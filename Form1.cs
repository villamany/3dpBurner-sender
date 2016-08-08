/*  3dpBurner Sender. A GCODE sender for GRBL based devices.
    This file is part of 3dpBurner Sender application.
   
    Copyright (C) 2014-2015  Adrian V. J. (villamany) contact: villamany@gmail.com

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
//Main form
  
using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
//using System.Threading;
using System.Management;//for serial port device names

using System.Runtime.InteropServices;
// for DllImportAttribute //For prevent entering standby/switching the display device off.

//Latest changes

//-A more precise remaining time
//-Code cleanup
//-Other minor bugs and improvements

namespace _3dpBurner
{

    public partial class frm3dpBurner : Form
    {
        const string ver = "1.1";//app version
        string rxString;
        List<string> fileLines;
        Int32 fileLinesCount;//for file streaming control
        Int32 fileLinesSent;//for file streaming control
        Int32 fileLinesConfirmed;//for file streaming control
        const int grblBuferSize = 127;//rx bufer size of grbl on arduino 
        int bufFree = grblBuferSize;//actual suposed free bytes on grbl buffer

        TimeSpan elapsed;//elapsed time from file burnin
        TimeSpan remaining;//remaining time (estimated)
        DateTime timeInit;//time start to burning file

        bool transfer = false;//true whe transfer in progress
        bool dataProcessing;//false when no data processing pending

        bool jogging=false;//true when we are jogging
        
        int GRBL_errCount = 0;// aux for grbl errors count for auto close port when more than some continuous errors ocurrs (prevents pplication hangs)
        const int GRBL_errMax = 2;//Number of grbl response errors for auto close ports

        bool connected;//for log the connected message

        //Thread exception
        private void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            ClosePort();
            Exception ex = e.Exception;
            MessageBox.Show(ex.Message, "Thread exception");
        }
        //Unhandled exception
        private void Application_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject != null)
            {
                ClosePort();
                Exception ex = (Exception)e.ExceptionObject;
                MessageBox.Show(ex.Message, "Application exception");
            }
        }
        //For prevent entering standby/switching the display device off.
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);
        [FlagsAttribute]
        public enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001
            // Legacy flag, should not be used.
            // ES_USER_PRESENT = 0x00000004
        }
        //Constructor
        public frm3dpBurner()
        {
            InitializeComponent();
            System.Windows.Forms.Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(Application_UnhandledException);
        }
        //log serial port dataReceive thread error message
        public void logErrorThr(object sender, EventArgs e)
        {
            logError(mens,err);
        }
        //log a error message
        private void logError(string message, Exception err)
        {
            string textmsg = "\r\n[ERROR]: " + message + ". ";
            if (err != null) textmsg += err.Message;
            textmsg += "\r\n";
            rtbLog.AppendText(textmsg);
            rtbLog.ScrollToCaret();
        }
        private void setTransferTrue()
        {
            transfer = true;
            //prevent system idle
            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS | EXECUTION_STATE.ES_SYSTEM_REQUIRED | EXECUTION_STATE.ES_AWAYMODE_REQUIRED | EXECUTION_STATE.ES_DISPLAY_REQUIRED);
        }
        private void setTransferFalse()
        {
            transfer = false;
            //restore system idle state
            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
        }
        //Process the received data line
        private void dataRx(object sender, EventArgs e)
        {
            //staus message?
            if ((rxString.Length > 0) && (rxString[0] == '<'))
            {
                toolStripStatusLabel1.Text =rxString;
                if (!connected)
                {
                    rtbLog.AppendText("\r\n[CONNECTED]\r\n");
                    rtbLog.ScrollToCaret();
                    rtbLog.Refresh();
                    connected=true;
                }

                if (rxString.Contains("Run")) statusStrip1.BackColor = Color.DodgerBlue;
                else
                    if (rxString.Contains("Idle")) statusStrip1.BackColor = Color.YellowGreen;
                    else
                        if (rxString.Contains("Alarm")) statusStrip1.BackColor = Color.DarkOrange;
                        else
                            if (rxString.Contains("Home")) statusStrip1.BackColor = Color.Violet;
                            else
                               if (rxString.Contains("Queue")) statusStrip1.BackColor = Color.FromArgb(255,255,10);
                                else
                                toolStripStatusLabel1.BackColor = SystemColors.Control;

                dataProcessing = false;
                return;
            }
            //If no transfer in progress
            if (!transfer)
            {
                rtbLog.AppendText(rxString);//print received line response
                rtbLog.AppendText("\r");
                rtbLog.ScrollToCaret();
                dataProcessing = false;
            }
            //jogging response?
            if (jogging)
            {
                jogging = false;
                sendLine("G90");//add a G90 absolute coords command
                dataProcessing = false;
                return;
            }
            //if no transfer, no any more to do
            if (!transfer) return;
            //line transfer response
            if (rxString != "ok")//Add line-response only if not ok (if many lines the stream procces is slowly)
            {
                rtbLog.AppendText(fileLines[fileLinesConfirmed] + " >" + rxString+"\r");
                rtbLog.ScrollToCaret();
            }
            bufFree += (fileLines[fileLinesConfirmed].Length + 1);//update bytes supose to be free on grbl rx bufer
            fileLinesConfirmed++;//line processed
            if (fileLinesConfirmed >= fileLinesCount)//Transfer finished and processed? Update status and controls
            {
                setTransferFalse();
                pbFile.Value = 100;
                lblFileProgress.Text = "100%";
                lblRemaining.Text = "00:00:00";
               // updateProgress();
                rtbLog.AppendText("[Yeah!. Burning Done! @" + lblElapsed.Text + "]\r\n");
                rtbLog.ScrollToCaret();
             }
             else//not finished
             {
                if (fileLinesSent < fileLinesCount) sendNextLine();//If more lines on file, send it
             }
             //updateProgress();
             dataProcessing = false;
        }
        //Send next line from fileStreaming
        private void sendNextLine()
        {
            try
            {
                while ((fileLinesSent < fileLinesCount) && (bufFree >= fileLines[fileLinesSent].Length + 1))
                {
                    serialPort1.Write(fileLines[fileLinesSent] + "\r");
                    bufFree -= (fileLines[fileLinesSent].Length + 1);
                    fileLinesSent++;
                }
            }
            catch (Exception er)
            {
                logError("Error sending next line", er);
                ClosePort();
            }
        }
        //Rx from serial port
        string mens;
        Exception err;
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {           
            while ((serialPort1.IsOpen)&& (serialPort1.BytesToRead > 0))
            {
                rxString = string.Empty;
                try
                {
                    rxString = serialPort1.ReadTo("\r\n");//read line from grbl, discard CR LF
                    dataProcessing = true;
                    this.Invoke(new EventHandler(dataRx));//tigger rx process 
                    while ((serialPort1.IsOpen) && (dataProcessing)) ;//wait previous data line processed done
                }
                catch (Exception errort)
                {
                    mens = "Error reading line from serial port";
                    ClosePort();
                    err = errort;
                    this.Invoke(new EventHandler(logErrorThr));
                }
             }
        }
        //Send a line adding a CR and log it
        private void sendLine(string data)
        {
            try
            {
                serialPort1.Write(data + "\r");
                rtbLog.AppendText(data + " >");//if not in transfer log the txLine
            }
            catch(Exception err)
            {
                logError("Sending line", err);
            }
        }
        //Open port
        private bool OpenPort()
        {
            try
            {
                connected = false;
                toolStripStatusLabel1.Text = "";
                toolStripStatusLabel1.BackColor=SystemColors.Control;
                rtbLog.AppendText("\r\n[CONNECTING]\r\n");
                rtbLog.ScrollToCaret();
                rtbLog.Refresh();

                serialPort1.PortName = cbPort.Text;

                serialPort1.Open();
                serialPort1.DiscardInBuffer();
                serialPort1.DiscardOutBuffer();
                
                dataProcessing = true;
                GRBL_errCount = 0;
                return (true);
            }
            catch (Exception err)
            {
                logError("Opening port", err);
                ClosePort();
                return (false);
            }
        }
        private bool ClosePort()
        {
            if (transfer) { button5_Click(this, null); return (false);}
            else
            {
                try
                {
                    setTransferFalse();
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.DiscardInBuffer();
                        serialPort1.DiscardOutBuffer();
                        serialPort1.Close();
                        rtbLog.AppendText("\r\n[DISCONNECTED]\r\n");
                        rtbLog.ScrollToCaret();
                        toolStripStatusLabel1.BackColor = SystemColors.Control;

                    }
                    toolStripStatusLabel1.Text = "";
                    toolStripStatusLabel1.BackColor = SystemColors.Control;
                    return (true);
                }
                catch (Exception err)
                {
                    logError("Closing port", err);
                    return (false);
                }
            }
        }
        //Send reset sentence
        private void grblReset()//Stop/reset button
        {
            try
            {
                setTransferFalse();
                rtbLog.AppendText("[RESET]");
                var dataArray = new byte[] { 24 };//Ctrl-X
                serialPort1.Write(dataArray, 0, 1);
            }
            catch (Exception err)
            {
                logError("Reset command fail", err);
            }

        }
        //Open port button
        private void button1_Click(object sender, EventArgs e)
        {                    
            if (serialPort1.IsOpen) ClosePort(); else OpenPort();                  
        }
        //Refresh port names on the combo box
        private void refreshPorts()
        {
            try
            {
                List<String> tList = new List<String>();
                cbPort.Items.Clear();
                foreach (string s in SerialPort.GetPortNames()) tList.Add(s);
                if (tList.Count < 1) logError("No serial ports found", null);
                else
                {
                    tList.Sort();
                    cbPort.Items.AddRange(tList.ToArray());
                }                             
            }
            catch (Exception e)
            {
                logError("Refreshing available ports", e);
            }
        }
        //Form on load
        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "3dpBurner Sender v" + ver;
            bHome.Text = "Go\r\nHome";
            btnZero.Text = "Zero\r\nXY";
            btnUnlock.Text = "Unlock\r\nAlarm";
            loadSettings();
        }
        //Load settings
        private void loadSettings()
        {
            try
            {   
                cbPort.Text = Properties.Settings1.Default.port;
                tbFile.Text = Properties.Settings1.Default.file;
                tbStepSize.Text = Properties.Settings1.Default.step;
                tbLaserPwr.Text = Properties.Settings1.Default.pwr;
                tbCustom1.Text = Properties.Settings1.Default.custom1;
                tbCustom2.Text = Properties.Settings1.Default.custom2;
            }
            catch (Exception e)
            {
                logError("Loading settings",e);
            }
        }
        //Save settings
        private void saveSettings()
        {
            try
            {
                Properties.Settings1.Default.port = cbPort.Text;
                Properties.Settings1.Default.file = tbFile.Text;
                Properties.Settings1.Default.step = tbStepSize.Text;
                Properties.Settings1.Default.pwr = tbLaserPwr.Text;
                Properties.Settings1.Default.custom1 = tbCustom1.Text;
                Properties.Settings1.Default.custom2 = tbCustom2.Text;
                Properties.Settings1.Default.Save();
                
            }
            catch (Exception e)
            {
                logError("Saving settings", e);
            }
        }
        //Send command button
        private void bSendCmd_Click(object sender, EventArgs e)
        {
            sendLine(tbCommand.Text);
            tbCommand.Clear();
        }
        //TextBox manual command
        private void tbCommand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13) return;
            sendLine(tbCommand.Text);
            tbCommand.Clear();
        }
        //Jog X+ button
        private void bXup_Click(object sender, EventArgs e)
        {
            jogging = true;
            sendLine("G91G0X+" + tbStepSize.Text);      
        }
        //Jog X- button
        private void bXdown_Click(object sender, EventArgs e)
        {
            jogging = true;
            sendLine("G91G0X-" + tbStepSize.Text);  
        }
        //Jog Y+ button
        private void bYup_Click(object sender, EventArgs e)
        {
            jogging = true;
            sendLine("G91G0Y+" + tbStepSize.Text);
        }
        //Jog Y- button
        private void bYdown_Click(object sender, EventArgs e)
        {
            jogging = true;
            sendLine("G91G0Y-" + tbStepSize.Text);
        }
        //Homming button
        private void bHome_Click(object sender, EventArgs e)
        {
            sendLine("$H");
        }
        //.01 Step button
        private void button12_Click(object sender, EventArgs e)
        {
            tbStepSize.Text="0.01";
        }
        //.1 Step button
        private void button19_Click(object sender, EventArgs e)
        {
            tbStepSize.Text = "0.1";
        }
        //1 Step button
        private void button20_Click(object sender, EventArgs e)
        {
            tbStepSize.Text = "1";
        }
        //5 step button
        private void button1_Click_1(object sender, EventArgs e)
        {
            tbStepSize.Text = "5";
        }
        //10 Step button
        private void button21_Click(object sender, EventArgs e)
        {
            tbStepSize.Text = "10";
        }
        //100 Step button
        private void button22_Click(object sender, EventArgs e)
        {
            tbStepSize.Text = "100";
        }
        //Fornm on close
        private void frm3dpBurner_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveSettings();
            if (transfer)
           {
                button5_Click(this, null);           
                e.Cancel=true;
            }
            else
            {
                ClosePort();
            }
        }
        //Open file
        private void bOpenfile_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbFile.Text = openFileDialog1.FileName;
            }
        }
        //Prepare file
        private void prepareFile()
        {
            rtbLog.AppendText("[Optimizing file...]\r\n");
            rtbLog.ScrollToCaret();
            rtbLog.Refresh();
            fileLinesSent = 0;
            fileLinesCount = 0;
            fileLinesConfirmed = 0;
            bufFree = grblBuferSize;
            if (File.Exists(tbFile.Text))
            {
                fileLines = new List<string>();
                StreamReader file = new StreamReader(tbFile.Text);
                string line = "";
                line = file.ReadLine();
                while (line!= null)
                {
                    line=line.Replace(" ", "");//remove spaces
                    line = line.Replace("\r", " ");//remove CR
                    line = line.Replace("\n", " ");//remove LF
                    line = line.ToUpper();//all uppercase
                    line = line.Trim();
                   if ((!string.IsNullOrEmpty(line))&&(line[0]!='('))//trim lines and remove all empty lines and comment lines
                    {
                        fileLines.Add(line);//add line to list to send
                        fileLinesCount++;//Count total lines
                    }
                    line = file.ReadLine();
                }
                file.Close();
                elapsed = TimeSpan.Zero;
                lblElapsed.Text = elapsed.ToString(@"hh\:mm\:ss");
            }
        }
        //Send file button
        private void bStart_Click(object sender, EventArgs e)
        {

                {
                    rtbLog.AppendText("[RESUME]\r\n");
                    rtbLog.ScrollToCaret();

                    try
                    {
                        serialPort1.Write("~");
                    }
                    catch (Exception err)
                    {
                        logError("Sending command", err);
                    }

                }
        }
        //Reset button
        private void button5_Click(object sender, EventArgs e)
        {
                grblReset();
        }
        //Unlock alarm button
        private void button11_Click(object sender, EventArgs e)
        {
            sendLine("$X");
        }
        //Update time elapsed
        private void tmrUpdates_Tick(object sender, EventArgs e)
        {
            if (transfer)//if active transfer update elapsed/remaining time time
            {
                float progressPorc;

                //file progress status
                if ((!File.Exists(tbFile.Text)) || (fileLinesCount < 1))//|| (fileLinesSent < 1))
                    progressPorc = 0;
                else
                {
                    progressPorc = (float)(fileLinesConfirmed * 100.0 / fileLinesCount);
                    //Text = Convert.ToString(fileLinesConfirmed) + "/" + Convert.ToString(fileLinesCount) + " lines "+ Convert.ToString (fileLinesConfirmed * 100.0 / fileLinesCount)+"%";//debug
                }
                pbFile.Value = Convert.ToInt32(progressPorc);
                lblFileProgress.Text = Convert.ToString((Int32)progressPorc) + "%";// "% (" + Convert.ToString(fileLinesConfirmed) + "/" + Convert.ToString(fileLinesCount) + " lines)";



                elapsed = DateTime.UtcNow - timeInit;
                lblElapsed.Text = elapsed.ToString(@"hh\:mm\:ss");
                if (fileLinesConfirmed>0)
                remaining = TimeSpan.FromSeconds((100 - progressPorc) * (elapsed.TotalSeconds / progressPorc));
                lblRemaining.Text = remaining.ToString(@"hh\:mm\:ss");

            }
            //retrieve GRBL status       
            if (serialPort1.IsOpen)
            {
                try
                {
                    var dataArray = new byte[] { Convert.ToByte('?') };
                    serialPort1.Write(dataArray, 0, 1);
                    GRBL_errCount=0;
                }
                catch (Exception er)
                {   
                    GRBL_errCount ++;
                    logError("Retrieving 3dpBurner status ( TRY " + GRBL_errCount.ToString() + " / " + GRBL_errMax.ToString() + " )", er);

                    if (GRBL_errCount >= GRBL_errMax)
                    {
                        logError("3dpBurner seem to not respond", null);
                        ClosePort();
                    }
                }
            }
        }
        //Laser On button
        private void btnLaserOn_Click(object sender, EventArgs e)
        {
            sendLine("M3");
        }
        //Laser Off button
        private void btsLaserOff_Click(object sender, EventArgs e)
        {
            sendLine("M5");
        }
        //Custom 1 button
        private void btnCustom1_Click(object sender, EventArgs e)
        {
            sendLine(tbCustom1.Text);
        }
        //Custom 1 textBox  
        private void tbCustom1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13) return;
            sendLine(tbCustom1.Text);
        }
        //Custom2 button
        private void btnCustom2_Click(object sender, EventArgs e)
        {
            sendLine(tbCustom2.Text);
        }
        //Custom 2 textBox
        private void tbCustom2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13) return;
            sendLine(tbCustom2.Text);
        }
        //Homing button
        private void btnZero_Click(object sender, EventArgs e)
        {
            sendLine("G92X0Y0");
        }
        //Clear log button
        private void btlClearLog_Click(object sender, EventArgs e)
        {
            rtbLog.Clear();
        }
        //Laser PWR button
        private void btnLaserPwr_Click(object sender, EventArgs e)
        {
            sendLine("S" + tbLaserPwr.Text);//Variable spindle PWM managed by 'Z'
        }
 
        //Zero XY button
        private void btnZeroXY_Click(object sender, EventArgs e)
        {
            sendLine("G92X0Y0");
        }
        //Zero Z button
        private void btnZeroZ_Click(object sender, EventArgs e)
        {
            sendLine("G92Z0");
        }
        //Restore settings
        private void restoreSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Restore Settings?", "Restore Settings", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.OK) return;
            Properties.Settings1.Default.Reset();
            Properties.Settings1.Default.Save();
            loadSettings();
        }
        //About dialog
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frmAb = new frmAbout();
            frmAb.ShowDialog();
        }
        //Enter on power texbox-Send Sxx command
        private void tbLaserPwr_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (e.KeyChar != (char)13) return;
                sendLine("S"+tbLaserPwr.Text);
            }
        }
        //Serial port selection
        private void cbPort_DropDown(object sender, EventArgs e)
        {
            refreshPorts();
        }
        //Pause button
        private void bPause_Click(object sender, EventArgs e)
        {
            rtbLog.AppendText("[PAUSE]\r\n");
            rtbLog.ScrollToCaret();
            rtbLog.Refresh();
            try
            {
                serialPort1.Write("!");//ensure pause is received
            }
            catch (Exception err)
            {
                logError("Sending command", err);
            }
        }
        //Reset button
        private void btnReset_Click(object sender, EventArgs e)
        {
            grblReset();
        }

        //Send file button
        private void btnFileStart_Click(object sender, EventArgs e)
        {
            if (!transfer)
            {
                if (!File.Exists(tbFile.Text))
                {
                    logError("Error opening file", null);
                    return;
                }               
                btnFileStart.Text = "Abort File";
                btnFileStart.BackColor = Color.Salmon;
                bOpenfile.Enabled = false;
                Refresh();
                prepareFile();
                rtbLog.AppendText("[Sending file...]\r\n");
                rtbLog.ScrollToCaret();
                rtbLog.Refresh();
                setTransferTrue();
                fileLinesConfirmed = 0;
                timeInit = DateTime.UtcNow;
                sendNextLine();
            }
            else
            {
                setTransferFalse();
                pbFile.Value = 0;
                rtbLog.AppendText("[Stop]\r\n");
                rtbLog.ScrollToCaret();
            }
        }
        //Visual controls updates
        private void tmrControlsUpdate_Tick(object sender, EventArgs e)
        {
             if (serialPort1.IsOpen)
            {
                bOpenPort.Text = "Disconnect";
                bOpenPort.BackColor = Color.Salmon;
            }
            else
            {
                bOpenPort.Text = "Connect";
                bOpenPort.BackColor = Color.YellowGreen;
            }

            if (transfer)
            {
                btnFileStart.Text="Abort File";
                btnFileStart.BackColor = Color.Salmon;
                bOpenfile.Enabled = false;
            }
            else
            {
                btnFileStart.Text = "Send File";
                btnFileStart.BackColor = Color.YellowGreen;
                bOpenfile.Enabled = true;
            }
            if (toolStripStatusLabel1.Text== "") statusStrip1.BackColor = SystemColors.Control;
        }
        //Serial ports info button
        private void btnPortsInfo_Click(object sender, EventArgs e)
        {
            try
            {
                //Display port and device names on the console
                rtbLog.AppendText("\r\n[PORTS INFO]\r\n");
                rtbLog.ScrollToCaret();  
                ManagementObjectSearcher searcher =
            new ManagementObjectSearcher("root\\CIMV2",
            "SELECT * FROM Win32_PnPEntity");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    if ((queryObj["Caption"] != null) && (queryObj["Name"].ToString().Contains("(COM")))
                    {

                        rtbLog.AppendText((queryObj["Caption"]).ToString()+"\r\n");
                        rtbLog.ScrollToCaret();
                    }
                }
                rtbLog.AppendText("\r\n");
            }
            catch (Exception er)
            {
                logError("Geting available ports info", er);
            }
        }

    }
}
