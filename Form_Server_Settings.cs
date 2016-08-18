using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace UAVFORS_Viewer
{

    public partial class ServerSettingsDialog : Form
    {
        [Serializable]
        public class ServerSettings
        {
            public string address;
            public int port;
            public string username = null;
            public string password = null;
        }
        private ServerSettings settings;
        public ServerSettingsDialog()
        {
            InitializeComponent();
            settings = new ServerSettings();
        }

        private void Form_Server_Settings_Load(object sender, EventArgs e)
        {
            loadSettings();
        }

        private void textBoxAddress_TextChanged(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            settings.address = box.Text;
        }

        private void numericUpDownPort_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown box = (NumericUpDown)sender;
            settings.port = (int)box.Value;
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            settings.username = box.Text;
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            settings.password = box.Text;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(ServerSettings));
            StreamWriter myWriter = new StreamWriter("ViewerSettings.xml");
            mySerializer.Serialize(myWriter, settings);
            myWriter.Close();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void loadSettings()
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(ServerSettings));
            FileStream myFileStream;
            try
            {
                myFileStream = new FileStream("ViewerSettings.xml", FileMode.Open);
            }
            catch
            {
                //Pokemon handle file not found exception//
                return;
            }
            // Call the Deserialize method and cast to the object type.
            settings = (ServerSettings)mySerializer.Deserialize(myFileStream);
            updateFields();

        }
        private void updateFields()
        {
            textBoxAddress.Text = settings.address;
            textBoxPassword.Text = settings.password;
            numericUpDownPort.Value = settings.port;
            textBoxUsername.Text = settings.username;
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
