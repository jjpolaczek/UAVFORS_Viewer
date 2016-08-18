namespace UAVFORS_Viewer
{
    partial class TopViewDialog
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
            this.UavImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.UavImage)).BeginInit();
            this.SuspendLayout();
            // 
            // UavImage
            // 
            this.UavImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UavImage.Location = new System.Drawing.Point(12, 12);
            this.UavImage.Name = "UavImage";
            this.UavImage.Size = new System.Drawing.Size(758, 529);
            this.UavImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UavImage.TabIndex = 0;
            this.UavImage.TabStop = false;
            this.UavImage.MouseEnter += new System.EventHandler(this.UavImage_MouseEnter);
            this.UavImage.MouseLeave += new System.EventHandler(this.UavImage_MouseLeave);
            // 
            // TopViewDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.UavImage);
            this.Name = "TopViewDialog";
            this.Text = "UAV View";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.UavImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox UavImage;
    }
}