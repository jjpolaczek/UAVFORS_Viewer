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
            this.contextMenuStripMap = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zoomInMarkersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPOIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearPOIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackBarScore = new System.Windows.Forms.TrackBar();
            this.trackBarScoreMax = new System.Windows.Forms.TrackBar();
            this.trackBarTime = new System.Windows.Forms.TrackBar();
            this.trackBarTimeMax = new System.Windows.Forms.TrackBar();
            this.labelLatitude = new System.Windows.Forms.Label();
            this.labelLongitude = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelLatLatch = new System.Windows.Forms.Label();
            this.labelLonLatch = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.labelUTMN = new System.Windows.Forms.Label();
            this.labelUTME = new System.Windows.Forms.Label();
            this.labelUTMzone = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStripMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScoreMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTimeMax)).BeginInit();
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
            this.gMapControl.Location = new System.Drawing.Point(12, 31);
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
            this.gMapControl.Size = new System.Drawing.Size(902, 582);
            this.gMapControl.TabIndex = 0;
            this.gMapControl.Zoom = 8D;
            this.gMapControl.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gMapControl_OnMarkerClick);
            this.gMapControl.OnMarkerEnter += new GMap.NET.WindowsForms.MarkerEnter(this.gMapControl_OnMarkerEnter);
            this.gMapControl.OnMapZoomChanged += new GMap.NET.MapZoomChanged(this.gMapControl_OnMapZoomChanged);
            this.gMapControl.Load += new System.EventHandler(this.Form1_Load);
            this.gMapControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gMapControl_MouseClick);
            this.gMapControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gMapControl_MouseDoubleClick);
            this.gMapControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gMapControl_MouseMove);
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
            // contextMenuStripMap
            // 
            this.contextMenuStripMap.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripMap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInMarkersToolStripMenuItem,
            this.addPOIToolStripMenuItem,
            this.clearPOIToolStripMenuItem});
            this.contextMenuStripMap.Name = "contextMenuStrip1";
            this.contextMenuStripMap.Size = new System.Drawing.Size(197, 82);
            // 
            // zoomInMarkersToolStripMenuItem
            // 
            this.zoomInMarkersToolStripMenuItem.Name = "zoomInMarkersToolStripMenuItem";
            this.zoomInMarkersToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.zoomInMarkersToolStripMenuItem.Text = "Zoom in markers";
            this.zoomInMarkersToolStripMenuItem.Click += new System.EventHandler(this.zoomInMarkersToolStripMenuItem_Click);
            // 
            // addPOIToolStripMenuItem
            // 
            this.addPOIToolStripMenuItem.Name = "addPOIToolStripMenuItem";
            this.addPOIToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.addPOIToolStripMenuItem.Text = "Add POI";
            this.addPOIToolStripMenuItem.Click += new System.EventHandler(this.addPOIToolStripMenuItem_Click);
            // 
            // clearPOIToolStripMenuItem
            // 
            this.clearPOIToolStripMenuItem.Name = "clearPOIToolStripMenuItem";
            this.clearPOIToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.clearPOIToolStripMenuItem.Text = "Clear POI";
            this.clearPOIToolStripMenuItem.Click += new System.EventHandler(this.clearPOIToolStripMenuItem_Click);
            // 
            // trackBarScore
            // 
            this.trackBarScore.Location = new System.Drawing.Point(972, 232);
            this.trackBarScore.Maximum = 10000;
            this.trackBarScore.Name = "trackBarScore";
            this.trackBarScore.Size = new System.Drawing.Size(264, 56);
            this.trackBarScore.TabIndex = 6;
            this.trackBarScore.TickFrequency = 200;
            this.trackBarScore.ValueChanged += new System.EventHandler(this.SliderChanged);
            // 
            // trackBarScoreMax
            // 
            this.trackBarScoreMax.Location = new System.Drawing.Point(972, 295);
            this.trackBarScoreMax.Maximum = 10000;
            this.trackBarScoreMax.Name = "trackBarScoreMax";
            this.trackBarScoreMax.Size = new System.Drawing.Size(264, 56);
            this.trackBarScoreMax.TabIndex = 7;
            this.trackBarScoreMax.TickFrequency = 200;
            this.trackBarScoreMax.Value = 10000;
            this.trackBarScoreMax.ValueChanged += new System.EventHandler(this.SliderChanged);
            // 
            // trackBarTime
            // 
            this.trackBarTime.Location = new System.Drawing.Point(972, 406);
            this.trackBarTime.Maximum = 1;
            this.trackBarTime.Name = "trackBarTime";
            this.trackBarTime.Size = new System.Drawing.Size(264, 56);
            this.trackBarTime.TabIndex = 8;
            this.trackBarTime.ValueChanged += new System.EventHandler(this.SliderChanged);
            // 
            // trackBarTimeMax
            // 
            this.trackBarTimeMax.Location = new System.Drawing.Point(972, 471);
            this.trackBarTimeMax.Maximum = 1;
            this.trackBarTimeMax.Name = "trackBarTimeMax";
            this.trackBarTimeMax.Size = new System.Drawing.Size(264, 56);
            this.trackBarTimeMax.TabIndex = 9;
            this.trackBarTimeMax.Value = 1;
            this.trackBarTimeMax.ValueChanged += new System.EventHandler(this.SliderChanged);
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
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1248, 656);
            this.Controls.Add(this.labelUTMzone);
            this.Controls.Add(this.labelUTME);
            this.Controls.Add(this.labelUTMN);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.labelLonLatch);
            this.Controls.Add(this.labelLatLatch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelLongitude);
            this.Controls.Add(this.labelLatitude);
            this.Controls.Add(this.trackBarTimeMax);
            this.Controls.Add(this.trackBarTime);
            this.Controls.Add(this.trackBarScoreMax);
            this.Controls.Add(this.trackBarScore);
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
            this.contextMenuStripMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScoreMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTimeMax)).EndInit();
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMap;
        private System.Windows.Forms.ToolStripMenuItem zoomInMarkersToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackBarScore;
        private System.Windows.Forms.TrackBar trackBarScoreMax;
        private System.Windows.Forms.TrackBar trackBarTime;
        private System.Windows.Forms.TrackBar trackBarTimeMax;
        private System.Windows.Forms.Label labelLatitude;
        private System.Windows.Forms.Label labelLongitude;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelLatLatch;
        private System.Windows.Forms.Label labelLonLatch;
        private System.Windows.Forms.ToolStripMenuItem addPOIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearPOIToolStripMenuItem;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label labelUTMN;
        private System.Windows.Forms.Label labelUTME;
        private System.Windows.Forms.Label labelUTMzone;
    }
}

