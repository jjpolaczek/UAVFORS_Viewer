namespace UAVFORS_Viewer
{
    partial class RoiDialog
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
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_image = new System.Windows.Forms.Button();
            this.button_terrain = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(12, 83);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 0;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_image
            // 
            this.button_image.Location = new System.Drawing.Point(285, 83);
            this.button_image.Name = "button_image";
            this.button_image.Size = new System.Drawing.Size(146, 23);
            this.button_image.TabIndex = 1;
            this.button_image.Text = "Download full image";
            this.button_image.UseVisualStyleBackColor = true;
            this.button_image.Click += new System.EventHandler(this.button_image_Click);
            // 
            // button_terrain
            // 
            this.button_terrain.Location = new System.Drawing.Point(103, 83);
            this.button_terrain.Name = "button_terrain";
            this.button_terrain.Size = new System.Drawing.Size(161, 23);
            this.button_terrain.TabIndex = 2;
            this.button_terrain.Text = "Download Terrain";
            this.button_terrain.UseVisualStyleBackColor = true;
            this.button_terrain.Click += new System.EventHandler(this.button_terrain_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "What do you want to do with this ROI? ";
            // 
            // RoiDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 120);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_terrain);
            this.Controls.Add(this.button_image);
            this.Controls.Add(this.button_cancel);
            this.Name = "RoiDialog";
            this.Text = "Select action";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_image;
        private System.Windows.Forms.Button button_terrain;
        private System.Windows.Forms.Label label1;
    }
}