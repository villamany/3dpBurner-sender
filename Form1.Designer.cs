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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnLaserOn = new System.Windows.Forms.Button();
            this.btsLaserOff = new System.Windows.Forms.Button();
            this.btnCustom1 = new System.Windows.Forms.Button();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.bOpenfile = new System.Windows.Forms.Button();
            this.bSendCmd = new System.Windows.Forms.Button();
            this.bHome = new System.Windows.Forms.Button();
            this.tbStepSize = new System.Windows.Forms.TextBox();
            this.pbFile = new System.Windows.Forms.ProgressBar();
            this.btnCustom2 = new System.Windows.Forms.Button();
            this.tbCustom1 = new System.Windows.Forms.TextBox();
            this.tbCustom2 = new System.Windows.Forms.TextBox();
            this.button12 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.gbJog = new System.Windows.Forms.GroupBox();
            this.bYdown = new System.Windows.Forms.Button();
            this.bXup = new System.Windows.Forms.Button();
            this.bXdown = new System.Windows.Forms.Button();
            this.bYup = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFileStart = new System.Windows.Forms.Button();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblElapsed = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblFileProgress = new System.Windows.Forms.Label();
            this.tbLaserPwr = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tmrUpdates = new System.Windows.Forms.Timer(this.components);
            this.gbConecction = new System.Windows.Forms.GroupBox();
            this.btnPortsInfo = new System.Windows.Forms.Button();
            this.gbLaserControl = new System.Windows.Forms.GroupBox();
            this.btnLaserPwr = new System.Windows.Forms.Button();
            this.tbCommand = new System.Windows.Forms.TextBox();
            this.gbConsole = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btlClearLog = new System.Windows.Forms.Button();
            this.gbReference = new System.Windows.Forms.GroupBox();
            this.btnGotoXoYo = new System.Windows.Forms.Button();
            this.btnZero = new System.Windows.Forms.Button();
            this.gbCustom = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.view3dpBurnerSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendConfigurationFileTo3dpBurnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.restoreSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrControlsUpdate = new System.Windows.Forms.Timer(this.components);
            this.bStart = new System.Windows.Forms.Button();
            this.bPause = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.panel19 = new System.Windows.Forms.Panel();
            this.btnUnlock = new System.Windows.Forms.Button();
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
            this.panel5.SuspendLayout();
            this.panel19.SuspendLayout();
            this.SuspendLayout();
            // 
            // bOpenPort
            // 
            this.bOpenPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(196)))), ((int)(((byte)(23)))));
            this.bOpenPort.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bOpenPort.FlatAppearance.BorderSize = 3;
            this.bOpenPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bOpenPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bOpenPort.Location = new System.Drawing.Point(93, 16);
            this.bOpenPort.Name = "bOpenPort";
            this.bOpenPort.Size = new System.Drawing.Size(109, 31);
            this.bOpenPort.TabIndex = 2;
            this.bOpenPort.Text = "Connect";
            this.bOpenPort.UseVisualStyleBackColor = false;
            this.bOpenPort.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbPort
            // 
            this.cbPort.BackColor = System.Drawing.Color.Snow;
            this.cbPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(9, 22);
            this.cbPort.MaxLength = 10;
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(75, 21);
            this.cbPort.TabIndex = 1;
            this.cbPort.Text = "COM1";
            this.cbPort.DropDown += new System.EventHandler(this.cbPort_DropDown);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.ReadBufferSize = 2048;
            this.serialPort1.ReadTimeout = 500;
            this.serialPort1.WriteTimeout = 3000;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // btnLaserOn
            // 
            this.btnLaserOn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(137)))), ((int)(((byte)(255)))));
            this.btnLaserOn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLaserOn.FlatAppearance.BorderSize = 3;
            this.btnLaserOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLaserOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaserOn.ForeColor = System.Drawing.Color.White;
            this.btnLaserOn.Location = new System.Drawing.Point(6, 16);
            this.btnLaserOn.Name = "btnLaserOn";
            this.btnLaserOn.Size = new System.Drawing.Size(88, 49);
            this.btnLaserOn.TabIndex = 1;
            this.btnLaserOn.Text = "On";
            this.btnLaserOn.UseVisualStyleBackColor = false;
            this.btnLaserOn.Click += new System.EventHandler(this.btnLaserOn_Click);
            // 
            // btsLaserOff
            // 
            this.btsLaserOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(137)))), ((int)(((byte)(255)))));
            this.btsLaserOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btsLaserOff.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btsLaserOff.FlatAppearance.BorderSize = 3;
            this.btsLaserOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btsLaserOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btsLaserOff.ForeColor = System.Drawing.Color.White;
            this.btsLaserOff.Location = new System.Drawing.Point(101, 16);
            this.btsLaserOff.Name = "btsLaserOff";
            this.btsLaserOff.Size = new System.Drawing.Size(86, 85);
            this.btsLaserOff.TabIndex = 2;
            this.btsLaserOff.Text = "Off";
            this.btsLaserOff.UseVisualStyleBackColor = false;
            this.btsLaserOff.Click += new System.EventHandler(this.btsLaserOff_Click);
            // 
            // btnCustom1
            // 
            this.btnCustom1.BackColor = System.Drawing.Color.Black;
            this.btnCustom1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCustom1.FlatAppearance.BorderSize = 0;
            this.btnCustom1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustom1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustom1.ForeColor = System.Drawing.Color.White;
            this.btnCustom1.Location = new System.Drawing.Point(8, 17);
            this.btnCustom1.Name = "btnCustom1";
            this.btnCustom1.Size = new System.Drawing.Size(90, 28);
            this.btnCustom1.TabIndex = 1;
            this.btnCustom1.Text = "Custom1";
            this.btnCustom1.UseVisualStyleBackColor = false;
            this.btnCustom1.Click += new System.EventHandler(this.btnCustom1_Click);
            // 
            // tbFile
            // 
            this.tbFile.BackColor = System.Drawing.Color.Snow;
            this.tbFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFile.Location = new System.Drawing.Point(7, 17);
            this.tbFile.Name = "tbFile";
            this.tbFile.Size = new System.Drawing.Size(237, 20);
            this.tbFile.TabIndex = 1;
            // 
            // bOpenfile
            // 
            this.bOpenfile.BackColor = System.Drawing.Color.Gainsboro;
            this.bOpenfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bOpenfile.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.bOpenfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bOpenfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bOpenfile.Location = new System.Drawing.Point(200, 44);
            this.bOpenfile.Name = "bOpenfile";
            this.bOpenfile.Size = new System.Drawing.Size(42, 28);
            this.bOpenfile.TabIndex = 3;
            this.bOpenfile.Text = "...";
            this.bOpenfile.UseVisualStyleBackColor = false;
            this.bOpenfile.Click += new System.EventHandler(this.bOpenfile_Click);
            // 
            // bSendCmd
            // 
            this.bSendCmd.BackColor = System.Drawing.Color.Gainsboro;
            this.bSendCmd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bSendCmd.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.bSendCmd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSendCmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSendCmd.Location = new System.Drawing.Point(612, 119);
            this.bSendCmd.Name = "bSendCmd";
            this.bSendCmd.Size = new System.Drawing.Size(54, 27);
            this.bSendCmd.TabIndex = 4;
            this.bSendCmd.Text = "Send";
            this.bSendCmd.UseVisualStyleBackColor = false;
            this.bSendCmd.Click += new System.EventHandler(this.bSendCmd_Click);
            // 
            // bHome
            // 
            this.bHome.BackColor = System.Drawing.Color.DarkOrange;
            this.bHome.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bHome.FlatAppearance.BorderSize = 3;
            this.bHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bHome.Location = new System.Drawing.Point(130, 20);
            this.bHome.Name = "bHome";
            this.bHome.Size = new System.Drawing.Size(58, 47);
            this.bHome.TabIndex = 3;
            this.bHome.Text = "Homing";
            this.bHome.UseVisualStyleBackColor = false;
            this.bHome.Click += new System.EventHandler(this.bHome_Click);
            // 
            // tbStepSize
            // 
            this.tbStepSize.BackColor = System.Drawing.Color.Snow;
            this.tbStepSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbStepSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStepSize.Location = new System.Drawing.Point(62, 87);
            this.tbStepSize.MaxLength = 3;
            this.tbStepSize.Name = "tbStepSize";
            this.tbStepSize.Size = new System.Drawing.Size(40, 22);
            this.tbStepSize.TabIndex = 5;
            this.tbStepSize.Text = "1";
            this.tbStepSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pbFile
            // 
            this.pbFile.BackColor = System.Drawing.Color.White;
            this.pbFile.Location = new System.Drawing.Point(8, 113);
            this.pbFile.Name = "pbFile";
            this.pbFile.Size = new System.Drawing.Size(190, 14);
            this.pbFile.Step = 1;
            this.pbFile.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbFile.TabIndex = 40;
            // 
            // btnCustom2
            // 
            this.btnCustom2.BackColor = System.Drawing.Color.Black;
            this.btnCustom2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCustom2.FlatAppearance.BorderSize = 0;
            this.btnCustom2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustom2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustom2.ForeColor = System.Drawing.Color.White;
            this.btnCustom2.Location = new System.Drawing.Point(345, 17);
            this.btnCustom2.Name = "btnCustom2";
            this.btnCustom2.Size = new System.Drawing.Size(90, 28);
            this.btnCustom2.TabIndex = 3;
            this.btnCustom2.Text = "Custom2";
            this.btnCustom2.UseVisualStyleBackColor = false;
            this.btnCustom2.Click += new System.EventHandler(this.btnCustom2_Click);
            // 
            // tbCustom1
            // 
            this.tbCustom1.BackColor = System.Drawing.Color.Snow;
            this.tbCustom1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCustom1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCustom1.Location = new System.Drawing.Point(103, 20);
            this.tbCustom1.MaxLength = 79;
            this.tbCustom1.Name = "tbCustom1";
            this.tbCustom1.Size = new System.Drawing.Size(223, 20);
            this.tbCustom1.TabIndex = 2;
            this.tbCustom1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCustom1_KeyPress);
            // 
            // tbCustom2
            // 
            this.tbCustom2.BackColor = System.Drawing.Color.Snow;
            this.tbCustom2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCustom2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCustom2.Location = new System.Drawing.Point(441, 20);
            this.tbCustom2.MaxLength = 79;
            this.tbCustom2.Name = "tbCustom2";
            this.tbCustom2.Size = new System.Drawing.Size(223, 20);
            this.tbCustom2.TabIndex = 4;
            this.tbCustom2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCustom2_KeyPress);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Gainsboro;
            this.button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button12.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Location = new System.Drawing.Point(165, 17);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(39, 25);
            this.button12.TabIndex = 6;
            this.button12.Text = ".01";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.Gainsboro;
            this.button19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button19.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Location = new System.Drawing.Point(165, 45);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(39, 25);
            this.button19.TabIndex = 7;
            this.button19.Text = ".1";
            this.button19.UseVisualStyleBackColor = false;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.Gainsboro;
            this.button20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button20.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.Location = new System.Drawing.Point(165, 73);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(39, 25);
            this.button20.TabIndex = 8;
            this.button20.Text = "1";
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.Color.Gainsboro;
            this.button21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button21.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button21.Location = new System.Drawing.Point(165, 129);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(39, 25);
            this.button21.TabIndex = 10;
            this.button21.Text = "10";
            this.button21.UseVisualStyleBackColor = false;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // button22
            // 
            this.button22.BackColor = System.Drawing.Color.Gainsboro;
            this.button22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button22.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button22.Location = new System.Drawing.Point(165, 157);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(39, 25);
            this.button22.TabIndex = 11;
            this.button22.Text = "100";
            this.button22.UseVisualStyleBackColor = false;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // gbJog
            // 
            this.gbJog.BackColor = System.Drawing.Color.White;
            this.gbJog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gbJog.Controls.Add(this.bYdown);
            this.gbJog.Controls.Add(this.bXup);
            this.gbJog.Controls.Add(this.bXdown);
            this.gbJog.Controls.Add(this.bYup);
            this.gbJog.Controls.Add(this.button1);
            this.gbJog.Controls.Add(this.button22);
            this.gbJog.Controls.Add(this.button21);
            this.gbJog.Controls.Add(this.button20);
            this.gbJog.Controls.Add(this.button19);
            this.gbJog.Controls.Add(this.button12);
            this.gbJog.Controls.Add(this.tbStepSize);
            this.gbJog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbJog.Location = new System.Drawing.Point(264, 28);
            this.gbJog.Name = "gbJog";
            this.gbJog.Size = new System.Drawing.Size(213, 195);
            this.gbJog.TabIndex = 3;
            this.gbJog.TabStop = false;
            this.gbJog.Text = "Motion";
            // 
            // bYdown
            // 
            this.bYdown.BackColor = System.Drawing.Color.DimGray;
            this.bYdown.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bYdown.FlatAppearance.BorderSize = 3;
            this.bYdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bYdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bYdown.ForeColor = System.Drawing.Color.White;
            this.bYdown.Location = new System.Drawing.Point(57, 131);
            this.bYdown.Name = "bYdown";
            this.bYdown.Size = new System.Drawing.Size(51, 51);
            this.bYdown.TabIndex = 4;
            this.bYdown.Text = "Y-";
            this.bYdown.UseVisualStyleBackColor = false;
            this.bYdown.Click += new System.EventHandler(this.bYdown_Click);
            // 
            // bXup
            // 
            this.bXup.BackColor = System.Drawing.Color.DimGray;
            this.bXup.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bXup.FlatAppearance.BorderSize = 3;
            this.bXup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bXup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bXup.ForeColor = System.Drawing.Color.White;
            this.bXup.Location = new System.Drawing.Point(108, 74);
            this.bXup.Name = "bXup";
            this.bXup.Size = new System.Drawing.Size(51, 51);
            this.bXup.TabIndex = 3;
            this.bXup.Text = "X+";
            this.bXup.UseVisualStyleBackColor = false;
            this.bXup.Click += new System.EventHandler(this.bXup_Click);
            // 
            // bXdown
            // 
            this.bXdown.BackColor = System.Drawing.Color.DimGray;
            this.bXdown.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bXdown.FlatAppearance.BorderSize = 3;
            this.bXdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bXdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bXdown.ForeColor = System.Drawing.Color.White;
            this.bXdown.Location = new System.Drawing.Point(7, 74);
            this.bXdown.Name = "bXdown";
            this.bXdown.Size = new System.Drawing.Size(51, 51);
            this.bXdown.TabIndex = 2;
            this.bXdown.Text = "X-";
            this.bXdown.UseVisualStyleBackColor = false;
            this.bXdown.Click += new System.EventHandler(this.bXdown_Click);
            // 
            // bYup
            // 
            this.bYup.BackColor = System.Drawing.Color.DimGray;
            this.bYup.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bYup.FlatAppearance.BorderSize = 3;
            this.bYup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bYup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bYup.ForeColor = System.Drawing.Color.White;
            this.bYup.Location = new System.Drawing.Point(57, 18);
            this.bYup.Name = "bYup";
            this.bYup.Size = new System.Drawing.Size(51, 51);
            this.bYup.TabIndex = 1;
            this.bYup.Text = "Y+";
            this.bYup.UseVisualStyleBackColor = false;
            this.bYup.Click += new System.EventHandler(this.bYup_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(165, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 25);
            this.button1.TabIndex = 9;
            this.button1.Text = "5";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.btnFileStart);
            this.groupBox2.Controls.Add(this.lblRemaining);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblElapsed);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblFileProgress);
            this.groupBox2.Controls.Add(this.pbFile);
            this.groupBox2.Controls.Add(this.bOpenfile);
            this.groupBox2.Controls.Add(this.tbFile);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(5, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 134);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File";
            // 
            // btnFileStart
            // 
            this.btnFileStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(196)))), ((int)(((byte)(23)))));
            this.btnFileStart.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnFileStart.FlatAppearance.BorderSize = 3;
            this.btnFileStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFileStart.Location = new System.Drawing.Point(7, 44);
            this.btnFileStart.Name = "btnFileStart";
            this.btnFileStart.Size = new System.Drawing.Size(188, 29);
            this.btnFileStart.TabIndex = 2;
            this.btnFileStart.Text = "Send File";
            this.btnFileStart.UseVisualStyleBackColor = false;
            this.btnFileStart.Click += new System.EventHandler(this.btnFileStart_Click);
            // 
            // lblRemaining
            // 
            this.lblRemaining.AutoSize = true;
            this.lblRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemaining.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblRemaining.Location = new System.Drawing.Point(144, 92);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.Size = new System.Drawing.Size(72, 17);
            this.lblRemaining.TabIndex = 49;
            this.lblRemaining.Text = "00:00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(150, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Remaining:";
            // 
            // lblElapsed
            // 
            this.lblElapsed.AutoSize = true;
            this.lblElapsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElapsed.ForeColor = System.Drawing.Color.Blue;
            this.lblElapsed.Location = new System.Drawing.Point(32, 92);
            this.lblElapsed.Name = "lblElapsed";
            this.lblElapsed.Size = new System.Drawing.Size(72, 17);
            this.lblElapsed.TabIndex = 45;
            this.lblElapsed.Text = "00:00:00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(44, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "Elapsed:";
            // 
            // lblFileProgress
            // 
            this.lblFileProgress.AutoSize = true;
            this.lblFileProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblFileProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileProgress.Location = new System.Drawing.Point(205, 110);
            this.lblFileProgress.Name = "lblFileProgress";
            this.lblFileProgress.Size = new System.Drawing.Size(48, 17);
            this.lblFileProgress.TabIndex = 44;
            this.lblFileProgress.Text = "100%";
            // 
            // tbLaserPwr
            // 
            this.tbLaserPwr.BackColor = System.Drawing.Color.Snow;
            this.tbLaserPwr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLaserPwr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLaserPwr.Location = new System.Drawing.Point(58, 75);
            this.tbLaserPwr.MaxLength = 4;
            this.tbLaserPwr.Name = "tbLaserPwr";
            this.tbLaserPwr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLaserPwr.Size = new System.Drawing.Size(37, 22);
            this.tbLaserPwr.TabIndex = 4;
            this.tbLaserPwr.Text = "0";
            this.tbLaserPwr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbLaserPwr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLaserPwr_KeyPress);
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
            this.gbConecction.Controls.Add(this.btnPortsInfo);
            this.gbConecction.Controls.Add(this.cbPort);
            this.gbConecction.Controls.Add(this.bOpenPort);
            this.gbConecction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbConecction.Location = new System.Drawing.Point(5, 28);
            this.gbConecction.Name = "gbConecction";
            this.gbConecction.Size = new System.Drawing.Size(252, 56);
            this.gbConecction.TabIndex = 1;
            this.gbConecction.TabStop = false;
            this.gbConecction.Text = "Connection";
            // 
            // btnPortsInfo
            // 
            this.btnPortsInfo.BackColor = System.Drawing.Color.Gainsboro;
            this.btnPortsInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPortsInfo.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnPortsInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPortsInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPortsInfo.Location = new System.Drawing.Point(212, 18);
            this.btnPortsInfo.Name = "btnPortsInfo";
            this.btnPortsInfo.Size = new System.Drawing.Size(27, 27);
            this.btnPortsInfo.TabIndex = 3;
            this.btnPortsInfo.Text = "i";
            this.btnPortsInfo.UseVisualStyleBackColor = false;
            this.btnPortsInfo.Click += new System.EventHandler(this.btnPortsInfo_Click);
            // 
            // gbLaserControl
            // 
            this.gbLaserControl.Controls.Add(this.btnLaserPwr);
            this.gbLaserControl.Controls.Add(this.tbLaserPwr);
            this.gbLaserControl.Controls.Add(this.btsLaserOff);
            this.gbLaserControl.Controls.Add(this.btnLaserOn);
            this.gbLaserControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLaserControl.Location = new System.Drawing.Point(485, 28);
            this.gbLaserControl.Name = "gbLaserControl";
            this.gbLaserControl.Size = new System.Drawing.Size(193, 110);
            this.gbLaserControl.TabIndex = 4;
            this.gbLaserControl.TabStop = false;
            this.gbLaserControl.Text = "Laser";
            // 
            // btnLaserPwr
            // 
            this.btnLaserPwr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(137)))), ((int)(((byte)(255)))));
            this.btnLaserPwr.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLaserPwr.FlatAppearance.BorderSize = 3;
            this.btnLaserPwr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLaserPwr.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaserPwr.ForeColor = System.Drawing.Color.White;
            this.btnLaserPwr.Location = new System.Drawing.Point(6, 72);
            this.btnLaserPwr.Name = "btnLaserPwr";
            this.btnLaserPwr.Size = new System.Drawing.Size(46, 30);
            this.btnLaserPwr.TabIndex = 3;
            this.btnLaserPwr.Text = "PWR";
            this.btnLaserPwr.UseVisualStyleBackColor = false;
            this.btnLaserPwr.Click += new System.EventHandler(this.btnLaserPwr_Click);
            // 
            // tbCommand
            // 
            this.tbCommand.BackColor = System.Drawing.Color.Snow;
            this.tbCommand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCommand.Location = new System.Drawing.Point(86, 122);
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.Size = new System.Drawing.Size(521, 20);
            this.tbCommand.TabIndex = 3;
            this.tbCommand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCommand_KeyPress);
            // 
            // gbConsole
            // 
            this.gbConsole.Controls.Add(this.panel1);
            this.gbConsole.Controls.Add(this.btlClearLog);
            this.gbConsole.Controls.Add(this.bSendCmd);
            this.gbConsole.Controls.Add(this.tbCommand);
            this.gbConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbConsole.Location = new System.Drawing.Point(5, 381);
            this.gbConsole.Name = "gbConsole";
            this.gbConsole.Size = new System.Drawing.Size(672, 154);
            this.gbConsole.TabIndex = 9;
            this.gbConsole.TabStop = false;
            this.gbConsole.Text = "Console";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.rtbLog);
            this.panel1.Location = new System.Drawing.Point(7, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(657, 97);
            this.panel1.TabIndex = 30;
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.SystemColors.Window;
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLog.DetectUrls = false;
            this.rtbLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLog.Location = new System.Drawing.Point(1, 1);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rtbLog.Size = new System.Drawing.Size(655, 95);
            this.rtbLog.TabIndex = 1;
            this.rtbLog.Text = "";
            this.rtbLog.WordWrap = false;
            // 
            // btlClearLog
            // 
            this.btlClearLog.BackColor = System.Drawing.Color.Gainsboro;
            this.btlClearLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btlClearLog.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btlClearLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btlClearLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btlClearLog.Location = new System.Drawing.Point(6, 119);
            this.btlClearLog.Name = "btlClearLog";
            this.btlClearLog.Size = new System.Drawing.Size(74, 28);
            this.btlClearLog.TabIndex = 2;
            this.btlClearLog.Text = "ClearLog";
            this.btlClearLog.UseVisualStyleBackColor = false;
            this.btlClearLog.Click += new System.EventHandler(this.btlClearLog_Click);
            // 
            // gbReference
            // 
            this.gbReference.Controls.Add(this.btnGotoXoYo);
            this.gbReference.Controls.Add(this.btnZero);
            this.gbReference.Controls.Add(this.bHome);
            this.gbReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbReference.Location = new System.Drawing.Point(485, 145);
            this.gbReference.Name = "gbReference";
            this.gbReference.Size = new System.Drawing.Size(193, 78);
            this.gbReference.TabIndex = 5;
            this.gbReference.TabStop = false;
            this.gbReference.Text = "Reference";
            // 
            // btnGotoXoYo
            // 
            this.btnGotoXoYo.BackColor = System.Drawing.Color.DarkOrange;
            this.btnGotoXoYo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGotoXoYo.FlatAppearance.BorderSize = 3;
            this.btnGotoXoYo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGotoXoYo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGotoXoYo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGotoXoYo.Location = new System.Drawing.Point(6, 17);
            this.btnGotoXoYo.Name = "btnGotoXoYo";
            this.btnGotoXoYo.Size = new System.Drawing.Size(59, 52);
            this.btnGotoXoYo.TabIndex = 1;
            this.btnGotoXoYo.Text = "GoTo 0,0";
            this.btnGotoXoYo.UseVisualStyleBackColor = false;
            this.btnGotoXoYo.Click += new System.EventHandler(this.btnGotoXoYo_Click);
            // 
            // btnZero
            // 
            this.btnZero.BackColor = System.Drawing.Color.DarkOrange;
            this.btnZero.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnZero.FlatAppearance.BorderSize = 3;
            this.btnZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZero.Location = new System.Drawing.Point(69, 20);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(58, 47);
            this.btnZero.TabIndex = 2;
            this.btnZero.Text = "Zero";
            this.btnZero.UseVisualStyleBackColor = false;
            this.btnZero.Click += new System.EventHandler(this.btnZero_Click);
            // 
            // gbCustom
            // 
            this.gbCustom.Controls.Add(this.tbCustom2);
            this.gbCustom.Controls.Add(this.tbCustom1);
            this.gbCustom.Controls.Add(this.btnCustom2);
            this.gbCustom.Controls.Add(this.btnCustom1);
            this.gbCustom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCustom.Location = new System.Drawing.Point(6, 228);
            this.gbCustom.Name = "gbCustom";
            this.gbCustom.Size = new System.Drawing.Size(672, 52);
            this.gbCustom.TabIndex = 6;
            this.gbCustom.TabStop = false;
            this.gbCustom.Text = "Custom";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkOrange;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(684, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.view3dpBurnerSettingsToolStripMenuItem,
            this.sendConfigurationFileTo3dpBurnerToolStripMenuItem,
            this.toolStripMenuItem2,
            this.restoreSettingsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(284, 6);
            // 
            // view3dpBurnerSettingsToolStripMenuItem
            // 
            this.view3dpBurnerSettingsToolStripMenuItem.Name = "view3dpBurnerSettingsToolStripMenuItem";
            this.view3dpBurnerSettingsToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.view3dpBurnerSettingsToolStripMenuItem.Text = "View 3dpBurner configuration";
            this.view3dpBurnerSettingsToolStripMenuItem.Click += new System.EventHandler(this.view3dpBurnerSettingsToolStripMenuItem_Click);
            // 
            // sendConfigurationFileTo3dpBurnerToolStripMenuItem
            // 
            this.sendConfigurationFileTo3dpBurnerToolStripMenuItem.Name = "sendConfigurationFileTo3dpBurnerToolStripMenuItem";
            this.sendConfigurationFileTo3dpBurnerToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.sendConfigurationFileTo3dpBurnerToolStripMenuItem.Text = "Send configuration file to 3dpBurner...";
            this.sendConfigurationFileTo3dpBurnerToolStripMenuItem.Click += new System.EventHandler(this.sendConfigurationFileTo3dpBurnerToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(284, 6);
            // 
            // restoreSettingsToolStripMenuItem
            // 
            this.restoreSettingsToolStripMenuItem.Name = "restoreSettingsToolStripMenuItem";
            this.restoreSettingsToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.restoreSettingsToolStripMenuItem.Text = "Restore application settings";
            this.restoreSettingsToolStripMenuItem.Click += new System.EventHandler(this.restoreSettingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(684, 22);
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
            // tmrControlsUpdate
            // 
            this.tmrControlsUpdate.Enabled = true;
            this.tmrControlsUpdate.Interval = 250;
            this.tmrControlsUpdate.Tick += new System.EventHandler(this.tmrControlsUpdate_Tick);
            // 
            // bStart
            // 
            this.bStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(196)))), ((int)(((byte)(23)))));
            this.bStart.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bStart.FlatAppearance.BorderSize = 5;
            this.bStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStart.Location = new System.Drawing.Point(574, 7);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(83, 76);
            this.bStart.TabIndex = 4;
            this.bStart.Text = "Resume";
            this.bStart.UseVisualStyleBackColor = false;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // bPause
            // 
            this.bPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(10)))));
            this.bPause.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bPause.FlatAppearance.BorderSize = 5;
            this.bPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPause.Location = new System.Drawing.Point(483, 7);
            this.bPause.Name = "bPause";
            this.bPause.Size = new System.Drawing.Size(83, 76);
            this.bPause.TabIndex = 3;
            this.bPause.Text = "Hold";
            this.bPause.UseVisualStyleBackColor = false;
            this.bPause.Click += new System.EventHandler(this.bPause_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Controls.Add(this.btnReset);
            this.panel5.Location = new System.Drawing.Point(10, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(376, 81);
            this.panel5.TabIndex = 1;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(34)))), ((int)(((byte)(23)))));
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(10)))));
            this.btnReset.FlatAppearance.BorderSize = 5;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Black;
            this.btnReset.Location = new System.Drawing.Point(5, 5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(365, 71);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // panel19
            // 
            this.panel19.BackColor = System.Drawing.Color.White;
            this.panel19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel19.Controls.Add(this.btnUnlock);
            this.panel19.Controls.Add(this.panel5);
            this.panel19.Controls.Add(this.bPause);
            this.panel19.Controls.Add(this.bStart);
            this.panel19.Location = new System.Drawing.Point(6, 284);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(671, 93);
            this.panel19.TabIndex = 8;
            // 
            // btnUnlock
            // 
            this.btnUnlock.BackColor = System.Drawing.Color.Silver;
            this.btnUnlock.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnUnlock.FlatAppearance.BorderSize = 5;
            this.btnUnlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnlock.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUnlock.Location = new System.Drawing.Point(391, 17);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(72, 59);
            this.btnUnlock.TabIndex = 2;
            this.btnUnlock.Text = "Unlock";
            this.btnUnlock.UseVisualStyleBackColor = false;
            this.btnUnlock.Click += new System.EventHandler(this.button11_Click);
            // 
            // frm3dpBurner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gbCustom);
            this.Controls.Add(this.gbReference);
            this.Controls.Add(this.gbConsole);
            this.Controls.Add(this.gbLaserControl);
            this.Controls.Add(this.gbConecction);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbJog);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel19);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
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
            this.panel5.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bOpenPort;
        private System.Windows.Forms.ComboBox cbPort;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnLaserOn;
        private System.Windows.Forms.Button btsLaserOff;
        private System.Windows.Forms.Button btnCustom1;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.Button bOpenfile;
        private System.Windows.Forms.Button bSendCmd;
        private System.Windows.Forms.Button bHome;
        private System.Windows.Forms.TextBox tbStepSize;
        private System.Windows.Forms.ProgressBar pbFile;
        private System.Windows.Forms.Button btnCustom2;
        private System.Windows.Forms.TextBox tbCustom1;
        private System.Windows.Forms.TextBox tbCustom2;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.GroupBox gbJog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbLaserPwr;
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.Button bXdown;
        private System.Windows.Forms.Button bYup;
        private System.Windows.Forms.Button bXup;
        private System.Windows.Forms.Button bYdown;
        private System.Windows.Forms.Button btnFileStart;
        private System.Windows.Forms.Timer tmrControlsUpdate;
        private System.Windows.Forms.Button btnPortsInfo;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Button bPause;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.Button btnGotoXoYo;
        private System.Windows.Forms.ToolStripMenuItem sendConfigurationFileTo3dpBurnerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem view3dpBurnerSettingsToolStripMenuItem;
    }
}

