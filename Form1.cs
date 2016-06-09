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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            //FtpListDirectory();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize map:
            gMapControl.MapProvider = GMap.NET.MapProviders.BingHybridMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapControl.SetPositionByKeywords("Warsaw, Poland");
        }

    }
}
