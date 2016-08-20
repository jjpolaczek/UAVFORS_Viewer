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

        public ServerSettings settings;
        public ServerSettingsDialog()
        {
            InitializeComponent();
            settings = new ServerSettings();
        }

        private void Form_Server_Settings_Load(object sender, EventArgs e)
        {
            settings = loadSettings();
            if(settings != null)
            {
                updateFields();
            }
            else
            {
                settings = settingsDefault();
                updateFields();
            }
        }
        private ServerSettings settingsDefault()
        {
            ServerSettings retval = new ServerSettings();
            retval.domain = "ftp://sample.domain.net";
            retval.directory = "UAVFORS";
            retval.password = "";
            retval.username = "username";
            retval.port = 23;
            return retval;
        }
        private void textBoxAddress_TextChanged(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            settings.domain = box.Text;
        }
        private void textBoxDirectory_TextChanged(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            settings.directory = box.Text;
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
        public ServerSettings loadSettings()
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
                return null;
            }
            // Call the Deserialize method and cast to the object type.
            ServerSettings retval = (ServerSettings)mySerializer.Deserialize(myFileStream);
            myFileStream.Close();
            return retval;
        }
        private void updateFields()
        {
            textBoxDomain.Text = settings.domain;
            textBoxDirectory.Text = settings.directory;
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
    [Serializable]
    public class ServerSettings
    {
        public string domain;
        public string directory;
        public int port;
        public string username = null;
        public string password = null;
    }
}
