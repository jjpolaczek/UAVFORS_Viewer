using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTP_Image_Browser
{
    public partial class TopViewDialog : Form
    {
        public TopViewDialog(string filepath)
        {
            InitializeComponent();
            UavImage.SizeMode = PictureBoxSizeMode.StretchImage;
            UavImage.Location = new Point(borderWidth_,  borderWidth_);
            UavImage.Load(filepath);
            aspectRatio_ = (double)UavImage.Image.Width / UavImage.Image.Height;
            UavImage.Height = baseHeight_;
            ResizeByHeight(0);
            this.UavImage.MouseWheel += UavImage_MouseWheel;
            //UavImage.Show();
            // UavImage.Refresh();
        }
        public void ResizeByHeight(int delta)
        {
            int newHeight = UavImage.Height + delta;
            if (newHeight < 0 || newHeight > 1000) return;
            UavImage.Height = newHeight;
            UavImage.Width = (int)Math.Round(UavImage.Height * aspectRatio_);
            this.Height = UavImage.Height + 2 * borderWidth_;
            this.Width = UavImage.Width + 2 * borderWidth_;
        }
        
        private double aspectRatio_ = 1.59;
        private int borderWidth_ = 5;
        private int baseHeight_ = 500;
        bool isOverDialog_ = false;


        private void UavImage_MouseWheel(object sender, MouseEventArgs e)
        {
            ResizeByHeight(e.Delta);
        }

        private void UavImage_MouseEnter(object sender, EventArgs e)
        {
            UavImage.Focus();
            isOverDialog_ = true;
        }

        private void UavImage_MouseLeave(object sender, EventArgs e)
        {
            isOverDialog_ = false;
        }
    }
}
