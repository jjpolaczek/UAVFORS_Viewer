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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelStatus = new System.Windows.Forms.Label();
            this.treeViewFolders = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.modifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.gMapControl.MaxZoom = 18;
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
            this.gMapControl.Size = new System.Drawing.Size(650, 712);
            this.gMapControl.TabIndex = 0;
            this.gMapControl.Zoom = 8D;
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
            this.menuStrip1.Size = new System.Drawing.Size(944, 28);
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
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(832, 780);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 23);
            this.progressBar.TabIndex = 2;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(732, 783);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelStatus.Size = new System.Drawing.Size(94, 17);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "Disconnected";
            // 
            // treeViewFolders
            // 
            this.treeViewFolders.Location = new System.Drawing.Point(668, 43);
            this.treeViewFolders.Name = "treeViewFolders";
            this.treeViewFolders.Size = new System.Drawing.Size(264, 120);
            this.treeViewFolders.TabIndex = 4;
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // modifyToolStripMenuItem
            // 
            this.modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
            this.modifyToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.modifyToolStripMenuItem.Text = "Modify";
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
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            // 
            // buttonMagic
            // 
            this.buttonMagic.Location = new System.Drawing.Point(704, 240);
            this.buttonMagic.Name = "buttonMagic";
            this.buttonMagic.Size = new System.Drawing.Size(75, 23);
            this.buttonMagic.TabIndex = 5;
            this.buttonMagic.Text = "Magic!";
            this.buttonMagic.UseVisualStyleBackColor = true;
            this.buttonMagic.Click += new System.EventHandler(this.buttonMagic_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 809);
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
    }
}

