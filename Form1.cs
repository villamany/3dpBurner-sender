using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;

namespace _3dpBurner
{
    public partial class frm3dpBurner : Form
    {
        const string ver = "0.1";
        string rxString;
        List<string> fileLines;
        Int32 fileLinesCount;
        Int32 fileLinesSent;
        Int32 fileLinesConfirmed;
        const int grblBuferSize = 127;//rx bufer size of grbl on arduino 
        int bufFree = grblBuferSize;//actual free bytes on grbl buffer

        TimeSpan elapsed;//elapsed time from file burnin
        DateTime timeInit;//time start to burning file

        bool transfer = false;
        bool lockRx = false;//lock rx critical variable for prevent data corruption
        string criticalRxString;

        bool jogging=false;//true when we are jogging

        public frm3dpBurner()
        {
            InitializeComponent();
        }
        //log a error message on console
        private void logError(string message, Exception err)
        {
            rtbLog.AppendText("[ERROR]: " + message+". " + err.Message);
        }
        //check status for enable/disable user controls
        private void checkControls()
        {
            if (serialPort1.IsOpen) bOpenPort.Text = "Close"; else bOpenPort.Text = "Open";
            if (transfer) bStart.Text = "Stop"; else bStart.Text="Start";
            cbPort.Enabled = !serialPort1.IsOpen;
            cbBaud.Enabled = !serialPort1.IsOpen;
            bRefreshport.Enabled = !serialPort1.IsOpen;

            tbCommand.Enabled = serialPort1.IsOpen;
            bSendCmd.Enabled = serialPort1.IsOpen;

            tbFile.Enabled = !transfer;
            bOpenfile.Enabled = !transfer;

            gbJog.Enabled = serialPort1.IsOpen && !transfer;
            gbLaserControl.Enabled = serialPort1.IsOpen && !transfer;
            gbCustom.Enabled = serialPort1.IsOpen && !transfer;
            gbReference.Enabled = serialPort1.IsOpen && !transfer;

            bStart.Enabled=(serialPort1.IsOpen);
            pbFile.Value = fileLinesConfirmed;
            pbBufer.Value = grblBuferSize - bufFree;

            btnReset.Enabled = serialPort1.IsOpen;                      
        }
        //Process received data
        private void dataRx(object sender, EventArgs e)
        {
            rxString=criticalRxString;//copy critical variable and unlock it
            lockRx = false;
 
            if ((rxString.Length>0)&&(criticalRxString[0]=='<'))//is a status message ?
            { //<Idle,MPos:0.000,0.000,0.000,WPos:0.000,0.000,0.000>
                Text = "3dpBurner Sender v" + ver+"     "+ rxString;           
            }
            
            else
            {           
                if (transfer)//is there a file transfer in progress? print line supose to be processed 
                {
                    rtbLog.AppendText(fileLines[fileLinesConfirmed]+ " >");
                }
                rtbLog.AppendText(rxString);//print received line response
                rtbLog.AppendText("\r");
                rtbLog.ScrollToCaret();
                if (transfer)//transfer in progress?
                {
                    bufFree += (fileLines[fileLinesConfirmed].Length+1);//update bytes supose to be free on grbl rx bufer
                    fileLinesConfirmed++;//line processed
                    if (fileLinesConfirmed >= fileLinesCount)//Transfer finished and provessed? Update status and controls
                    {
                        transfer = false;
                        checkControls();
                        //file progress status
                        if ((!File.Exists(tbFile.Text)) || (fileLinesCount < 1) || (fileLinesSent < 1))
                            lblFileProgress.Text = "0% (0 lines)";//"0%   ( 0/0 lines )";
                        else
                            lblFileProgress.Text = Convert.ToString(fileLinesSent * 100 / fileLinesCount) + "% (" + Convert.ToString(fileLinesCount) + " lines)";

                        MessageBox.Show("Yeah!. Burning Done!\r\n\r\nWorking time: "+ lblElapsed.Text ,"Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    
                    }
                    else//not finished and processed
                    {
                        if (fileLinesSent < fileLinesCount) sendNextLine();//If more lines on file, send it
                    }
                    if ((!File.Exists(tbFile.Text)) || (fileLinesCount < 1) || (fileLinesSent < 1))
                        lblFileProgress.Text = "0% (0 lines)";//"0%   ( 0/0 lines )";
                    else
                        lblFileProgress.Text = Convert.ToString(fileLinesConfirmed * 100 / fileLinesCount) + "% (" + Convert.ToString(fileLinesCount) + " lines)";

                    checkControls();
                }
                else
                {
                    if (jogging)//if jogging add a G90 absolute coords command
                    {
                        jogging = false;
                        sendLine("G90");
                    }
                }               
            }
        }
        private void sendNextLine()
        {
            while ((fileLinesSent < fileLinesCount) && (bufFree >= fileLines[fileLinesSent].Length + 1))
            {
                sendLine(fileLines[fileLinesSent]);
                bufFree -= (fileLines[fileLinesSent].Length + 1);
                fileLinesSent++;
                checkControls();
            }
        }
        //Rx from serial port
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            while (serialPort1.BytesToRead > 0)
            {
                while (lockRx) ;//wait until unlock critical variable
                lockRx = true;//lock critical variable
                criticalRxString = "";
                try
                {
                        criticalRxString += serialPort1.ReadTo("\r\n");//read line from grbl, discard CR LF
                        this.Invoke(new EventHandler(dataRx));//tigger rx process
                }
                catch (Exception err)
                {
                    logError("Reading GRBL response",err);
                }
               
            }
        }
        //Send a line adding the enter key
        private void sendLine(string data)
        {
            serialPort1.Write(data + "\r");
            if (!transfer) rtbLog.AppendText(data+" >");//if not in transfer log the txLine
        }

        private bool OpenPort()
        {
            try
            {
                rtbLog.Clear();
                Refresh();
                serialPort1.PortName = cbPort.Text;
                serialPort1.BaudRate = Convert.ToInt32(cbBaud.Text);
                serialPort1.Open();
                grblReset();
                checkControls();
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
                    Thread.Sleep(2000);     
                }
                checkControls();
                return (true);
            }
            catch (Exception err)
            {
                logError("Closing port", err);
                return (false);
            }
        }
        private void grblReset()//Stop/reset button
        {
            rtbLog.AppendText("[CTRL-X]");
            var dataArray = new byte[] { 24 };//Ctrl-X
            serialPort1.Write(dataArray, 0, 1);
            transfer = false;
        }
        private void button1_Click(object sender, EventArgs e)//Open port button
        {

            if (serialPort1.IsOpen) 
                {
                    ClosePort();
                }
                else
            {
                if (OpenPort())
                {
                    
                    checkControls();
                }
            }    
        }

        private void refreshPorts()
        {
            List<String> tList = new List<String>();

            cbPort.Items.Clear();

            foreach (string s in SerialPort.GetPortNames())
            {
                tList.Add(s);
            }

            if (tList.Count < 1)
            {
                MessageBox.Show("No serial ports found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                tList.Sort();
                cbPort.Items.AddRange(tList.ToArray());
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "3dpBurner Sender v" + ver;
            bHome.Text = "Go\r\nHome";
            btnZero.Text = "Zero\r\nCoord";
            btnUnlock.Text = "Unlock\r\nAlarm";

            refreshPorts();
            pbBufer.Maximum = grblBuferSize;
            checkControls();
            loadSettings();
            prepareFile();


            

           
  
           
        }
        private void loadSettings()
        {
        //    try
          //  {
            
                cbPort.Text = Properties.Settings1.Default.port;
                cbBaud.Text = Properties.Settings1.Default.baud;
                tbFile.Text = Properties.Settings1.Default.file;
                tbStepSize.Text = Properties.Settings1.Default.step;
                tbLaserPwr.Text = Properties.Settings1.Default.pwr;
                tbCustom1.Text = Properties.Settings1.Default.custom1;
                tbCustom2.Text = Properties.Settings1.Default.custom2;
      //      }
    //        catch { }
        }
        private void saveSettings()
        {
            //try
            //{
                Properties.Settings1.Default.port = cbPort.Text;
                Properties.Settings1.Default.baud = cbBaud.Text;
                Properties.Settings1.Default.file = tbFile.Text;
                Properties.Settings1.Default.step = tbStepSize.Text;
                Properties.Settings1.Default.pwr = tbLaserPwr.Text;
                Properties.Settings1.Default.custom1 = tbCustom1.Text;
                Properties.Settings1.Default.custom2 = tbCustom2.Text;
                Properties.Settings1.Default.Save();
//            }
  //          catch { }

        }
        private void bSendCmd_Click(object sender, EventArgs e)
        {
            sendLine(tbCommand.Text);
            tbCommand.Clear();
        }

        private void bXup_Click(object sender, EventArgs e)
        {
            jogging = true;
            sendLine("G91G0X+" + tbStepSize.Text);           
        }

        private void bXdown_Click(object sender, EventArgs e)
        {
            jogging = true;
            sendLine("G91G0X-" + tbStepSize.Text);
        }

        private void bYup_Click(object sender, EventArgs e)
        {
            jogging = true;
            sendLine("G91G0Y+" + tbStepSize.Text);
        }

        private void bYdown_Click(object sender, EventArgs e)
        {
            jogging = true;
            sendLine("G91G0Y-" + tbStepSize.Text);
        }

        private void bHome_Click(object sender, EventArgs e)
        {
            sendLine("$H");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tbStepSize.Text="0.01";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            tbStepSize.Text = "0.1";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            tbStepSize.Text = "1";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            tbStepSize.Text = "10";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            tbStepSize.Text = "100";
        }

        public void bRefreshport_Click(object sender, EventArgs e)
        {

            refreshPorts();
        }

        private void frm3dpBurner_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveSettings();
            ClosePort();
        }

        private void tbCommand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                sendLine(tbCommand.Text);
                tbCommand.Clear();
            }
        }

        private void bOpenfile_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbFile.Text = openFileDialog1.FileName;
                prepareFile();
            }
        }

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

                pbFile.Maximum = fileLinesCount;
            }
            //file progress status
            if ((!File.Exists(tbFile.Text)) || (fileLinesCount < 1))
            lblFileProgress.Text = "0% (0 lines)";//"0%   ( 0/0 lines )";
            else
                lblFileProgress.Text = Convert.ToString(fileLinesSent * 100 / fileLinesCount) + "% (" + Convert.ToString(fileLinesCount) + " lines)";

            checkControls();

           
        }
        private void bStar_Click(object sender, EventArgs e)
        {
            if (!transfer)
            {                
                if (!File.Exists(tbFile.Text))
                {
                    MessageBox.Show(this, "Error opening file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                prepareFile();
                transfer = true;
                fileLinesConfirmed = 0;
                timeInit = DateTime.UtcNow;
                sendNextLine();
                
            }
            else

            {
                transfer = false;
            }
            checkControls();
        }


        private void button5_Click(object sender, EventArgs e)//reset button
        {
            grblReset();
            transfer = false;
            checkControls();
            //prepareFile();

           
        }

        private void button11_Click(object sender, EventArgs e)
        {
            sendLine("$X");
        }


        //Update and show time elapsed
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
                var dataArray = new byte[] { Convert.ToByte('?') };
                serialPort1.Write(dataArray, 0, 1);
            }          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tbStepSize.Text = "5";
        }

        private void btnLaserOn_Click(object sender, EventArgs e)
        {
              sendLine("M3");
        }

        private void btsLaserOff_Click(object sender, EventArgs e)
        {
            sendLine("M5");
        }

        private void btnCustom1_Click(object sender, EventArgs e)
        {
            sendLine(tbCustom1.Text);
        }

        private void btnCustom2_Click(object sender, EventArgs e)
        {
            sendLine(tbCustom2.Text);
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            sendLine("G92X0Y0Z0");
        }

        private void btlClearLog_Click(object sender, EventArgs e)
        {
            rtbLog.Clear();
        }

        private void btnLaserPwr_Click(object sender, EventArgs e)
        {
            sendLine("S" + tbLaserPwr.Text);
        }
        //Custom 1 button  
        private void tbCustom1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                sendLine(tbCustom1.Text);
            }
        }
        //Custom 2 button 
        private void tbCustom2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                sendLine(tbCustom2.Text);
            }
        }      
}
}
