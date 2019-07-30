using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace OrdersManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach(var status in Enum.GetNames(typeof(Status)).ToList())
            {
                cbStatus.Items.Add(status);
                cbStatusFilter.Items.Add(status);
            }            
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Load User from config file
            foreach(var id in LoadUsers().Users)
            {
                cbUsers.Items.Add(id.UserName);
            }
            
        }

        private UsersType LoadUsers()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UsersType));
            using (FileStream fileStream = new FileStream("UsersList.xml", FileMode.Open))
            {
                UsersType result = (UsersType)serializer.Deserialize(fileStream);
                return result;
            }
            
        }
    }

    [XmlRoot("Users")]
    public class UsersType
    {
        [XmlElement("User")]
        public List<UserType> Users { get; set; }
    }

    public class UserType
    {
        [XmlAttribute("Id")]
        public string Id { get; set; }
        [XmlAttribute("UserName")]
        public string UserName { get; set; }
    }

    public enum Status
    {
        NewOrder=0,
        Processed=1,
        Shipped=2,
        Finished=3,
        Refund=9
    }
}
