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
using OpenQA.Selenium.Support.UI;

namespace OrdersManagement
{
    public partial class Form1 : Form
    {
        public static IWebDriver firefoxDriver;
        private string profilesFolder = "";
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private int timeOut = 0;
        public Form1()
        {
            InitializeComponent();
            foreach(var status in Enum.GetNames(typeof(Status)).ToList())
            {
                cbStatusFilter.Items.Add(status);
            }
            log.Info("Start the program");
            timeOut = int.Parse(ConfigurationManager.AppSettings["TimeOutForWaiting"].ToString());
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            log.Info("Start load user profile");
            FirefoxProfile profile = new FirefoxProfile(Path.Combine(profilesFolder, cbUsers.SelectedItem.ToString()));
            FirefoxOptions opt = new FirefoxOptions();
            opt.Profile = profile;
            //@@TODO: remove comment
            firefoxDriver = new FirefoxDriver(opt);

            //dataGridView1.DataSource = LoadOrderFromDB(cbUsers.SelectedText.ToString()).Tables[0];
            log.Info("Finish load user profile");
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
            log.Info("Finish load firefox profiles");
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

        private void BtUpdate_Click(object sender, EventArgs e)
        {
            bool isUpdateAli = false;
            bool isUpdateTracking = false;

            if (string.IsNullOrEmpty(dataGridView1.SelectedRows[0].Cells["AliId"].Value.ToString()) && !string.IsNullOrEmpty(tbAliId.Text))
                isUpdateAli = true;
            if (string.IsNullOrEmpty(dataGridView1.SelectedRows[0].Cells["AliTrackingNumber"].Value.ToString()) && !string.IsNullOrEmpty(tbAliTrackNumber.Text))
                isUpdateTracking = true;

            log.Info("Update data to DB. Is update AliID: " + isUpdateAli.ToString() + ". Is update AliTrackingNumber: " + isUpdateTracking.ToString());

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
            firefoxDriver.Navigate().GoToUrl("https://sellercentral.amazon.com/orders-v3/ref=xx_myo_dnav_xx");
            List<AmzOrder> amzOrders = new List<AmzOrder>();
            string orderXpath = ConfigurationManager.AppSettings["OrderLinkXPath"].ToString();
            string refreshXpath = ConfigurationManager.AppSettings["RefreshButton"].ToString();

            firefoxDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOut);
            bool continueCheck = true;
            int count = 0;
            while (continueCheck)
            {
                try
                {
                    AmzOrder newOrder = new AmzOrder();

                    IWebElement refreshButton = firefoxDriver.FindElement(By.XPath(refreshXpath));
                    refreshButton.Click();

                    IWebElement orderElement = firefoxDriver.FindElement(By.XPath(orderXpath));
                    orderElement.Click();

                    //Get Order information
                    string OrderIdXPath = ConfigurationManager.AppSettings["OrderIdXPath"].ToString();
                    string PurchaseDateXPath = ConfigurationManager.AppSettings["PurchaseDateXPath"].ToString();
                    string CountryXPath = ConfigurationManager.AppSettings["CountryXPath"].ToString();
                    string ShipAddressXPath = ConfigurationManager.AppSettings["ShipAddressXPath"].ToString();
                    string ShipPhoneXPath = ConfigurationManager.AppSettings["ShipPhoneXPath"].ToString();

                    newOrder.OrderId = firefoxDriver.FindElement(By.XPath(OrderIdXPath)).Text;
                    newOrder.PurchasedDate = firefoxDriver.FindElement(By.XPath(PurchaseDateXPath)).Text;
                    newOrder.Country = firefoxDriver.FindElement(By.XPath(CountryXPath)).Text;
                    newOrder.ShipAddress = firefoxDriver.FindElement(By.XPath(ShipAddressXPath)).Text;
                    newOrder.ShipPhone = firefoxDriver.FindElement(By.XPath(ShipPhoneXPath)).Text;

                    //Get items information
                    bool continueItem = true;
                    string ItemImage = ConfigurationManager.AppSettings["ItemImage"].ToString();
                    string ItemAsin = ConfigurationManager.AppSettings["ItemAsin"].ToString();
                    string ItemSku = ConfigurationManager.AppSettings["ItemSku"].ToString();
                    string ItemQuantity = ConfigurationManager.AppSettings["ItemQuantity"].ToString();
                    string ItemUnitPrice = ConfigurationManager.AppSettings["ItemUnitPrice"].ToString();
                    string ItemSubTotal = ConfigurationManager.AppSettings["ItemSubTotal"].ToString();

                    while (continueItem)
                    {
                        try
                        {
                            AmzItem newItem = new AmzItem();
                            newItem.ImageUrl = firefoxDriver.FindElement(By.XPath(ItemImage)).GetAttribute("src");
                            newItem.Asin = firefoxDriver.FindElement(By.XPath(ItemAsin)).Text;
                            newItem.Sku = firefoxDriver.FindElement(By.XPath(ItemSku)).Text;
                            newItem.Quantity = firefoxDriver.FindElement(By.XPath(ItemQuantity)).Text;
                            newItem.UnitPrice = firefoxDriver.FindElement(By.XPath(ItemUnitPrice)).Text;
                            newItem.SubTotal = firefoxDriver.FindElement(By.XPath(ItemSubTotal)).Text;

                            newOrder.Items.Add(newItem);

                            //Update xpath for next item
                            ItemImage += "1";
                            ItemAsin += "1";
                            ItemSku += "1";
                            ItemQuantity += "1";
                            ItemUnitPrice += "1";
                            ItemSubTotal += "1";
                        }
                        catch (Exception ex)
                        {
                            log.Warn("Get item from Amz. OrderId: " + newOrder.OrderId + ". Exception: " + ex.ToString());
                            continueItem = false;
                        }
                    }

                    amzOrders.Add(newOrder);
                }
                catch (Exception ex)
                {
                    log.Warn("Get order from Amz. " + ex.ToString());
                    count++;
                    if (count > int.Parse(ConfigurationManager.AppSettings["NumberOfRetry"].ToString()))
                        continueCheck = false;
                }

                //Confirm shipment for this order                
                try
                {
                    string ConfirmShipment = ConfigurationManager.AppSettings["ConfirmShipment"].ToString();
                    firefoxDriver.FindElement(By.XPath(ConfirmShipment)).Click();

                    string ConfirmShipment2 = ConfigurationManager.AppSettings["ConfirmShipment2"].ToString();
                    firefoxDriver.FindElement(By.XPath(ConfirmShipment2)).Click();

                    string ConfirmShipment3 = ConfigurationManager.AppSettings["ConfirmShipment3"].ToString();
                    firefoxDriver.FindElement(By.XPath(ConfirmShipment3)).Click();
                }
                catch (Exception ex)
                {
                    log.Warn("Do not need to confirm shipment" +ex.ToString());
                }
            }

            //Save to DB
            SaveOrderToDB(amzOrders);
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
            log.Info("Save data to DB. Id, AliId, AliCashAmount, AliTrackingNumber, Refund: " + Id.ToString()
                + ", " + AliId + ", " + AliCashAmount + ", " + AliTrackingNumber + ", " + Refund);

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
                log.Error("Parsing number error. " + ex.ToString());
            }
            
            cmd.Parameters.AddWithValue("@AliTrackingNumber", AliTrackingNumber);
            if (isUpdateTracking)
                cmd.Parameters.AddWithValue("@AliTrackingDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            else
                cmd.Parameters.AddWithValue("@AliTrackingDate", "");
            
            cmd.Parameters.AddWithValue("@Id", Id);
            try
            {
                cmd.ExecuteNonQuery();
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
            catch(Exception ex)
            {
                log.Error("Save data to DB error. " + ex.ToString());
            }
            
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbAliId.Text = dataGridView1.SelectedRows[0].Cells["AliId"].Value.ToString();
            tbAliCashAmount.Text = dataGridView1.SelectedRows[0].Cells["AliCashAmount"].Value.ToString();
            tbAliTrackNumber.Text = dataGridView1.SelectedRows[0].Cells["AliTrackingNumber"].Value.ToString();
            tbRefund.Text = dataGridView1.SelectedRows[0].Cells["Refund"].Value.ToString();
        }

        private void SaveOrderToDB(List<AmzOrder> orders)
        {

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

    public class AmzOrder
    {
        public string OrderId;
        public string PurchasedDate;
        public string ShipAddress;
        public string ShipPhone;
        public string Country;
        public List<AmzItem> Items;

        public AmzOrder()
        {
            Items = new List<AmzItem>();
        }
    }

    public class AmzItem
    {
        public string ImageUrl;
        public string Asin;
        public string Sku;
        public string UnitPrice;
        public string SubTotal;
        public string Quantity;
    }
}
