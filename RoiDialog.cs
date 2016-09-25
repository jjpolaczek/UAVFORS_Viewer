using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UAVFORS_Viewer
{
    public partial class RoiDialog : Form
    {
        public RoiDialog(float latitude, float longitude)
        {
            InitializeComponent();
            label_latitude.Text += latitude.ToString("F7");
            label_longitude.Text += longitude.ToString("F7");
            string latString, lngString;
            if(latitude > 0)
            {
                latString = latitude.ToString("F7")+"N";
            }
            else
            {
                latString = (-latitude).ToString("F7") + "S";
            }
            if(longitude > 0)
            {
                lngString = longitude.ToString("F7")+"E";
            }
            else
            {
                lngString = (-longitude).ToString("F7") + "W";
            }
            latString = latString.Replace(',', '.');
            lngString = lngString.Replace(',', '.');
            linkLabel_gmaps.Text += latString + "+" + lngString;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button_terrain_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_image_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void linkLabel_gmaps_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(linkLabel_gmaps.Text);
            Process.Start(sInfo);
        }
    }
}
