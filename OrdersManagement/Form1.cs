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
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace OrdersManagement
{
    public partial class Form1 : Form
    {
        public static IWebDriver firefoxDriver;
        private string profilesFolder = "";        
        BindingSource bindingSource= new BindingSource();
        public Form1()
        {
            InitializeComponent();
            foreach(var status in Enum.GetNames(typeof(Status)).ToList())
            {
                //cbStatus.Items.Add(status);
                cbStatusFilter.Items.Add(status);
            }            
        }

        private void Button1_Click(object sender, EventArgs e)
        {            
            FirefoxProfile profile = new FirefoxProfile(Path.Combine(profilesFolder, cbUsers.SelectedItem.ToString()));
            FirefoxOptions opt = new FirefoxOptions();
            opt.Profile = profile;
            //@@TODO: remove comment
            //firefoxDriver = new FirefoxDriver(opt);

            //bindingSource.DataSource = LoadOrderFromDB(cbUsers.SelectedText.ToString()).Tables[0];
            //dataGridView1.DataSource = bindingSource;
            dataGridView1.DataSource = LoadOrderFromDB(cbUsers.SelectedText.ToString()).Tables[0];
            // BindingDataFromGridView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Load all firefox profiles
            profilesFolder = ConfigurationManager.AppSettings["FireFoxProfiles"];
            foreach(var directory in Directory.GetDirectories(profilesFolder))
            {
                //string[] temp = Path.GetFileName(directory).Split('.');
                cbUsers.Items.Add(Path.GetFileName(directory));
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

        private void BindingDataFromGridView()
        {
            //cbStatus.DataBindings.Add(new System.Windows.Forms.Binding("Text", bindingSource, "Status", true,DataSourceUpdateMode.OnPropertyChanged));
            tbAliId.DataBindings.Add(new System.Windows.Forms.Binding("Text", bindingSource, "AliId", true, DataSourceUpdateMode.OnPropertyChanged));
            tbAliCashAmount.DataBindings.Add(new System.Windows.Forms.Binding("Text", bindingSource, "AliCashAmount", true, DataSourceUpdateMode.OnPropertyChanged));
            tbAliTrackNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", bindingSource, "AliTrackingNumber", true, DataSourceUpdateMode.OnPropertyChanged));
            tbRefund.DataBindings.Add(new System.Windows.Forms.Binding("Text", bindingSource, "Refund", true, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void BtUpdate_Click(object sender, EventArgs e)
        {
            bool isUpdateAli = false;
            bool isUpdateTracking = false;

            if (string.IsNullOrEmpty(dataGridView1.SelectedRows[0].Cells["AliId"].Value.ToString()) && !string.IsNullOrEmpty(tbAliId.Text))
                isUpdateAli = true;
            if (string.IsNullOrEmpty(dataGridView1.SelectedRows[0].Cells["AliTrackingNumber"].Value.ToString()) && !string.IsNullOrEmpty(tbAliTrackNumber.Text))
                isUpdateTracking = true;

            dataGridView1.SelectedRows[0].Cells["AliId"].Value = tbAliId.Text;
            dataGridView1.SelectedRows[0].Cells["AliCashAmount"].Value = tbAliCashAmount.Text;
            dataGridView1.SelectedRows[0].Cells["AliTrackingNumber"].Value = tbAliTrackNumber.Text;
            dataGridView1.SelectedRows[0].Cells["Refund"].Value = tbRefund.Text;

            //Save data to DB
            UpdateToDB(int.Parse(dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString()),tbAliId.Text, tbAliCashAmount.Text, tbAliTrackNumber.Text, 
                tbRefund.Text, isUpdateAli, isUpdateTracking);
        }

        private void BtnGetAmzOrder_Click(object sender, EventArgs e)
        {
            //Get new order from Amazon: update shipment status
        }

        private DataSet LoadOrderFromDB(string userName)
        {
            //Load data from DB for selected users
            MySqlConnection conn;
            string connectionString = ConfigurationManager.AppSettings["MySQLConnection"];
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                string query = "SELECT * FROM Orders";
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);                    
                    return ds;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void UpdateToDB(int Id, string AliId, string AliCashAmount,string AliTrackingNumber, string Refund, bool isUpdateAli, bool isUpdateTracking)
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["MySQLConnection"]);
            conn.Open();

            string updateCmd = "UPDATE Orders SET AliId=@AliId, AliDate=@AliDate, AliCashAmount=@AliCashAmount, AliTrackingNumber=@AliTrackingNumber, "
                + "AliTrackingDate=@AliTrackingDate, Refund=@Refund WHERE Id=@Id";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = updateCmd;
            cmd.Parameters.AddWithValue("@AliId", AliId);

            if (isUpdateAli)
                cmd.Parameters.AddWithValue("@AliDate", DateTime.Now);
            else
                cmd.Parameters.AddWithValue("@AliDate", "");

            //Parsing double value
            try
            {
                if (!string.IsNullOrWhiteSpace(AliCashAmount))
                {
                    double cashAmount = double.Parse(AliCashAmount);
                    cmd.Parameters.AddWithValue("@AliCashAmount", AliCashAmount);
                }
                else
                    cmd.Parameters.AddWithValue("@AliCashAmount", 0);

                if (!string.IsNullOrWhiteSpace(Refund))
                {
                    double refund = double.Parse(Refund);
                    cmd.Parameters.AddWithValue("@Refund", refund);
                }
                else
                    cmd.Parameters.AddWithValue("@Refund", 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Number is invalid" + ex.ToString());
            }
            
            cmd.Parameters.AddWithValue("@AliTrackingNumber", AliTrackingNumber);
            if (isUpdateTracking)
                cmd.Parameters.AddWithValue("@AliTrackingDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            else
                cmd.Parameters.AddWithValue("@AliTrackingDate", "");
            
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.ExecuteNonQuery();
            conn.Close();
            cmd.Dispose();
            conn.Dispose();
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbAliId.Text = dataGridView1.SelectedRows[0].Cells["AliId"].Value.ToString();
            tbAliCashAmount.Text = dataGridView1.SelectedRows[0].Cells["AliCashAmount"].Value.ToString();
            tbAliTrackNumber.Text = dataGridView1.SelectedRows[0].Cells["AliTrackingNumber"].Value.ToString();
            tbRefund.Text = dataGridView1.SelectedRows[0].Cells["Refund"].Value.ToString();
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
        Refund=4
    }
}
