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
//Form 1 (Main form) design

namespace _3dpBurner
{
    partial class frm3dpBurner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm3dpBurner));
            this.bOpenPort = new System.Windows.Forms.Button();
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.cbBaud = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.bXdown = new System.Windows.Forms.Button();
            this.bXup = new System.Windows.Forms.Button();
            this.bYup = new System.Windows.Forms.Button();
            this.bYdown = new System.Windows.Forms.Button();
            this.btnLaserOn = new System.Windows.Forms.Button();
            this.btsLaserOff = new System.Windows.Forms.Button();
            this.btnCustom1 = new System.Windows.Forms.Button();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.bOpenfile = new System.Windows.Forms.Button();
            this.bStart = new System.Windows.Forms.Button();
            this.bSendCmd = new System.Windows.Forms.Button();
            this.bHome = new System.Windows.Forms.Button();
            this.tbStepSize = new System.Windows.Forms.TextBox();
            this.pbFile = new System.Windows.Forms.ProgressBar();
            this.pbBufer = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCustom2 = new System.Windows.Forms.Button();
            this.tbCustom1 = new System.Windows.Forms.TextBox();
            this.tbCustom2 = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.gbJog = new System.Windows.Forms.GroupBox();
            this.btnZdown = new System.Windows.Forms.Button();
            this.btnZup = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblBuf = new System.Windows.Forms.Label();
            this.lblElapsed = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblFileProgress = new System.Windows.Forms.Label();
            this.tbLaserPwr = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tmrUpdates = new System.Windows.Forms.Timer(this.components);
            this.gbConecction = new System.Windows.Forms.GroupBox();
            this.bRefreshport = new System.Windows.Forms.Button();
            this.gbLaserControl = new System.Windows.Forms.GroupBox();
            this.btnLaserPwr = new System.Windows.Forms.Button();
            this.tbCommand = new System.Windows.Forms.TextBox();
            this.gbConsole = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btlClearLog = new System.Windows.Forms.Button();
            this.gbReference = new System.Windows.Forms.GroupBox();
            this.btnZeroZ = new System.Windows.Forms.Button();
            this.btnZeroXY = new System.Windows.Forms.Button();
            this.btnZero = new System.Windows.Forms.Button();
            this.gbCustom = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axisMillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axisLaserPWRSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axisLaserPWRZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axisLaserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbJog.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbConecction.SuspendLayout();
            this.gbLaserControl.SuspendLayout();
            this.gbConsole.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbReference.SuspendLayout();
            this.gbCustom.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bOpenPort
            // 
            this.bOpenPort.Location = new System.Drawing.Point(148, 17);
            this.bOpenPort.Name = "bOpenPort";
            this.bOpenPort.Size = new System.Drawing.Size(64, 23);
            this.bOpenPort.TabIndex = 0;
            this.bOpenPort.Text = "Open";
            this.bOpenPort.UseVisualStyleBackColor = true;
            this.bOpenPort.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbPort
            // 
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(9, 19);
            this.cbPort.MaxLength = 10;
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(64, 21);
            this.cbPort.TabIndex = 1;
            this.cbPort.Text = "COM45";
            // 
            // cbBaud
            // 
            this.cbBaud.FormattingEnabled = true;
            this.cbBaud.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cbBaud.Location = new System.Drawing.Point(79, 18);
            this.cbBaud.MaxLength = 10;
            this.cbBaud.Name = "cbBaud";
            this.cbBaud.Size = new System.Drawing.Size(63, 21);
            this.cbBaud.TabIndex = 2;
            this.cbBaud.Text = "115200";
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.ReadBufferSize = 2048;
            this.serialPort1.ReadTimeout = 3000;
            this.serialPort1.WriteTimeout = 3000;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // bXdown
            // 
            this.bXdown.BackColor = System.Drawing.SystemColors.Control;
            this.bXdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bXdown.Location = new System.Drawing.Point(5, 66);
            this.bXdown.Name = "bXdown";
            this.bXdown.Size = new System.Drawing.Size(44, 44);
            this.bXdown.TabIndex = 7;
            this.bXdown.Text = "X-";
            this.bXdown.UseVisualStyleBackColor = false;
            this.bXdown.Click += new System.EventHandler(this.bXdown_Click);
            // 
            // bXup
            // 
            this.bXup.BackColor = System.Drawing.SystemColors.Control;
            this.bXup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bXup.Location = new System.Drawing.Point(51, 66);
            this.bXup.Name = "bXup";
            this.bXup.Size = new System.Drawing.Size(44, 44);
            this.bXup.TabIndex = 8;
            this.bXup.Text = "X+";
            this.bXup.UseVisualStyleBackColor = false;
            this.bXup.Click += new System.EventHandler(this.bXup_Click);
            // 
            // bYup
            // 
            this.bYup.BackColor = System.Drawing.SystemColors.Control;
            this.bYup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bYup.Location = new System.Drawing.Point(29, 21);
            this.bYup.Name = "bYup";
            this.bYup.Size = new System.Drawing.Size(44, 44);
            this.bYup.TabIndex = 9;
            this.bYup.Text = "Y+";
            this.bYup.UseVisualStyleBackColor = false;
            this.bYup.Click += new System.EventHandler(this.bYup_Click);
            // 
            // bYdown
            // 
            this.bYdown.BackColor = System.Drawing.SystemColors.Control;
            this.bYdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bYdown.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bYdown.Location = new System.Drawing.Point(29, 111);
            this.bYdown.Name = "bYdown";
            this.bYdown.Size = new System.Drawing.Size(44, 44);
            this.bYdown.TabIndex = 10;
            this.bYdown.Text = "Y-";
            this.bYdown.UseVisualStyleBackColor = false;
            this.bYdown.Click += new System.EventHandler(this.bYdown_Click);
            // 
            // btnLaserOn
            // 
            this.btnLaserOn.Location = new System.Drawing.Point(6, 17);
            this.btnLaserOn.Name = "btnLaserOn";
            this.btnLaserOn.Size = new System.Drawing.Size(67, 44);
            this.btnLaserOn.TabIndex = 11;
            this.btnLaserOn.Text = "On";
            this.btnLaserOn.UseVisualStyleBackColor = true;
            this.btnLaserOn.Click += new System.EventHandler(this.btnLaserOn_Click);
            // 
            // btsLaserOff
            // 
            this.btsLaserOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btsLaserOff.Location = new System.Drawing.Point(79, 16);
            this.btsLaserOff.Name = "btsLaserOff";
            this.btsLaserOff.Size = new System.Drawing.Size(73, 72);
            this.btsLaserOff.TabIndex = 12;
            this.btsLaserOff.Text = "Off";
            this.btsLaserOff.UseVisualStyleBackColor = true;
            this.btsLaserOff.Click += new System.EventHandler(this.btsLaserOff_Click);
            // 
            // btnCustom1
            // 
            this.btnCustom1.Location = new System.Drawing.Point(6, 19);
            this.btnCustom1.Name = "btnCustom1";
            this.btnCustom1.Size = new System.Drawing.Size(97, 23);
            this.btnCustom1.TabIndex = 14;
            this.btnCustom1.Text = "Custom1";
            this.btnCustom1.UseVisualStyleBackColor = true;
            this.btnCustom1.Click += new System.EventHandler(this.btnCustom1_Click);
            // 
            // btnUnlock
            // 
            this.btnUnlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnlock.Location = new System.Drawing.Point(105, 17);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(48, 45);
            this.btnUnlock.TabIndex = 16;
            this.btnUnlock.Text = "Unlock";
            this.btnUnlock.UseVisualStyleBackColor = true;
            this.btnUnlock.Click += new System.EventHandler(this.button11_Click);
            // 
            // tbFile
            // 
            this.tbFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFile.Location = new System.Drawing.Point(7, 15);
            this.tbFile.Name = "tbFile";
            this.tbFile.Size = new System.Drawing.Size(203, 20);
            this.tbFile.TabIndex = 20;
            // 
            // bOpenfile
            // 
            this.bOpenfile.Location = new System.Drawing.Point(214, 13);
            this.bOpenfile.Name = "bOpenfile";
            this.bOpenfile.Size = new System.Drawing.Size(30, 23);
            this.bOpenfile.TabIndex = 43;
            this.bOpenfile.Text = "...";
            this.bOpenfile.Click += new System.EventHandler(this.bOpenfile_Click);
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(7, 42);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(75, 23);
            this.bStart.TabIndex = 23;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStar_Click);
            // 
            // bSendCmd
            // 
            this.bSendCmd.Location = new System.Drawing.Point(334, 133);
            this.bSendCmd.Name = "bSendCmd";
            this.bSendCmd.Size = new System.Drawing.Size(44, 23);
            this.bSendCmd.TabIndex = 28;
            this.bSendCmd.Text = "Send";
            this.bSendCmd.UseVisualStyleBackColor = true;
            this.bSendCmd.Click += new System.EventHandler(this.bSendCmd_Click);
            // 
            // bHome
            // 
            this.bHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bHome.Location = new System.Drawing.Point(5, 17);
            this.bHome.Name = "bHome";
            this.bHome.Size = new System.Drawing.Size(48, 45);
            this.bHome.TabIndex = 30;
            this.bHome.Text = "GoHome";
            this.bHome.UseVisualStyleBackColor = true;
            this.bHome.Click += new System.EventHandler(this.bHome_Click);
            // 
            // tbStepSize
            // 
            this.tbStepSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbStepSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStepSize.Location = new System.Drawing.Point(98, 125);
            this.tbStepSize.MaxLength = 3;
            this.tbStepSize.Name = "tbStepSize";
            this.tbStepSize.Size = new System.Drawing.Size(40, 23);
            this.tbStepSize.TabIndex = 31;
            this.tbStepSize.Text = "1";
            this.tbStepSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pbFile
            // 
            this.pbFile.Location = new System.Drawing.Point(7, 87);
            this.pbFile.Name = "pbFile";
            this.pbFile.Size = new System.Drawing.Size(237, 20);
            this.pbFile.Step = 1;
            this.pbFile.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbFile.TabIndex = 40;
            // 
            // pbBufer
            // 
            this.pbBufer.BackColor = System.Drawing.SystemColors.Control;
            this.pbBufer.Location = new System.Drawing.Point(115, 49);
            this.pbBufer.Name = "pbBufer";
            this.pbBufer.Size = new System.Drawing.Size(105, 8);
            this.pbBufer.Step = 1;
            this.pbBufer.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbBufer.TabIndex = 41;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(90, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "Buf:";
            // 
            // btnCustom2
            // 
            this.btnCustom2.Location = new System.Drawing.Point(110, 19);
            this.btnCustom2.Name = "btnCustom2";
            this.btnCustom2.Size = new System.Drawing.Size(97, 23);
            this.btnCustom2.TabIndex = 44;
            this.btnCustom2.Text = "Custom2";
            this.btnCustom2.UseVisualStyleBackColor = true;
            this.btnCustom2.Click += new System.EventHandler(this.btnCustom2_Click);
            // 
            // tbCustom1
            // 
            this.tbCustom1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCustom1.Location = new System.Drawing.Point(6, 48);
            this.tbCustom1.MaxLength = 79;
            this.tbCustom1.Name = "tbCustom1";
            this.tbCustom1.Size = new System.Drawing.Size(97, 20);
            this.tbCustom1.TabIndex = 45;
            this.tbCustom1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCustom1_KeyPress);
            // 
            // tbCustom2
            // 
            this.tbCustom2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCustom2.Location = new System.Drawing.Point(110, 48);
            this.tbCustom2.MaxLength = 79;
            this.tbCustom2.Name = "tbCustom2";
            this.tbCustom2.Size = new System.Drawing.Size(97, 20);
            this.tbCustom2.TabIndex = 46;
            this.tbCustom2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCustom2_KeyPress);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Red;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Yellow;
            this.btnReset.Location = new System.Drawing.Point(395, 281);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(214, 81);
            this.btnReset.TabIndex = 47;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.button5_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(145, 15);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(35, 20);
            this.button12.TabIndex = 48;
            this.button12.Text = ".01";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(145, 41);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(35, 20);
            this.button19.TabIndex = 49;
            this.button19.Text = ".1";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(145, 66);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(35, 20);
            this.button20.TabIndex = 50;
            this.button20.Text = "1";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(145, 117);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(35, 20);
            this.button21.TabIndex = 51;
            this.button21.Text = "10";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(145, 142);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(35, 20);
            this.button22.TabIndex = 52;
            this.button22.Text = "100";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // gbJog
            // 
            this.gbJog.BackColor = System.Drawing.SystemColors.Control;
            this.gbJog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gbJog.Controls.Add(this.btnZdown);
            this.gbJog.Controls.Add(this.btnZup);
            this.gbJog.Controls.Add(this.button1);
            this.gbJog.Controls.Add(this.button22);
            this.gbJog.Controls.Add(this.button21);
            this.gbJog.Controls.Add(this.button20);
            this.gbJog.Controls.Add(this.button19);
            this.gbJog.Controls.Add(this.button12);
            this.gbJog.Controls.Add(this.tbStepSize);
            this.gbJog.Controls.Add(this.bYdown);
            this.gbJog.Controls.Add(this.bYup);
            this.gbJog.Controls.Add(this.bXup);
            this.gbJog.Controls.Add(this.bXdown);
            this.gbJog.Location = new System.Drawing.Point(261, 28);
            this.gbJog.Name = "gbJog";
            this.gbJog.Size = new System.Drawing.Size(186, 171);
            this.gbJog.TabIndex = 53;
            this.gbJog.TabStop = false;
            this.gbJog.Text = "Motion";
            // 
            // btnZdown
            // 
            this.btnZdown.BackColor = System.Drawing.SystemColors.Control;
            this.btnZdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZdown.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnZdown.Location = new System.Drawing.Point(99, 67);
            this.btnZdown.Name = "btnZdown";
            this.btnZdown.Size = new System.Drawing.Size(38, 34);
            this.btnZdown.TabIndex = 55;
            this.btnZdown.Text = "Z-";
            this.btnZdown.UseVisualStyleBackColor = false;
            this.btnZdown.Click += new System.EventHandler(this.btnZdown_Click);
            // 
            // btnZup
            // 
            this.btnZup.BackColor = System.Drawing.SystemColors.Control;
            this.btnZup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZup.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnZup.Location = new System.Drawing.Point(99, 27);
            this.btnZup.Name = "btnZup";
            this.btnZup.Size = new System.Drawing.Size(38, 34);
            this.btnZup.TabIndex = 54;
            this.btnZup.Text = "Z+";
            this.btnZup.UseVisualStyleBackColor = false;
            this.btnZup.Click += new System.EventHandler(this.btnZup_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(145, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 20);
            this.button1.TabIndex = 53;
            this.button1.Text = "5";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblBuf);
            this.groupBox2.Controls.Add(this.lblElapsed);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblFileProgress);
            this.groupBox2.Controls.Add(this.pbFile);
            this.groupBox2.Controls.Add(this.bStart);
            this.groupBox2.Controls.Add(this.bOpenfile);
            this.groupBox2.Controls.Add(this.tbFile);
            this.groupBox2.Controls.Add(this.pbBufer);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(4, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 113);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File";
            // 
            // lblBuf
            // 
            this.lblBuf.AutoSize = true;
            this.lblBuf.Location = new System.Drawing.Point(221, 46);
            this.lblBuf.Name = "lblBuf";
            this.lblBuf.Size = new System.Drawing.Size(25, 13);
            this.lblBuf.TabIndex = 47;
            this.lblBuf.Text = "000";
            // 
            // lblElapsed
            // 
            this.lblElapsed.AutoSize = true;
            this.lblElapsed.Location = new System.Drawing.Point(197, 70);
            this.lblElapsed.Name = "lblElapsed";
            this.lblElapsed.Size = new System.Drawing.Size(49, 13);
            this.lblElapsed.TabIndex = 45;
            this.lblElapsed.Text = "00:00:00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(152, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "Elapsed:";
            // 
            // lblFileProgress
            // 
            this.lblFileProgress.AutoSize = true;
            this.lblFileProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblFileProgress.Location = new System.Drawing.Point(8, 70);
            this.lblFileProgress.Name = "lblFileProgress";
            this.lblFileProgress.Size = new System.Drawing.Size(60, 13);
            this.lblFileProgress.TabIndex = 44;
            this.lblFileProgress.Text = "0% (0 lines)";
            // 
            // tbLaserPwr
            // 
            this.tbLaserPwr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLaserPwr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLaserPwr.Location = new System.Drawing.Point(43, 65);
            this.tbLaserPwr.MaxLength = 4;
            this.tbLaserPwr.Name = "tbLaserPwr";
            this.tbLaserPwr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLaserPwr.Size = new System.Drawing.Size(33, 23);
            this.tbLaserPwr.TabIndex = 55;
            this.tbLaserPwr.Text = "0";
            this.tbLaserPwr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "G-Code Files(*.CNC;*.NC;*.TAP;*.TXT)|*.CNC;*.NC;*.TAP;*.TXT|All files (*.*)|*.*";
            // 
            // tmrUpdates
            // 
            this.tmrUpdates.Enabled = true;
            this.tmrUpdates.Interval = 500;
            this.tmrUpdates.Tick += new System.EventHandler(this.tmrUpdates_Tick);
            // 
            // gbConecction
            // 
            this.gbConecction.Controls.Add(this.bRefreshport);
            this.gbConecction.Controls.Add(this.cbBaud);
            this.gbConecction.Controls.Add(this.cbPort);
            this.gbConecction.Controls.Add(this.bOpenPort);
            this.gbConecction.Location = new System.Drawing.Point(3, 28);
            this.gbConecction.Name = "gbConecction";
            this.gbConecction.Size = new System.Drawing.Size(252, 50);
            this.gbConecction.TabIndex = 58;
            this.gbConecction.TabStop = false;
            this.gbConecction.Text = "Connection";
            // 
            // bRefreshport
            // 
            this.bRefreshport.BackgroundImage = global::_3dpBurner.Properties.Resources.refresh;
            this.bRefreshport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bRefreshport.Location = new System.Drawing.Point(217, 17);
            this.bRefreshport.Name = "bRefreshport";
            this.bRefreshport.Size = new System.Drawing.Size(25, 23);
            this.bRefreshport.TabIndex = 56;
            this.bRefreshport.UseVisualStyleBackColor = true;
            this.bRefreshport.Click += new System.EventHandler(this.bRefreshport_Click);
            // 
            // gbLaserControl
            // 
            this.gbLaserControl.Controls.Add(this.btnLaserPwr);
            this.gbLaserControl.Controls.Add(this.tbLaserPwr);
            this.gbLaserControl.Controls.Add(this.btsLaserOff);
            this.gbLaserControl.Controls.Add(this.btnLaserOn);
            this.gbLaserControl.Location = new System.Drawing.Point(453, 28);
            this.gbLaserControl.Name = "gbLaserControl";
            this.gbLaserControl.Size = new System.Drawing.Size(158, 96);
            this.gbLaserControl.TabIndex = 59;
            this.gbLaserControl.TabStop = false;
            this.gbLaserControl.Text = "Laser";
            // 
            // btnLaserPwr
            // 
            this.btnLaserPwr.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaserPwr.Location = new System.Drawing.Point(4, 63);
            this.btnLaserPwr.Name = "btnLaserPwr";
            this.btnLaserPwr.Size = new System.Drawing.Size(38, 27);
            this.btnLaserPwr.TabIndex = 56;
            this.btnLaserPwr.Text = "PWR";
            this.btnLaserPwr.UseVisualStyleBackColor = true;
            this.btnLaserPwr.Click += new System.EventHandler(this.btnLaserPwr_Click);
            // 
            // tbCommand
            // 
            this.tbCommand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCommand.Location = new System.Drawing.Point(78, 135);
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.Size = new System.Drawing.Size(254, 20);
            this.tbCommand.TabIndex = 27;
            this.tbCommand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCommand_KeyPress);
            // 
            // gbConsole
            // 
            this.gbConsole.Controls.Add(this.panel1);
            this.gbConsole.Controls.Add(this.btlClearLog);
            this.gbConsole.Controls.Add(this.bSendCmd);
            this.gbConsole.Controls.Add(this.tbCommand);
            this.gbConsole.Location = new System.Drawing.Point(3, 204);
            this.gbConsole.Name = "gbConsole";
            this.gbConsole.Size = new System.Drawing.Size(386, 163);
            this.gbConsole.TabIndex = 60;
            this.gbConsole.TabStop = false;
            this.gbConsole.Text = "Console";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.rtbLog);
            this.panel1.Location = new System.Drawing.Point(7, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 112);
            this.panel1.TabIndex = 30;
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.SystemColors.Window;
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLog.DetectUrls = false;
            this.rtbLog.Location = new System.Drawing.Point(1, 1);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rtbLog.Size = new System.Drawing.Size(369, 110);
            this.rtbLog.TabIndex = 4;
            this.rtbLog.Text = "";
            this.rtbLog.WordWrap = false;
            // 
            // btlClearLog
            // 
            this.btlClearLog.Location = new System.Drawing.Point(6, 133);
            this.btlClearLog.Name = "btlClearLog";
            this.btlClearLog.Size = new System.Drawing.Size(66, 24);
            this.btlClearLog.TabIndex = 29;
            this.btlClearLog.Text = "ClearLog";
            this.btlClearLog.UseVisualStyleBackColor = true;
            this.btlClearLog.Click += new System.EventHandler(this.btlClearLog_Click);
            // 
            // gbReference
            // 
            this.gbReference.Controls.Add(this.btnZeroZ);
            this.gbReference.Controls.Add(this.btnZeroXY);
            this.gbReference.Controls.Add(this.btnZero);
            this.gbReference.Controls.Add(this.bHome);
            this.gbReference.Controls.Add(this.btnUnlock);
            this.gbReference.Location = new System.Drawing.Point(452, 130);
            this.gbReference.Name = "gbReference";
            this.gbReference.Size = new System.Drawing.Size(158, 69);
            this.gbReference.TabIndex = 61;
            this.gbReference.TabStop = false;
            this.gbReference.Text = "Reference";
            // 
            // btnZeroZ
            // 
            this.btnZeroZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroZ.Location = new System.Drawing.Point(53, 42);
            this.btnZeroZ.Name = "btnZeroZ";
            this.btnZeroZ.Size = new System.Drawing.Size(52, 20);
            this.btnZeroZ.TabIndex = 33;
            this.btnZeroZ.Text = "ZeroZ";
            this.btnZeroZ.UseVisualStyleBackColor = true;
            this.btnZeroZ.Click += new System.EventHandler(this.btnZeroZ_Click);
            // 
            // btnZeroXY
            // 
            this.btnZeroXY.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroXY.Location = new System.Drawing.Point(53, 17);
            this.btnZeroXY.Name = "btnZeroXY";
            this.btnZeroXY.Size = new System.Drawing.Size(52, 25);
            this.btnZeroXY.TabIndex = 32;
            this.btnZeroXY.Text = "ZeroXY";
            this.btnZeroXY.UseVisualStyleBackColor = true;
            this.btnZeroXY.Click += new System.EventHandler(this.btnZeroXY_Click);
            // 
            // btnZero
            // 
            this.btnZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZero.Location = new System.Drawing.Point(55, 17);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(48, 45);
            this.btnZero.TabIndex = 31;
            this.btnZero.Text = "Zero";
            this.btnZero.UseVisualStyleBackColor = true;
            this.btnZero.Click += new System.EventHandler(this.btnZero_Click);
            // 
            // gbCustom
            // 
            this.gbCustom.Controls.Add(this.tbCustom2);
            this.gbCustom.Controls.Add(this.tbCustom1);
            this.gbCustom.Controls.Add(this.btnCustom2);
            this.gbCustom.Controls.Add(this.btnCustom1);
            this.gbCustom.Location = new System.Drawing.Point(396, 204);
            this.gbCustom.Name = "gbCustom";
            this.gbCustom.Size = new System.Drawing.Size(215, 75);
            this.gbCustom.TabIndex = 62;
            this.gbCustom.TabStop = false;
            this.gbCustom.Text = "Custom";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modeToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(615, 24);
            this.menuStrip1.TabIndex = 63;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.axisMillToolStripMenuItem,
            this.axisLaserPWRSToolStripMenuItem,
            this.axisLaserPWRZToolStripMenuItem,
            this.axisLaserToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // axisMillToolStripMenuItem
            // 
            this.axisMillToolStripMenuItem.CheckOnClick = true;
            this.axisMillToolStripMenuItem.Name = "axisMillToolStripMenuItem";
            this.axisMillToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.axisMillToolStripMenuItem.Text = "3axisMill";
            this.axisMillToolStripMenuItem.Click += new System.EventHandler(this.axisMillToolStripMenuItem_Click);
            // 
            // axisLaserPWRSToolStripMenuItem
            // 
            this.axisLaserPWRSToolStripMenuItem.Checked = true;
            this.axisLaserPWRSToolStripMenuItem.CheckOnClick = true;
            this.axisLaserPWRSToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.axisLaserPWRSToolStripMenuItem.Name = "axisLaserPWRSToolStripMenuItem";
            this.axisLaserPWRSToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.axisLaserPWRSToolStripMenuItem.Text = "2axisLaserPWR_S";
            this.axisLaserPWRSToolStripMenuItem.Click += new System.EventHandler(this.axisLaserPWRSToolStripMenuItem_Click);
            // 
            // axisLaserPWRZToolStripMenuItem
            // 
            this.axisLaserPWRZToolStripMenuItem.CheckOnClick = true;
            this.axisLaserPWRZToolStripMenuItem.Name = "axisLaserPWRZToolStripMenuItem";
            this.axisLaserPWRZToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.axisLaserPWRZToolStripMenuItem.Text = "2axisLaserPWR_Z";
            this.axisLaserPWRZToolStripMenuItem.Click += new System.EventHandler(this.axisLaserPWRZToolStripMenuItem_Click);
            // 
            // axisLaserToolStripMenuItem
            // 
            this.axisLaserToolStripMenuItem.CheckOnClick = true;
            this.axisLaserToolStripMenuItem.Name = "axisLaserToolStripMenuItem";
            this.axisLaserToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.axisLaserToolStripMenuItem.Text = "3axisLaser";
            this.axisLaserToolStripMenuItem.Click += new System.EventHandler(this.axisLaserToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreSettingsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // restoreSettingsToolStripMenuItem
            // 
            this.restoreSettingsToolStripMenuItem.Name = "restoreSettingsToolStripMenuItem";
            this.restoreSettingsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.restoreSettingsToolStripMenuItem.Text = "Restore Settings";
            this.restoreSettingsToolStripMenuItem.Click += new System.EventHandler(this.restoreSettingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 363);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(615, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 64;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel2.Text = "Status:";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(28, 17);
            this.toolStripStatusLabel1.Text = "       ";
            // 
            // frm3dpBurner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(615, 385);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gbCustom);
            this.Controls.Add(this.gbReference);
            this.Controls.Add(this.gbConsole);
            this.Controls.Add(this.gbLaserControl);
            this.Controls.Add(this.gbConecction);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbJog);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm3dpBurner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3dpBurner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm3dpBurner_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbJog.ResumeLayout(false);
            this.gbJog.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbConecction.ResumeLayout(false);
            this.gbLaserControl.ResumeLayout(false);
            this.gbLaserControl.PerformLayout();
            this.gbConsole.ResumeLayout(false);
            this.gbConsole.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.gbReference.ResumeLayout(false);
            this.gbCustom.ResumeLayout(false);
            this.gbCustom.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bOpenPort;
        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.ComboBox cbBaud;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button bXdown;
        private System.Windows.Forms.Button bXup;
        private System.Windows.Forms.Button bYup;
        private System.Windows.Forms.Button bYdown;
        private System.Windows.Forms.Button btnLaserOn;
        private System.Windows.Forms.Button btsLaserOff;
        private System.Windows.Forms.Button btnCustom1;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.Button bOpenfile;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Button bSendCmd;
        private System.Windows.Forms.Button bHome;
        private System.Windows.Forms.TextBox tbStepSize;
        private System.Windows.Forms.ProgressBar pbFile;
        private System.Windows.Forms.ProgressBar pbBufer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCustom2;
        private System.Windows.Forms.TextBox tbCustom1;
        private System.Windows.Forms.TextBox tbCustom2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.GroupBox gbJog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbLaserPwr;
        private System.Windows.Forms.Button bRefreshport;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblFileProgress;
        private System.Windows.Forms.Label lblElapsed;
        private System.Windows.Forms.Timer tmrUpdates;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbConecction;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gbLaserControl;
        private System.Windows.Forms.TextBox tbCommand;
        private System.Windows.Forms.GroupBox gbConsole;
        private System.Windows.Forms.GroupBox gbReference;
        private System.Windows.Forms.GroupBox gbCustom;
        private System.Windows.Forms.Button btnLaserPwr;
        private System.Windows.Forms.Button btlClearLog;
        private System.Windows.Forms.Button btnZero;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Label lblBuf;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem axisMillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem axisLaserPWRSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem axisLaserPWRZToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem axisLaserToolStripMenuItem;
        private System.Windows.Forms.Button btnZdown;
        private System.Windows.Forms.Button btnZup;
        private System.Windows.Forms.Button btnZeroZ;
        private System.Windows.Forms.Button btnZeroXY;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}

