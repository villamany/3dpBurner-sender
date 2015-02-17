/*Changelog 

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

namespace _3dpBurner
{
    public partial class frm3dpBurner : Form
    {
        const string ver = "0.2.1";//app version
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
            updateControls();
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
        //update visual controls status (Enable/Disable controls)
        private void updateControls()
        {
            if (serialPort1.IsOpen) bOpenPort.Text = "Close"; else bOpenPort.Text = "Open";
            bStart.Enabled = serialPort1.IsOpen && !transfer;
            bOpenPort.Enabled = !transfer;
            cbPort.Enabled = !serialPort1.IsOpen;
            cbBaud.Enabled = !serialPort1.IsOpen;
            bRefreshport.Enabled = !serialPort1.IsOpen;

            tbFile.Enabled = !transfer;
            bOpenfile.Enabled = !transfer;

            gbJog.Enabled = serialPort1.IsOpen && !transfer;
            gbLaserControl.Enabled = serialPort1.IsOpen && !transfer;
            gbCustom.Enabled = serialPort1.IsOpen && !transfer;
            gbReference.Enabled = serialPort1.IsOpen && !transfer;

            btnReset.Enabled = serialPort1.IsOpen;
            if (btnReset.Enabled) btnReset.BackColor = Color.Red; else btnReset.BackColor = Color.WhiteSmoke;

            tbCommand.Enabled = serialPort1.IsOpen && !transfer;
            bSendCmd.Enabled = tbCommand.Enabled;     
            
            restoreSettingsToolStripMenuItem.Enabled=!serialPort1.IsOpen;
        }
        //Update file progress (progressBars and labels)
        private void updateProgress()
        {
            pbFile.Value = fileLinesConfirmed;
            pbBufer.Value = grblBuferSize - bufFree;
            lblBuf.Text = Convert.ToString(pbBufer.Value);//
            //file progress status
            if ((!File.Exists(tbFile.Text)) || (fileLinesCount < 1) )//|| (fileLinesSent < 1))
                lblFileProgress.Text = "0% (0/0 lines)";//"0%   ( 0/0 lines )";
            else
                lblFileProgress.Text = Convert.ToString(fileLinesConfirmed * 100 / fileLinesCount) + "% (" + Convert.ToString(fileLinesConfirmed) + "/" + Convert.ToString(fileLinesCount) + " lines)";
        }
        //Process the received data line
        private void dataRx(object sender, EventArgs e)
        {
            //staus message?
            if ((rxString.Length > 0) && (rxString[0] == '<'))
            {
                toolStripStatusLabel1.Text =rxString;
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
                transfer = false;
                updateProgress();
                rtbLog.AppendText("[File done @" + lblElapsed.Text + "]\r\n");
                rtbLog.ScrollToCaret();
                MessageBox.Show("Yeah!. Burning Done!\r\n\r\nWorking time: " + lblElapsed.Text, "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                updateControls();
             }
             else//not finished
             {
                if (fileLinesSent < fileLinesCount) sendNextLine();//If more lines on file, send it
             }
             updateProgress();
             dataProcessing = false;
        }
        //Send next line from fileStreaming
        private void sendNextLine()
        {
            while ((fileLinesSent < fileLinesCount) && (bufFree >= fileLines[fileLinesSent].Length + 1))
            {
                serialPort1.Write(fileLines[fileLinesSent] + "\r");
                bufFree -= (fileLines[fileLinesSent].Length + 1);
                fileLinesSent++;
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
                    //serialPort1.DiscardInBuffer();
                    //serialPort1.DiscardOutBuffer();
                    serialPort1.Close();
                    mens = "Error reading line from serial port";
                    err = errort;
                    this.Invoke(new EventHandler(logErrorThr));
                    //return;
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
                updateControls();
            }
        }
        //Open port
        private bool OpenPort()
        {
            try
            {
                serialPort1.PortName = cbPort.Text;
                serialPort1.BaudRate = Convert.ToInt32(cbBaud.Text);
                serialPort1.Open();
                dataProcessing = true;
                grblReset();
                updateControls();
                return (true);
            }
            catch (Exception err)
            {
                logError("Opening port", err);
                updateControls();
                return (false);
            }
        }
        private bool ClosePort()
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();                  
                }
                updateControls();
                return (true);
            }
            catch (Exception err)
            {
                logError("Closing port", err);
                updateControls();
                return (false);
            }
        }
        //Send reset sentence
        private void grblReset()//Stop/reset button
        {
            transfer = false;
            rtbLog.AppendText("[CTRL-X]");
            var dataArray = new byte[] { 24 };//Ctrl-X
            serialPort1.Write(dataArray, 0, 1);         
        }
        //Open port button
        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen) 
                ClosePort();
            else
            OpenPort();                  
        }
        //Refresh port names
        private void refreshPorts()
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
        //Form on load
        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "3dpBurner Sender v" + ver;
            bHome.Text = "Go\r\nHome";
            btnZero.Text = "Zero\r\nXY";
            btnUnlock.Text = "Unlock\r\nAlarm";
            refreshPorts();
            pbBufer.Maximum = grblBuferSize;
            updateControls();
            loadSettings();
            prepareFile();
        }
        //Load settings
        private void loadSettings()
        {
            try
            {   
                string mode;
                cbPort.Text = Properties.Settings1.Default.port;
                cbBaud.Text = Properties.Settings1.Default.baud;
                tbFile.Text = Properties.Settings1.Default.file;
                tbStepSize.Text = Properties.Settings1.Default.step;
                tbLaserPwr.Text = Properties.Settings1.Default.pwr;
                tbCustom1.Text = Properties.Settings1.Default.custom1;
                tbCustom2.Text = Properties.Settings1.Default.custom2;
                mode = Properties.Settings1.Default.mode;
                if (mode==axisMillToolStripMenuItem.Text)
                {
                    selectMode(axisMillToolStripMenuItem);
                }
                else
                    if (mode==axisLaserPWRSToolStripMenuItem.Text)
                    {
                        selectMode(axisLaserPWRSToolStripMenuItem);
                    }
                    else
                        if (mode == axisLaserPWRZToolStripMenuItem.Text)
                        {
                            selectMode(axisLaserPWRZToolStripMenuItem);
                        }
                        else
                            if (mode == axisLaserToolStripMenuItem.Text)
                            {
                                selectMode(axisLaserToolStripMenuItem);
                            }
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
                string mode="";//get selected mode
                if(axisMillToolStripMenuItem.Checked) mode=axisMillToolStripMenuItem.Text;//3 axis mill
                else if (axisLaserPWRSToolStripMenuItem.Checked) mode = axisLaserPWRSToolStripMenuItem.Text;//2 axis laser power with S
                else if (axisLaserPWRZToolStripMenuItem.Checked) mode = axisLaserPWRZToolStripMenuItem.Text;//2 axis laser power with Z
                else if (axisLaserToolStripMenuItem.Checked) mode = axisLaserToolStripMenuItem.Text;//3 axis laser

                Properties.Settings1.Default.port = cbPort.Text;
                Properties.Settings1.Default.baud = cbBaud.Text;
                Properties.Settings1.Default.file = tbFile.Text;
                Properties.Settings1.Default.step = tbStepSize.Text;
                Properties.Settings1.Default.pwr = tbLaserPwr.Text;
                Properties.Settings1.Default.custom1 = tbCustom1.Text;
                Properties.Settings1.Default.custom2 = tbCustom2.Text;
                Properties.Settings1.Default.mode = mode;
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
        //Refresh button
        public void bRefreshport_Click(object sender, EventArgs e)
        {

            refreshPorts();
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
                prepareFile();
            }
        }
        //Prepare file
        private void prepareFile()
        {
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
                    //line.Trim();
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
                pbFile.Maximum = fileLinesCount;//progressBar maximun update
                elapsed = TimeSpan.Zero;
                lblElapsed.Text = elapsed.ToString(@"hh\:mm\:ss");
            }
            updateProgress();
        }
        //Send file button
        private void bStar_Click(object sender, EventArgs e)
        {             
                if (!File.Exists(tbFile.Text))
                {
                    logError("Error opening file",null);
                    return;
                }
                prepareFile();
                transfer = true;
                fileLinesConfirmed = 0;
                timeInit = DateTime.UtcNow;
                rtbLog.AppendText("[Sending file...]\r\n");
                rtbLog.ScrollToCaret();
                sendNextLine();
                updateControls();
        }
        //Reset button
        private void button5_Click(object sender, EventArgs e)
        {
            grblReset();
            transfer = false;
            updateControls();          
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
                elapsed = DateTime.UtcNow - timeInit;
                lblElapsed.Text = elapsed.ToString(@"hh\:mm\:ss");
                remaining = TimeSpan.FromSeconds((fileLinesCount - fileLinesConfirmed) * Convert.ToInt32(elapsed.TotalSeconds) / fileLinesConfirmed);
                lblRemaining.Text = remaining.ToString(@"hh\:mm\:ss");
            }
            //retrieve GRBL status       
            if (serialPort1.IsOpen)
            {
                try
                {
                    var dataArray = new byte[] { Convert.ToByte('?') };
                    serialPort1.Write(dataArray, 0, 1);
                }
                catch (Exception er)
                {
                    logError("Retrieving GRBL status", er);
                    serialPort1.Close();
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
            //Mode 2axisLaserPwrZ
            if (axisLaserPWRZToolStripMenuItem.Checked) sendLine("Z" + tbLaserPwr.Text);//Variable spindle PWM managed by 'Z'
            //Mode 2axisLaserPwrS or 3axisLaser or 3axisMill
            else
                sendLine("S" + tbLaserPwr.Text);//Variable spindle PWM managed by 'Z'
        }
        //Select mode (enable/disable and mod user controls for the specified mode)
        private void selectMode(ToolStripMenuItem mode)
        {
            axisMillToolStripMenuItem.Checked=false;
            axisLaserPWRSToolStripMenuItem.Checked=false;
            axisLaserPWRZToolStripMenuItem.Checked=false;
            axisLaserToolStripMenuItem.Checked = false;
            mode.Checked = true;
                //3axis mode? (mode 3axisMill or 3axisLaser). Show 3axis controls
                if(mode==axisMillToolStripMenuItem|mode==axisLaserToolStripMenuItem)
                {
                    btnZdown.Visible = true;
                    btnZup.Visible = true;
                    btnZero.Visible=false;
                    btnZeroXY.Visible = true;
                    btnZeroZ.Visible = true;
                    bXup.Location = new Point(51, 66);
                    bXdown.Location = new Point(5, 66);
                    bYup.Location = new Point(29, 21);
                    bYdown.Location = new Point(29, 111);
                    tbStepSize.Location = new Point(98, 125);
                }
                //2axis mode (mode 2axisLaserPwrS or 2axisLaserPwrZ).Show 2axis controls
                else
                {
                    btnZdown.Visible = false;
                    btnZup.Visible = false;
                    btnZero.Visible=true;
                    btnZeroXY.Visible = false;
                    btnZeroZ.Visible = false;
                    bXup.Location = new Point(96, 66);
                    bXdown.Location = new Point(4, 66);
                    bYup.Location = new Point(50, 21);
                    bYdown.Location = new Point(50, 111);
                    tbStepSize.Location = new Point(52, 76);
                }
                //Laser mode? (Mode 2axisLaserPwrS or 2axisLaserPwrZ or 3axisLaser). Rename laser controls
                if (mode==axisLaserPWRSToolStripMenuItem | mode==axisLaserPWRZToolStripMenuItem | mode==axisLaserToolStripMenuItem)
                    {
                        gbLaserControl.Text = "Laser";
                        btnLaserPwr.Text = "PWR";
                    }
                //Mill mode? (3axisMill). Rename mill controls
                else
                    {
                        btnZdown.Visible = true;
                        btnZup.Visible = true;
                        gbLaserControl.Text = "Spindle";
                        btnLaserPwr.Text = "RPM";
                    }
        }
        //Mode 3axisMill Selection. Standard 3 axis mill mode
        private void axisMillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectMode(axisMillToolStripMenuItem);
        }
        //Mode 2axisLaserPwrS Selection. 2 axis laser using "Sx" as power set command
        private void axisLaserPWRSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectMode(axisLaserPWRSToolStripMenuItem);
        }
        //Mode 2axisLaserPwrZ Selection. 2 axis laser using "Zx" as power set command
        private void axisLaserPWRZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectMode(axisLaserPWRZToolStripMenuItem);
        }
        //Mode 3axisLaser Selection. 3 axis laser (use "Sx" as power set command)
        private void axisLaserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectMode(axisLaserToolStripMenuItem);
        }
        //Jog Z+ button
        private void btnZup_Click(object sender, EventArgs e)
        {
            jogging = true;
            sendLine("G91G0Z+" + tbStepSize.Text);    
        }
        //Jog Z- button
        private void btnZdown_Click(object sender, EventArgs e)
        {
            jogging = true;
            sendLine("G91G0Z-" + tbStepSize.Text); 
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

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }  
    }
}
