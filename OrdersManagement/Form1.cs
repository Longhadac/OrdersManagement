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
using System.Globalization;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace OrdersManagement
{
    public partial class Form1 : Form
    {
        public static IWebDriver firefoxDriver;
        private string profilesFolder = "";
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private int timeOut = 0;
        string connectionString = "";
        int threadDelay;
        List<string> ffProfiles;
        UsersType userMap;
        public Form1()
        {
            InitializeComponent();
            foreach(var status in Enum.GetNames(typeof(Status)).ToList())
            {
                cbStatusFilter.Items.Add(status);
            }
            log.Info("Start the program");
            timeOut = int.Parse(ConfigurationManager.AppSettings["TimeOutForWaiting"].ToString());
            connectionString = ConfigurationManager.AppSettings["MySQLConnectionLocal"];
            threadDelay = int.Parse(ConfigurationManager.AppSettings["DelayThread"].ToString());
        }

        private void btnLoadProfile_Click(object sender, EventArgs e)
        {
            log.Info("Start load user profile");
            string firefoxProfile = "";
            foreach(string fprofile in ffProfiles)
            {
                if(fprofile.Contains(cbUsers.SelectedItem.ToString()))
                {
                    firefoxProfile = fprofile;
                    break;
                }
            }
            FirefoxProfile profile = new FirefoxProfile(Path.Combine(profilesFolder, firefoxProfile));
            FirefoxOptions opt = new FirefoxOptions();
            opt.Profile = profile;
            
            firefoxDriver = new FirefoxDriver(opt);
            
            log.Info("Finish load user profile");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ffProfiles = new List<string>();
            //Load all firefox profiles
            profilesFolder = ConfigurationManager.AppSettings["FireFoxProfiles"];
            foreach(var directory in Directory.GetDirectories(profilesFolder))
            {
                string[] temp = Path.GetFileName(directory).Split('.');
                ffProfiles.Add(Path.GetFileName(directory));
                cbUsers.Items.Add(temp[1]);
            }
            log.Info("Finish load firefox profiles");

            userMap = LoadUsers();
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
            bool isUpdateRefund = false;

            if ((string.IsNullOrEmpty(dataGridView1.SelectedRows[0].Cells["AliId"].Value.ToString()) && !string.IsNullOrEmpty(tbAliId.Text))
                || (dataGridView1.SelectedRows[0].Cells["AliId"].Value.ToString() != tbAliId.Text))
                isUpdateAli = true;
            if ((string.IsNullOrEmpty(dataGridView1.SelectedRows[0].Cells["AliTrackingNumber"].Value.ToString()) && !string.IsNullOrEmpty(tbAliTrackNumber.Text))
                || (dataGridView1.SelectedRows[0].Cells["AliTrackingNumber"].Value.ToString() != tbAliTrackNumber.Text))
                isUpdateTracking = true;
            if ((string.IsNullOrEmpty(dataGridView1.SelectedRows[0].Cells["Refund"].Value.ToString()) && !string.IsNullOrEmpty(tbRefund.Text))
                || (dataGridView1.SelectedRows[0].Cells["Refund"].Value.ToString() != tbRefund.Text))
                isUpdateRefund = true;

            log.Info("Update data to DB. Is update AliID: " + isUpdateAli.ToString() + ". Is update AliTrackingNumber: " + isUpdateTracking.ToString());

            dataGridView1.SelectedRows[0].Cells["AliId"].Value = tbAliId.Text;
            if(!string.IsNullOrWhiteSpace(tbAliCashAmount.Text))
                dataGridView1.SelectedRows[0].Cells["AliCashAmount"].Value = tbAliCashAmount.Text;
            dataGridView1.SelectedRows[0].Cells["AliTrackingNumber"].Value = tbAliTrackNumber.Text;
            if (!string.IsNullOrWhiteSpace(tbRefund.Text))
                dataGridView1.SelectedRows[0].Cells["Refund"].Value = tbRefund.Text;

            if(isUpdateAli)
                dataGridView1.SelectedRows[0].Cells["Status"].Value = Status.Processed.ToString();
            if (isUpdateTracking)
                dataGridView1.SelectedRows[0].Cells["Status"].Value = Status.Shipped.ToString();
            if (isUpdateRefund)
                dataGridView1.SelectedRows[0].Cells["Status"].Value = Status.Refund.ToString();
            //Save data to DB
            UpdateToDB(int.Parse(dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString()),tbAliId.Text, tbAliCashAmount.Text, tbAliTrackNumber.Text, 
                tbRefund.Text, isUpdateAli, isUpdateTracking, isUpdateRefund);
        }

        private void BtnGetAmzOrder_Click(object sender, EventArgs e)
        {
            //Get new order from Amazon: update shipment status
            firefoxDriver.Navigate().GoToUrl("https://sellercentral.amazon.com/orders-v3/ref=xx_myo_dnav_xx");
            List<AmzOrder> amzOrders = new List<AmzOrder>();
            string orderXpath = ConfigurationManager.AppSettings["OrderLinkXPath"].ToString();
            string orderCSS = ConfigurationManager.AppSettings["OrderLinkCSS"].ToString();
            string refreshXpath = ConfigurationManager.AppSettings["RefreshButton"].ToString();

            firefoxDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOut);
            bool continueCheck = true;
            int count = 0;
            while (continueCheck)
            {
                try
                {
                    AmzOrder newOrder = new AmzOrder();
                    Thread.Sleep(threadDelay);
                    IWebElement refreshButton = firefoxDriver.FindElement(By.XPath(refreshXpath));
                    refreshButton.Click();
                    Thread.Sleep(threadDelay);
                    //IWebElement orderElement = firefoxDriver.FindElement(By.XPath(orderXpath));
                    IWebElement orderElement = firefoxDriver.FindElement(By.CssSelector(orderCSS));
                    orderElement.Click();
                    Thread.Sleep(threadDelay);
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
                    string ItemImage = ConfigurationManager.AppSettings["ItemImageCSS"].ToString();
                    string ItemAsin = ConfigurationManager.AppSettings["ItemAsinCSS"].ToString();
                    string ItemSku = ConfigurationManager.AppSettings["ItemSkuCSS"].ToString();
                    string ItemQuantity = ConfigurationManager.AppSettings["ItemQuantityCSS"].ToString();
                    string ItemUnitPrice = ConfigurationManager.AppSettings["ItemUnitPriceCSS"].ToString();
                    string ItemSubTotal = ConfigurationManager.AppSettings["ItemSubTotalCSS"].ToString();
                    int itemCount = 1;
                    while (continueItem)
                    {
                        try
                        {
                            AmzItem newItem = new AmzItem();
                            newItem.ImageUrl = firefoxDriver.FindElement(By.CssSelector(ItemImage)).GetAttribute("src");
                            newItem.Asin = firefoxDriver.FindElement(By.CssSelector(ItemAsin)).Text;
                            newItem.Sku = firefoxDriver.FindElement(By.CssSelector(ItemSku)).Text;
                            newItem.Quantity = firefoxDriver.FindElement(By.CssSelector(ItemQuantity)).Text;
                            newItem.UnitPrice = firefoxDriver.FindElement(By.CssSelector(ItemUnitPrice)).Text;
                            newItem.SubTotal = firefoxDriver.FindElement(By.CssSelector(ItemSubTotal)).Text;

                            newOrder.Items.Add(newItem);

                            //Update xpath for next item
                            string oldValue = "tr:nth-child(" + itemCount.ToString() + ")";
                            itemCount++;
                            string newValue = "tr:nth-child(" + itemCount.ToString() + ")";
                            ItemImage = ItemImage.Replace(oldValue, newValue);
                            ItemAsin = ItemAsin.Replace(oldValue, newValue);
                            ItemSku = ItemSku.Replace(oldValue, newValue);
                            ItemQuantity = ItemQuantity.Replace(oldValue, newValue);
                            ItemUnitPrice = ItemUnitPrice.Replace(oldValue, newValue);
                            ItemSubTotal = ItemSubTotal.Replace(oldValue, newValue);
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
                    ConfirmShipment = ConfigurationManager.AppSettings["ConfirmShipmentCSS"].ToString();
                    //firefoxDriver.FindElement(By.XPath(ConfirmShipment)).Click();
                    firefoxDriver.FindElement(By.CssSelector(ConfirmShipment)).Click();

                    string ConfirmShipment2 = ConfigurationManager.AppSettings["ConfirmShipment2"].ToString();
                    //ConfirmShipment2 = ConfigurationManager.AppSettings["ConfirmShipment2CSS"].ToString();
                    Thread.Sleep(threadDelay);
                    firefoxDriver.FindElement(By.XPath(ConfirmShipment2)).Click();
                    //firefoxDriver.FindElement(By.CssSelector(ConfirmShipment2)).Click();

                    string ConfirmShipment3 = ConfigurationManager.AppSettings["ConfirmShipment3"].ToString();
                    ConfirmShipment3 = ConfigurationManager.AppSettings["ConfirmShipment3CSS"].ToString();
                    Thread.Sleep(threadDelay);
                    firefoxDriver.FindElement(By.CssSelector(ConfirmShipment3)).Click();
                }
                catch (Exception ex)
                {
                    log.Warn("Do not need to confirm shipment" +ex.ToString());
                }
            }

            //Save to DB
            SaveOrderToDB(amzOrders);

            //Refress datagridview
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = LoadOrderFromDB(cbUsers.SelectedText.ToString()).Tables[0];
        }

        private DataSet LoadOrderFromDB(string userName="")
        {
            //Load data from DB for selected users
            MySqlConnection conn;            
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
                log.Info("Cannot load data from DB. " + ex.Message);
                return null;
            }
        }

        private void UpdateToDB(int Id, string AliId, string AliCashAmount,string AliTrackingNumber, string Refund, bool isUpdateAli, bool isUpdateTracking, bool isUpdateRefund)
        {
            log.Info("Save data to DB. Id, AliId, AliCashAmount, AliTrackingNumber, Refund: " + Id.ToString()
                + ", " + AliId + ", " + AliCashAmount + ", " + AliTrackingNumber + ", " + Refund);

            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string updateCmd = "UPDATE Orders SET AliId=@AliId, AliDate=@AliDate, AliCashAmount=@AliCashAmount, AliTrackingNumber=@AliTrackingNumber, "
                + "AliTrackingDate=@AliTrackingDate, Refund=@Refund WHERE Id=@Id";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = updateCmd;
            cmd.Parameters.AddWithValue("@AliId", AliId.Trim());

            if (isUpdateAli)
                cmd.Parameters.AddWithValue("@AliDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            else
                cmd.Parameters.AddWithValue("@AliDate", "0000-00-00 00:00:00");

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
            
            cmd.Parameters.AddWithValue("@AliTrackingNumber", AliTrackingNumber.Trim());
            if (isUpdateTracking)
                cmd.Parameters.AddWithValue("@AliTrackingDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            else
                cmd.Parameters.AddWithValue("@AliTrackingDate", "0000-00-00 00:00:00");
            
            cmd.Parameters.AddWithValue("@Id", Id);
            try
            {
                cmd.ExecuteNonQuery();

                //Update status
                if(isUpdateAli || isUpdateTracking || isUpdateRefund)
                {
                    MySqlCommand newCmd = conn.CreateCommand();
                    newCmd.CommandText = "UPDATE Orders SET Status = @Status WHERE Id=@Id";
                    newCmd.Parameters.AddWithValue("@Id", Id);                    
                    if (isUpdateRefund)
                        newCmd.Parameters.AddWithValue("@Status", Status.Refund.ToString());
                    else if (isUpdateTracking)
                        newCmd.Parameters.AddWithValue("@Status", Status.Shipped.ToString());
                    else if (isUpdateAli)
                        newCmd.Parameters.AddWithValue("@Status", Status.Processed.ToString());
                    newCmd.ExecuteNonQuery();
                }
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
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            
            foreach (AmzOrder order in orders)
            {
                //Get map user account
                string amzAccount = "";
                foreach(var user in userMap.Users)
                {
                    if (user.FireFoxId == cbUsers.SelectedItem.ToString())
                    {
                        amzAccount = user.AmzUserId;
                        break;
                    }
                }

                //Save to Table Order: Clean data before saving
                string replacedString = order.PurchasedDate.Replace(" PDT", "");
                //@@TODO: Get Account Id from configuration file
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO Orders(AmzOrderId,AccountId, PurchasedDate, Country, ShipAddress, ShipPhone, Status) " +
                    "VALUES(@AmzOrderId, @AccountId, @PurchasedDate,@Country,@ShipAddress,@ShipPhone,@Status)";
                comm.Parameters.AddWithValue("@AmzOrderId", order.OrderId);
                comm.Parameters.AddWithValue("@AccountId", amzAccount);
                comm.Parameters.AddWithValue("@PurchasedDate", DateTime.Parse(replacedString));
                comm.Parameters.AddWithValue("@Country", order.Country);
                comm.Parameters.AddWithValue("@ShipAddress", order.ShipAddress);
                comm.Parameters.AddWithValue("@ShipPhone", order.ShipPhone);
                comm.Parameters.AddWithValue("@Status", "NewOrder");

                comm.ExecuteNonQuery();

                long newOrderId = comm.LastInsertedId;
                //Save Item to table Item
                foreach (AmzItem item in order.Items)
                {
                    MySqlCommand newComm = conn.CreateCommand();
                    newComm.CommandText = "INSERT INTO Items(OrderId,Image, Asin, Sku, Quantity, UnitPrice, SubTotal) " +
                    "VALUES(@OrderId, @Image, @Asin,@Sku,@Quantity,@UnitPrice,@SubTotal)";

                    newComm.Parameters.AddWithValue("@OrderId", newOrderId);
                    newComm.Parameters.AddWithValue("@Image", item.ImageUrl);
                    newComm.Parameters.AddWithValue("@Asin", item.Asin);
                    newComm.Parameters.AddWithValue("@Sku", item.Sku.Replace("SKU: ", ""));
                    newComm.Parameters.AddWithValue("@Quantity", item.Quantity);
                    newComm.Parameters.AddWithValue("@UnitPrice", decimal.Parse(item.UnitPrice.Remove(0,2), NumberStyles.Currency));
                    newComm.Parameters.AddWithValue("@SubTotal", decimal.Parse(item.SubTotal.Remove(0, 2), NumberStyles.Currency));

                    newComm.ExecuteNonQuery();
                }
            }

            conn.Close();
            conn.Dispose();
        }

        private string ConvertSkuToAliLink(string sku)
        {
            string result = "https://www.aliexpress.com/item/";
            long IdNumber;
            if (sku.Contains("-"))
            {
                string temp = sku.Split('-')[0];
                if (temp.Length >= 11)
                    IdNumber = long.Parse(temp.Substring(temp.Length - 11, 11)) - 1;
                else
                {
                    temp = sku.Split('-')[1];
                    IdNumber = long.Parse(temp.Substring(0, 11));
                }
            }
            else
            {
                IdNumber = long.Parse(sku.Substring(sku.Length - 11, 11)) - 1;
            }
            result += IdNumber.ToString() + ".html";
            return result;
        }

        private void BtnGetTracking_Click(object sender, EventArgs e)
        {
            //Get all order in status: Processed
            var strExpr = "Status = 'Processed'";
            var dv = LoadOrderFromDB().Tables[0].DefaultView;
            dv.RowFilter = strExpr;

            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://trade.aliexpress.com");

            string UserName = ConfigurationManager.AppSettings["UserName"];
            string Password = ConfigurationManager.AppSettings["Password"];
            string login = ConfigurationManager.AppSettings["NeedLogIn"];
            Thread.Sleep(threadDelay);
            if (login == "1")
            {
                IWebElement alibaba_login_box = driver.FindElement(By.Id("alibaba-login-box"));
                driver.SwitchTo().Frame(alibaba_login_box);

                driver.FindElement(By.Id("fm-login-id")).SendKeys(UserName);
                driver.FindElement(By.Id("fm-login-password")).SendKeys(Password);
                driver.FindElement(By.XPath("//*[@id='login-form']/div[5]/button")).Click();
                driver.SwitchTo().ParentFrame();
            }
            Thread.Sleep(threadDelay);

            foreach (DataRow row in dv.ToTable().Rows)
            {
                //IWebElement orderId = driver.FindElement(By.Id("//*[@id='order-no']"));
                IWebElement orderId = driver.FindElement(By.Name("orderListSearch"));
                driver.SwitchTo().Frame(orderId);
                driver.FindElement(By.Id("//*[@id='order-no']")).SendKeys(row["AliId"].ToString());
                //orderId.SendKeys(row["AliId"].ToString());
            }

        }

        private void BtnLoadOrder_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LoadOrderFromDB().Tables[0];
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
        [XmlAttribute("FireFoxId")]
        public string FireFoxId { get; set; }
        [XmlAttribute("AmzUserId")]
        public string AmzUserId { get; set; }
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
