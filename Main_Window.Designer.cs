namespace UAVFORS_Viewer
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelStatus = new System.Windows.Forms.Label();
            this.treeViewFolders = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.buttonMagic = new System.Windows.Forms.Button();
            this.labelLatitude = new System.Windows.Forms.Label();
            this.labelLongitude = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelLatLatch = new System.Windows.Forms.Label();
            this.labelLonLatch = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.labelUTMN = new System.Windows.Forms.Label();
            this.labelUTME = new System.Windows.Forms.Label();
            this.labelUTMzone = new System.Windows.Forms.Label();
            this.labelLatitudeLand = new System.Windows.Forms.Label();
            this.labelLongitudeLand = new System.Windows.Forms.Label();
            this.textBoxLatitudeLand = new System.Windows.Forms.TextBox();
            this.textBoxLongitudeLand = new System.Windows.Forms.TextBox();
            this.buttonSendLocation = new System.Windows.Forms.Button();
            this.groupBoxLandCoordinates = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.groupBoxLandCoordinates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.actionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1248, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remoteServerToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // remoteServerToolStripMenuItem
            // 
            this.remoteServerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modifyToolStripMenuItem});
            this.remoteServerToolStripMenuItem.Name = "remoteServerToolStripMenuItem";
            this.remoteServerToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.remoteServerToolStripMenuItem.Text = "Remote Server";
            // 
            // modifyToolStripMenuItem
            // 
            this.modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
            this.modifyToolStripMenuItem.Size = new System.Drawing.Size(131, 26);
            this.modifyToolStripMenuItem.Text = "Modify";
            this.modifyToolStripMenuItem.Click += new System.EventHandler(this.modifyToolStripMenuItem_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(1136, 614);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 23);
            this.progressBar.TabIndex = 2;
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(919, 614);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelStatus.Size = new System.Drawing.Size(211, 23);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "Disconnected";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // treeViewFolders
            // 
            this.treeViewFolders.Location = new System.Drawing.Point(972, 31);
            this.treeViewFolders.Name = "treeViewFolders";
            this.treeViewFolders.Size = new System.Drawing.Size(264, 144);
            this.treeViewFolders.TabIndex = 4;
            this.treeViewFolders.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewFolders_NodeMouseDoubleClick);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // buttonMagic
            // 
            this.buttonMagic.Location = new System.Drawing.Point(1161, 191);
            this.buttonMagic.Name = "buttonMagic";
            this.buttonMagic.Size = new System.Drawing.Size(75, 23);
            this.buttonMagic.TabIndex = 5;
            this.buttonMagic.Text = "Magic!";
            this.buttonMagic.UseVisualStyleBackColor = true;
            this.buttonMagic.Click += new System.EventHandler(this.buttonMagic_Click);
            // 
            // labelLatitude
            // 
            this.labelLatitude.AutoSize = true;
            this.labelLatitude.Location = new System.Drawing.Point(76, 623);
            this.labelLatitude.Name = "labelLatitude";
            this.labelLatitude.Size = new System.Drawing.Size(89, 17);
            this.labelLatitude.TabIndex = 10;
            this.labelLatitude.Text = "labelLatitude";
            // 
            // labelLongitude
            // 
            this.labelLongitude.AutoSize = true;
            this.labelLongitude.Location = new System.Drawing.Point(154, 623);
            this.labelLongitude.Name = "labelLongitude";
            this.labelLongitude.Size = new System.Drawing.Size(101, 17);
            this.labelLongitude.TabIndex = 11;
            this.labelLongitude.Text = "labelLongitude";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 623);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Coordinates:";
            // 
            // labelLatLatch
            // 
            this.labelLatLatch.Location = new System.Drawing.Point(755, 614);
            this.labelLatLatch.Name = "labelLatLatch";
            this.labelLatLatch.Size = new System.Drawing.Size(75, 17);
            this.labelLatLatch.TabIndex = 0;
            this.labelLatLatch.Text = "Click map";
            // 
            // labelLonLatch
            // 
            this.labelLonLatch.AutoSize = true;
            this.labelLonLatch.Location = new System.Drawing.Point(825, 614);
            this.labelLonLatch.Name = "labelLonLatch";
            this.labelLonLatch.Size = new System.Drawing.Size(68, 17);
            this.labelLonLatch.TabIndex = 13;
            this.labelLonLatch.Text = "Click map";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(1050, 191);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 14;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // labelUTMN
            // 
            this.labelUTMN.AutoSize = true;
            this.labelUTMN.Location = new System.Drawing.Point(755, 635);
            this.labelUTMN.Name = "labelUTMN";
            this.labelUTMN.Size = new System.Drawing.Size(52, 17);
            this.labelUTMN.TabIndex = 15;
            this.labelUTMN.Text = "UTM N";
            // 
            // labelUTME
            // 
            this.labelUTME.AutoSize = true;
            this.labelUTME.Location = new System.Drawing.Point(825, 635);
            this.labelUTME.Name = "labelUTME";
            this.labelUTME.Size = new System.Drawing.Size(51, 17);
            this.labelUTME.TabIndex = 16;
            this.labelUTME.Text = "UTM E";
            // 
            // labelUTMzone
            // 
            this.labelUTMzone.AutoSize = true;
            this.labelUTMzone.Location = new System.Drawing.Point(720, 635);
            this.labelUTMzone.Name = "labelUTMzone";
            this.labelUTMzone.Size = new System.Drawing.Size(39, 17);
            this.labelUTMzone.TabIndex = 17;
            this.labelUTMzone.Text = "zone";
            // 
            // labelLatitudeLand
            // 
            this.labelLatitudeLand.AutoSize = true;
            this.labelLatitudeLand.Location = new System.Drawing.Point(3, 24);
            this.labelLatitudeLand.Name = "labelLatitudeLand";
            this.labelLatitudeLand.Size = new System.Drawing.Size(32, 17);
            this.labelLatitudeLand.TabIndex = 25;
            this.labelLatitudeLand.Text = "Lat:";
            // 
            // labelLongitudeLand
            // 
            this.labelLongitudeLand.AutoSize = true;
            this.labelLongitudeLand.Location = new System.Drawing.Point(135, 24);
            this.labelLongitudeLand.Name = "labelLongitudeLand";
            this.labelLongitudeLand.Size = new System.Drawing.Size(36, 17);
            this.labelLongitudeLand.TabIndex = 26;
            this.labelLongitudeLand.Text = "Lon:";
            // 
            // textBoxLatitudeLand
            // 
            this.textBoxLatitudeLand.Location = new System.Drawing.Point(30, 21);
            this.textBoxLatitudeLand.Name = "textBoxLatitudeLand";
            this.textBoxLatitudeLand.Size = new System.Drawing.Size(92, 22);
            this.textBoxLatitudeLand.TabIndex = 27;
            // 
            // textBoxLongitudeLand
            // 
            this.textBoxLongitudeLand.Location = new System.Drawing.Point(165, 21);
            this.textBoxLongitudeLand.Name = "textBoxLongitudeLand";
            this.textBoxLongitudeLand.Size = new System.Drawing.Size(92, 22);
            this.textBoxLongitudeLand.TabIndex = 28;
            // 
            // buttonSendLocation
            // 
            this.buttonSendLocation.Location = new System.Drawing.Point(99, 47);
            this.buttonSendLocation.Name = "buttonSendLocation";
            this.buttonSendLocation.Size = new System.Drawing.Size(56, 23);
            this.buttonSendLocation.TabIndex = 29;
            this.buttonSendLocation.Text = "Send";
            this.buttonSendLocation.UseVisualStyleBackColor = true;
            this.buttonSendLocation.Click += new System.EventHandler(this.buttonSendLocation_Click);
            // 
            // groupBoxLandCoordinates
            // 
            this.groupBoxLandCoordinates.Controls.Add(this.textBoxLongitudeLand);
            this.groupBoxLandCoordinates.Controls.Add(this.labelLatitudeLand);
            this.groupBoxLandCoordinates.Controls.Add(this.buttonSendLocation);
            this.groupBoxLandCoordinates.Controls.Add(this.labelLongitudeLand);
            this.groupBoxLandCoordinates.Controls.Add(this.textBoxLatitudeLand);
            this.groupBoxLandCoordinates.Location = new System.Drawing.Point(970, 220);
            this.groupBoxLandCoordinates.Name = "groupBoxLandCoordinates";
            this.groupBoxLandCoordinates.Size = new System.Drawing.Size(267, 78);
            this.groupBoxLandCoordinates.TabIndex = 30;
            this.groupBoxLandCoordinates.TabStop = false;
            this.groupBoxLandCoordinates.Text = "Remote landing";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(919, 580);
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1248, 656);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBoxLandCoordinates);
            this.Controls.Add(this.labelUTMzone);
            this.Controls.Add(this.labelUTME);
            this.Controls.Add(this.labelUTMN);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.labelLonLatch);
            this.Controls.Add(this.labelLatLatch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelLongitude);
            this.Controls.Add(this.labelLatitude);
            this.Controls.Add(this.buttonMagic);
            this.Controls.Add(this.treeViewFolders);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "UAVFORS Viewer";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxLandCoordinates.ResumeLayout(false);
            this.groupBoxLandCoordinates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remoteServerToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TreeView treeViewFolders;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.Button buttonMagic;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Label labelLatitude;
        private System.Windows.Forms.Label labelLongitude;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelLatLatch;
        private System.Windows.Forms.Label labelLonLatch;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label labelUTMN;
        private System.Windows.Forms.Label labelUTME;
        private System.Windows.Forms.Label labelUTMzone;
        private System.Windows.Forms.Label labelLatitudeLand;
        private System.Windows.Forms.Label labelLongitudeLand;
        private System.Windows.Forms.TextBox textBoxLatitudeLand;
        private System.Windows.Forms.TextBox textBoxLongitudeLand;
        private System.Windows.Forms.Button buttonSendLocation;
        private System.Windows.Forms.GroupBox groupBoxLandCoordinates;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

