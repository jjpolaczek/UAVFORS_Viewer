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
            this.trackBarScoreHue = new System.Windows.Forms.TrackBar();
            this.trackBarScoreDensity = new System.Windows.Forms.TrackBar();
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.trackBarSize = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.labelLatitudeLand = new System.Windows.Forms.Label();
            this.labelLongitudeLand = new System.Windows.Forms.Label();
            this.textBoxLatitudeLand = new System.Windows.Forms.TextBox();
            this.textBoxLongitudeLand = new System.Windows.Forms.TextBox();
            this.buttonSendLocation = new System.Windows.Forms.Button();
            this.groupBoxLandCoordinates = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStripMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScoreHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScoreDensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTimeMax)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSize)).BeginInit();
            this.groupBoxLandCoordinates.SuspendLayout();
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
            this.gMapControl.Location = new System.Drawing.Point(0, 31);
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
            this.gMapControl.OnMarkerLeave += new GMap.NET.WindowsForms.MarkerLeave(this.gMapControl_OnMarkerLeave);
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
            this.menuStrip1.Size = new System.Drawing.Size(1248, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remoteServerToolStripMenuItem,
            this.mapToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // remoteServerToolStripMenuItem
            // 
            this.remoteServerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modifyToolStripMenuItem});
            this.remoteServerToolStripMenuItem.Name = "remoteServerToolStripMenuItem";
            this.remoteServerToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.remoteServerToolStripMenuItem.Text = "Remote Server";
            // 
            // modifyToolStripMenuItem
            // 
            this.modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
            this.modifyToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.modifyToolStripMenuItem.Text = "Modify";
            this.modifyToolStripMenuItem.Click += new System.EventHandler(this.modifyToolStripMenuItem_Click);
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proviToolStripMenuItem,
            this.googleToolStripMenuItem});
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.mapToolStripMenuItem.Text = "Map provider";
            // 
            // proviToolStripMenuItem
            // 
            this.proviToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.satelliteToolStripMenuItem,
            this.roadToolStripMenuItem,
            this.hybridToolStripMenuItem});
            this.proviToolStripMenuItem.Name = "proviToolStripMenuItem";
            this.proviToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.proviToolStripMenuItem.Text = "Bing";
            // 
            // satelliteToolStripMenuItem
            // 
            this.satelliteToolStripMenuItem.Name = "satelliteToolStripMenuItem";
            this.satelliteToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.satelliteToolStripMenuItem.Text = "Satellite";
            this.satelliteToolStripMenuItem.Click += new System.EventHandler(this.satelliteToolStripMenuItem_Click);
            // 
            // roadToolStripMenuItem
            // 
            this.roadToolStripMenuItem.Name = "roadToolStripMenuItem";
            this.roadToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.roadToolStripMenuItem.Text = "Road";
            this.roadToolStripMenuItem.Click += new System.EventHandler(this.roadToolStripMenuItem_Click);
            // 
            // hybridToolStripMenuItem
            // 
            this.hybridToolStripMenuItem.Name = "hybridToolStripMenuItem";
            this.hybridToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
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
            this.googleToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.googleToolStripMenuItem.Text = "Google";
            // 
            // satelliteToolStripMenuItem1
            // 
            this.satelliteToolStripMenuItem1.Name = "satelliteToolStripMenuItem1";
            this.satelliteToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            this.satelliteToolStripMenuItem1.Text = "Satellite";
            this.satelliteToolStripMenuItem1.Click += new System.EventHandler(this.satelliteToolStripMenuItem1_Click);
            // 
            // roadToolStripMenuItem1
            // 
            this.roadToolStripMenuItem1.Name = "roadToolStripMenuItem1";
            this.roadToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            this.roadToolStripMenuItem1.Text = "Road";
            this.roadToolStripMenuItem1.Click += new System.EventHandler(this.roadToolStripMenuItem1_Click);
            // 
            // hybridToolStripMenuItem1
            // 
            this.hybridToolStripMenuItem1.Name = "hybridToolStripMenuItem1";
            this.hybridToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            this.hybridToolStripMenuItem1.Text = "Hybrid";
            this.hybridToolStripMenuItem1.Click += new System.EventHandler(this.hybridToolStripMenuItem1_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
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
            // contextMenuStripMap
            // 
            this.contextMenuStripMap.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripMap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInMarkersToolStripMenuItem,
            this.addPOIToolStripMenuItem,
            this.clearPOIToolStripMenuItem});
            this.contextMenuStripMap.Name = "contextMenuStrip1";
            this.contextMenuStripMap.Size = new System.Drawing.Size(165, 70);
            // 
            // zoomInMarkersToolStripMenuItem
            // 
            this.zoomInMarkersToolStripMenuItem.Name = "zoomInMarkersToolStripMenuItem";
            this.zoomInMarkersToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.zoomInMarkersToolStripMenuItem.Text = "Zoom in markers";
            this.zoomInMarkersToolStripMenuItem.Click += new System.EventHandler(this.zoomInMarkersToolStripMenuItem_Click);
            // 
            // addPOIToolStripMenuItem
            // 
            this.addPOIToolStripMenuItem.Name = "addPOIToolStripMenuItem";
            this.addPOIToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.addPOIToolStripMenuItem.Text = "Add POI";
            this.addPOIToolStripMenuItem.Click += new System.EventHandler(this.addPOIToolStripMenuItem_Click);
            // 
            // clearPOIToolStripMenuItem
            // 
            this.clearPOIToolStripMenuItem.Name = "clearPOIToolStripMenuItem";
            this.clearPOIToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.clearPOIToolStripMenuItem.Text = "Clear POI";
            this.clearPOIToolStripMenuItem.Click += new System.EventHandler(this.clearPOIToolStripMenuItem_Click);
            // 
            // trackBarScoreHue
            // 
            this.trackBarScoreHue.Location = new System.Drawing.Point(-2, 3);
            this.trackBarScoreHue.Maximum = 255;
            this.trackBarScoreHue.Name = "trackBarScoreHue";
            this.trackBarScoreHue.Size = new System.Drawing.Size(264, 45);
            this.trackBarScoreHue.TabIndex = 6;
            this.trackBarScoreHue.TickFrequency = 5;
            this.trackBarScoreHue.ValueChanged += new System.EventHandler(this.SliderChanged);
            // 
            // trackBarScoreDensity
            // 
            this.trackBarScoreDensity.Location = new System.Drawing.Point(-2, 65);
            this.trackBarScoreDensity.Maximum = 255;
            this.trackBarScoreDensity.Name = "trackBarScoreDensity";
            this.trackBarScoreDensity.Size = new System.Drawing.Size(264, 45);
            this.trackBarScoreDensity.TabIndex = 7;
            this.trackBarScoreDensity.TickFrequency = 5;
            this.trackBarScoreDensity.ValueChanged += new System.EventHandler(this.SliderChanged);
            // 
            // trackBarTime
            // 
            this.trackBarTime.Location = new System.Drawing.Point(-2, 124);
            this.trackBarTime.Maximum = 1;
            this.trackBarTime.Name = "trackBarTime";
            this.trackBarTime.Size = new System.Drawing.Size(264, 45);
            this.trackBarTime.TabIndex = 8;
            this.trackBarTime.ValueChanged += new System.EventHandler(this.SliderChanged);
            // 
            // trackBarTimeMax
            // 
            this.trackBarTimeMax.Location = new System.Drawing.Point(-2, 186);
            this.trackBarTimeMax.Maximum = 1;
            this.trackBarTimeMax.Name = "trackBarTimeMax";
            this.trackBarTimeMax.Size = new System.Drawing.Size(264, 45);
            this.trackBarTimeMax.TabIndex = 9;
            this.trackBarTimeMax.Value = 1;
            this.trackBarTimeMax.ValueChanged += new System.EventHandler(this.SliderChanged);
            // 
            // labelLatitude
            // 
            this.labelLatitude.AutoSize = true;
            this.labelLatitude.Location = new System.Drawing.Point(76, 623);
            this.labelLatitude.Name = "labelLatitude";
            this.labelLatitude.Size = new System.Drawing.Size(67, 13);
            this.labelLatitude.TabIndex = 10;
            this.labelLatitude.Text = "labelLatitude";
            // 
            // labelLongitude
            // 
            this.labelLongitude.AutoSize = true;
            this.labelLongitude.Location = new System.Drawing.Point(154, 623);
            this.labelLongitude.Name = "labelLongitude";
            this.labelLongitude.Size = new System.Drawing.Size(76, 13);
            this.labelLongitude.TabIndex = 11;
            this.labelLongitude.Text = "labelLongitude";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 623);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
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
            this.labelLonLatch.Size = new System.Drawing.Size(53, 13);
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
            this.labelUTMN.Size = new System.Drawing.Size(42, 13);
            this.labelUTMN.TabIndex = 15;
            this.labelUTMN.Text = "UTM N";
            // 
            // labelUTME
            // 
            this.labelUTME.AutoSize = true;
            this.labelUTME.Location = new System.Drawing.Point(825, 635);
            this.labelUTME.Name = "labelUTME";
            this.labelUTME.Size = new System.Drawing.Size(41, 13);
            this.labelUTME.TabIndex = 16;
            this.labelUTME.Text = "UTM E";
            // 
            // labelUTMzone
            // 
            this.labelUTMzone.AutoSize = true;
            this.labelUTMzone.Location = new System.Drawing.Point(720, 635);
            this.labelUTMzone.Name = "labelUTMzone";
            this.labelUTMzone.Size = new System.Drawing.Size(30, 13);
            this.labelUTMzone.TabIndex = 17;
            this.labelUTMzone.Text = "zone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Score Hue.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Score Dens.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(196, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Time Min.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(193, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Time Max.";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.trackBarScoreHue);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.trackBarScoreDensity);
            this.panel1.Controls.Add(this.trackBarTime);
            this.panel1.Controls.Add(this.trackBarTimeMax);
            this.panel1.Location = new System.Drawing.Point(972, 359);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 245);
            this.panel1.TabIndex = 22;
            // 
            // trackBarSize
            // 
            this.trackBarSize.Location = new System.Drawing.Point(1083, 305);
            this.trackBarSize.Maximum = 40;
            this.trackBarSize.Name = "trackBarSize";
            this.trackBarSize.Size = new System.Drawing.Size(151, 45);
            this.trackBarSize.TabIndex = 23;
            this.trackBarSize.TickFrequency = 2;
            this.trackBarSize.ValueChanged += new System.EventHandler(this.trackBarSize_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1016, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Size boost";
            // 
            // labelLatitudeLand
            // 
            this.labelLatitudeLand.AutoSize = true;
            this.labelLatitudeLand.Location = new System.Drawing.Point(3, 24);
            this.labelLatitudeLand.Name = "labelLatitudeLand";
            this.labelLatitudeLand.Size = new System.Drawing.Size(25, 13);
            this.labelLatitudeLand.TabIndex = 25;
            this.labelLatitudeLand.Text = "Lat:";
            // 
            // labelLongitudeLand
            // 
            this.labelLongitudeLand.AutoSize = true;
            this.labelLongitudeLand.Location = new System.Drawing.Point(135, 24);
            this.labelLongitudeLand.Name = "labelLongitudeLand";
            this.labelLongitudeLand.Size = new System.Drawing.Size(28, 13);
            this.labelLongitudeLand.TabIndex = 26;
            this.labelLongitudeLand.Text = "Lon:";
            // 
            // textBoxLatitudeLand
            // 
            this.textBoxLatitudeLand.Location = new System.Drawing.Point(30, 21);
            this.textBoxLatitudeLand.Name = "textBoxLatitudeLand";
            this.textBoxLatitudeLand.Size = new System.Drawing.Size(92, 20);
            this.textBoxLatitudeLand.TabIndex = 27;
            // 
            // textBoxLongitudeLand
            // 
            this.textBoxLongitudeLand.Location = new System.Drawing.Point(165, 21);
            this.textBoxLongitudeLand.Name = "textBoxLongitudeLand";
            this.textBoxLongitudeLand.Size = new System.Drawing.Size(92, 20);
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
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1248, 656);
            this.Controls.Add(this.groupBoxLandCoordinates);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.trackBarSize);
            this.Controls.Add(this.panel1);
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
            this.Controls.Add(this.gMapControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "UAVFORS Viewer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStripMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScoreHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScoreDensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTimeMax)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSize)).EndInit();
            this.groupBoxLandCoordinates.ResumeLayout(false);
            this.groupBoxLandCoordinates.PerformLayout();
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
        private System.Windows.Forms.TrackBar trackBarScoreHue;
        private System.Windows.Forms.TrackBar trackBarScoreDensity;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar trackBarSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelLatitudeLand;
        private System.Windows.Forms.Label labelLongitudeLand;
        private System.Windows.Forms.TextBox textBoxLatitudeLand;
        private System.Windows.Forms.TextBox textBoxLongitudeLand;
        private System.Windows.Forms.Button buttonSendLocation;
        private System.Windows.Forms.GroupBox groupBoxLandCoordinates;
    }
}

