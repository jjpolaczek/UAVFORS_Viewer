namespace FTP_Image_Browser
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
            this.gMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.satelliteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hybridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.googleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.satelliteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.roadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hybridToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelStatus = new System.Windows.Forms.Label();
            this.treeViewFolders = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.buttonMagic = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gMapControl
            // 
            this.gMapControl.BackColor = System.Drawing.SystemColors.Control;
            this.gMapControl.Bearing = 0F;
            this.gMapControl.CanDragMap = true;
            this.gMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl.GrayScaleMode = false;
            this.gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl.LevelsKeepInMemmory = 5;
            this.gMapControl.Location = new System.Drawing.Point(12, 43);
            this.gMapControl.MarkersEnabled = true;
            this.gMapControl.MaxZoom = 20;
            this.gMapControl.MinZoom = 2;
            this.gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl.Name = "gMapControl";
            this.gMapControl.NegativeMode = false;
            this.gMapControl.PolygonsEnabled = true;
            this.gMapControl.RetryLoadTile = 0;
            this.gMapControl.RoutesEnabled = true;
            this.gMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl.ShowTileGridLines = false;
            this.gMapControl.Size = new System.Drawing.Size(893, 594);
            this.gMapControl.TabIndex = 0;
            this.gMapControl.Zoom = 8D;
            this.gMapControl.OnMapZoomChanged += new GMap.NET.MapZoomChanged(this.gMapControl_OnMapZoomChanged);
            this.gMapControl.Load += new System.EventHandler(this.Form1_Load);
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
            this.remoteServerToolStripMenuItem,
            this.mapToolStripMenuItem});
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
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proviToolStripMenuItem,
            this.googleToolStripMenuItem});
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.mapToolStripMenuItem.Text = "Map provider";
            // 
            // proviToolStripMenuItem
            // 
            this.proviToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.satelliteToolStripMenuItem,
            this.roadToolStripMenuItem,
            this.hybridToolStripMenuItem});
            this.proviToolStripMenuItem.Name = "proviToolStripMenuItem";
            this.proviToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.proviToolStripMenuItem.Text = "Bing";
            // 
            // satelliteToolStripMenuItem
            // 
            this.satelliteToolStripMenuItem.Name = "satelliteToolStripMenuItem";
            this.satelliteToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.satelliteToolStripMenuItem.Text = "Satellite";
            this.satelliteToolStripMenuItem.Click += new System.EventHandler(this.satelliteToolStripMenuItem_Click);
            // 
            // roadToolStripMenuItem
            // 
            this.roadToolStripMenuItem.Name = "roadToolStripMenuItem";
            this.roadToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.roadToolStripMenuItem.Text = "Road";
            this.roadToolStripMenuItem.Click += new System.EventHandler(this.roadToolStripMenuItem_Click);
            // 
            // hybridToolStripMenuItem
            // 
            this.hybridToolStripMenuItem.Name = "hybridToolStripMenuItem";
            this.hybridToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.hybridToolStripMenuItem.Text = "Hybrid";
            this.hybridToolStripMenuItem.Click += new System.EventHandler(this.hybridToolStripMenuItem_Click);
            // 
            // googleToolStripMenuItem
            // 
            this.googleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.satelliteToolStripMenuItem1,
            this.roadToolStripMenuItem1,
            this.hybridToolStripMenuItem1});
            this.googleToolStripMenuItem.Name = "googleToolStripMenuItem";
            this.googleToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.googleToolStripMenuItem.Text = "Google";
            // 
            // satelliteToolStripMenuItem1
            // 
            this.satelliteToolStripMenuItem1.Name = "satelliteToolStripMenuItem1";
            this.satelliteToolStripMenuItem1.Size = new System.Drawing.Size(138, 26);
            this.satelliteToolStripMenuItem1.Text = "Satellite";
            this.satelliteToolStripMenuItem1.Click += new System.EventHandler(this.satelliteToolStripMenuItem1_Click);
            // 
            // roadToolStripMenuItem1
            // 
            this.roadToolStripMenuItem1.Name = "roadToolStripMenuItem1";
            this.roadToolStripMenuItem1.Size = new System.Drawing.Size(138, 26);
            this.roadToolStripMenuItem1.Text = "Road";
            this.roadToolStripMenuItem1.Click += new System.EventHandler(this.roadToolStripMenuItem1_Click);
            // 
            // hybridToolStripMenuItem1
            // 
            this.hybridToolStripMenuItem1.Name = "hybridToolStripMenuItem1";
            this.hybridToolStripMenuItem1.Size = new System.Drawing.Size(138, 26);
            this.hybridToolStripMenuItem1.Text = "Hybrid";
            this.hybridToolStripMenuItem1.Click += new System.EventHandler(this.hybridToolStripMenuItem1_Click);
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
            this.labelStatus.Location = new System.Drawing.Point(928, 614);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelStatus.Size = new System.Drawing.Size(202, 23);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "Disconnected";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // treeViewFolders
            // 
            this.treeViewFolders.Location = new System.Drawing.Point(956, 43);
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
            this.buttonMagic.Location = new System.Drawing.Point(1145, 221);
            this.buttonMagic.Name = "buttonMagic";
            this.buttonMagic.Size = new System.Drawing.Size(75, 23);
            this.buttonMagic.TabIndex = 5;
            this.buttonMagic.Text = "Magic!";
            this.buttonMagic.UseVisualStyleBackColor = true;
            this.buttonMagic.Click += new System.EventHandler(this.buttonMagic_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1248, 649);
            this.Controls.Add(this.buttonMagic);
            this.Controls.Add(this.treeViewFolders);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.gMapControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "UAVFORS Viewer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl;
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
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem satelliteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hybridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem googleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem satelliteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem roadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hybridToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

