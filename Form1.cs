//Changelog v0.1.1 to 0.1.2development

//Last commit introduced a bug by not saving settings on exit when serial port is closed
//----------Commit
//Code cleanup
//Some stability issues fixed
 
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
        const string ver = "0.1.2development";//app version
        string rxString;
        List<string> fileLines;
        Int32 fileLinesCount;//for file streaming control
        Int32 fileLinesSent;//for file streaming control
        Int32 fileLinesConfirmed;//for file streaming control
        const int grblBuferSize = 127;//rx bufer size of grbl on arduino 
        int bufFree = grblBuferSize;//actual suposed free bytes on grbl buffer

        TimeSpan elapsed;//elapsed time from file burnin
        DateTime timeInit;//time start to burning file

        bool transfer = false;//true whe transfer in progress
        bool dataProcessing;//false when no data processing pending

        bool jogging=false;//true when we are jogging

        //Thread exception
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            MessageBox.Show(ex.Message, "Thread exception");
        }
        //Unhandled exception
        private static void Application_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject != null)
            {
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
                Text = "3dpBurner Sender v" + ver+"     "+ rxString;
                dataProcessing = false;
                return;
            }
            //jogging response?
            if (jogging)
            {
                jogging = false;
                serialPort1.Write("G90\r");//add a G90 absolute coords command
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
                return;
            }
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
                updateControls();
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
        //Send a line adding a CR
        private bool OpenPort()
        {
            try
            {
                serialPort1.PortName = cbPort.Text;
                serialPort1.BaudRate = Convert.ToInt32(cbBaud.Text);
                serialPort1.Open();
                dataProcessing = true;
                grblReset();
                return (true);
            }
            catch (Exception err)
            {
                logError("Opening port", err);
                return (false);
            }
        }
        private bool ClosePort()
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    grblReset();
                    serialPort1.Close();                  
                }
                updateControls();
                return (true);
            }
            catch (Exception err)
            {
                logError("Closing port", err);
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
                {
                    ClosePort();
                    return;
                }
            if (OpenPort())updateControls();                  
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
            btnZero.Text = "Zero\r\nCoord";
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
                cbPort.Text = Properties.Settings1.Default.port;
                cbBaud.Text = Properties.Settings1.Default.baud;
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
                Properties.Settings1.Default.baud = cbBaud.Text;
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
            serialPort1.Write(tbCommand.Text+"\r");
            tbCommand.Clear();
        }
        //TextBox manual command
        private void tbCommand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13) return;
            serialPort1.Write(tbCommand.Text + "\r");
            tbCommand.Clear();
        }
        //Jog X+ button
        private void bXup_Click(object sender, EventArgs e)
        {
            jogging = true;
            serialPort1.Write("G91G0X+" + tbStepSize.Text + "\r");      
        }
        //Jog X- button
        private void bXdown_Click(object sender, EventArgs e)
        {
            jogging = true;
            serialPort1.Write("G91G0X-" + tbStepSize.Text + "\r");  
        }
        //Jog Y+ button
        private void bYup_Click(object sender, EventArgs e)
        {
            jogging = true;
            serialPort1.Write("G91G0Y+" + tbStepSize.Text + "\r");
        }
        //Jog Y- button
        private void bYdown_Click(object sender, EventArgs e)
        {
            jogging = true;
            serialPort1.Write("G91G0Y-" + tbStepSize.Text + "\r");
        }
        //Homming button
        private void bHome_Click(object sender, EventArgs e)
        {
            serialPort1.Write("$H\r");
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
            //ClosePort(); return;
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
            serialPort1.Write("$X\r");
        }
        //Update time elapsed
        private void tmrUpdates_Tick(object sender, EventArgs e)
        {
            if (transfer)//if active transfer update elapsed time
            {
                elapsed = DateTime.UtcNow - timeInit;
                lblElapsed.Text = elapsed.ToString(@"hh\:mm\:ss");
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
                    updateControls();
                }
            }          
        }
        //Laser On button
        private void btnLaserOn_Click(object sender, EventArgs e)
        {
            serialPort1.Write("M3\r");
        }
        //Laser Off button
        private void btsLaserOff_Click(object sender, EventArgs e)
        {
            serialPort1.Write("M5\r");
        }
        //Custom 1 button
        private void btnCustom1_Click(object sender, EventArgs e)
        {
            serialPort1.Write(tbCustom1.Text + "\r");
        }
        //Custom 1 textBox  
        private void tbCustom1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13) return;
            serialPort1.Write(tbCustom1.Text + "\r");
        }
        //Custom2 button
        private void btnCustom2_Click(object sender, EventArgs e)
        {
            serialPort1.Write(tbCustom2.Text + "\r");
        }
        //Custom 2 textBox
        private void tbCustom2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13) return;
            serialPort1.Write(tbCustom2.Text + "\r");
        }
        //Homing button
        private void btnZero_Click(object sender, EventArgs e)
        {
            serialPort1.Write("G92X0Y0Z0\r");
        }
        //Clear log button
        private void btlClearLog_Click(object sender, EventArgs e)
        {
            rtbLog.Clear();
        }
        //Laser PWR button
        private void btnLaserPwr_Click(object sender, EventArgs e)
        {
            serialPort1.Write("S" + tbLaserPwr.Text+"\r");
        }  
    }
}
