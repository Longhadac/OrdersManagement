using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdersManagement
{
    public partial class LoadProfiles : Form
    {
        public string selectedProfile { get; set; }

        public LoadProfiles()
        {
            InitializeComponent();
        }

        private void LoadProfiles_Load(object sender, EventArgs e)
        {
            //Load all firefox profiles
            string profilesFolder = ConfigurationManager.AppSettings["FireFoxProfiles"];
            string[] dirs = Directory.GetDirectories(profilesFolder);
            //Array.Sort(dirs, StringComparer.InvariantCulture);
            List<string> amzAccounts = new List<string>();
            foreach (var directory in dirs)
            {
                string[] temp = Path.GetFileName(directory).Split('.');
                amzAccounts.Add(temp[1]);
            }
            amzAccounts.Sort();
            cbUsers.Items.AddRange(amzAccounts.ToArray());
        }

        private void BtnLoadProfile_Click(object sender, EventArgs e)
        {
            selectedProfile = cbUsers.SelectedItem.ToString();
            if(!string.IsNullOrEmpty(selectedProfile))
                Close();
        }
    }
}
