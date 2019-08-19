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
using System.Diagnostics;

namespace OrdersManagement
{
    public partial class Form1 : Form
    {
        #region Global Variables
        public static IWebDriver firefoxDriver;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private int timeOut = 0;
        string connectionString = "";
        string profileName = "";
        int threadDelay;

        UsersType userMap;
        string link1 = "";
        string link2 = "";
        string link3 = "";
        string link4 = "";

        DataTable ordersTable;
        DataTable skuTable;
        private BindingSource orderBindingSource = new BindingSource();
        private MySqlDataAdapter orderDataAdapter = new MySqlDataAdapter();
        private BindingSource itemBindingSource = new BindingSource();
        private MySqlDataAdapter itemDataAdapter = new MySqlDataAdapter();
        private BindingSource AliBindingSource = new BindingSource();
        private MySqlDataAdapter AliDataAdapter = new MySqlDataAdapter();

        private BindingSource SkuBindingSource = new BindingSource();
        private MySqlDataAdapter SkuDataAdapter = new MySqlDataAdapter();


        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            log.Info("Start the program");

            userMap = LoadUsers();
            foreach (var status in Enum.GetNames(typeof(Status)).ToList())
            {
                cbbStatus.Items.Add(status);
            }
            foreach (var user in userMap.Users)
            {
                cbbAccount.Items.Add(user.AmzUserId);
            }

            timeOut = int.Parse(ConfigurationManager.AppSettings["TimeOutForWaiting"].ToString());
            connectionString = ConfigurationManager.AppSettings["MySQLConnection"];
            threadDelay = int.Parse(ConfigurationManager.AppSettings["DelayThread"].ToString());

            log.Info("Load order to view");
            GetOrdersFromDB();

            var x = (from r in ordersTable.AsEnumerable()
                     select r["Country"]).Distinct().ToArray();
            cbbCountry.Items.AddRange(x);

            cbbNote.Items.Add("Yes");
            cbbNote.Items.Add("No");

            LoadSkuToolStripMenuItem_Click(null, null);
        }

        private void GetOrdersFromDB()
        {
            //Load data from DB for selected users
            MySqlConnection conn;
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                string query = "SELECT * FROM orders";
                orderDataAdapter = new MySqlDataAdapter(query, conn);
                ordersTable = new DataTable();
                orderDataAdapter.Fill(ordersTable);
                orderBindingSource.DataSource = ordersTable;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                log.Info("Cannot load data from DB. " + ex.Message);
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lbAddress.Items.Clear();
            string[] address = dgvOrders.SelectedRows[0].Cells["ShipAddress"].Value.ToString().Split('\n');
            foreach (var add in address)
            {
                lbAddress.Items.Add(add);
            }

            string[] phones = dgvOrders.SelectedRows[0].Cells["ShipPhone"].Value.ToString().Split('\n');
            foreach (var phone in phones)
            {
                if (phone.Contains("ext"))
                {
                    string[] exts = phone.Split(new string[] { "ext" }, StringSplitOptions.None);

                    exts[0] = exts[0].Replace("-", "").Replace(" ", "");
                    exts[1] = exts[1].Replace("-", "").Replace(" ", "");

                    lbAddress.Items.Add(exts[0]);
                    lbAddress.Items.Add("ext " + exts[1]);
                }
                else
                    lbAddress.Items.Add(phone.Replace("-", "").Replace(" ", ""));
            }

            //Load images and link
            GetItemsByOrderId(dgvOrders.SelectedRows[0].Cells["Id"].Value.ToString());
            dgvItems.DataSource = itemBindingSource;
            GetAliTrackByOrderId(dgvOrders.SelectedRows[0].Cells["Id"].Value.ToString());
            dgvAli.DataSource = AliBindingSource;
            try
            {
                link1 = ConvertSkuToAliLink(dgvItems.Rows[0].Cells["Sku"].Value.ToString());
                pictureBox1.LoadAsync(dgvItems.Rows[0].Cells["Image"].Value.ToString());
                link2 = ConvertSkuToAliLink(dgvItems.Rows[1].Cells["Sku"].Value.ToString());
                pictureBox2.LoadAsync(dgvItems.Rows[1].Cells["Image"].Value.ToString());
                link3 = ConvertSkuToAliLink(dgvItems.Rows[2].Cells["Sku"].Value.ToString());
                pictureBox3.LoadAsync(dgvItems.Rows[2].Cells["Image"].Value.ToString());
                link4 = ConvertSkuToAliLink(dgvItems.Rows[3].Cells["Sku"].Value.ToString());
                pictureBox4.LoadAsync(dgvItems.Rows[3].Cells["Image"].Value.ToString());
            }
            catch (Exception ex)
            {
                log.Warn("Loading image. Ex:" + ex.ToString());
            }
        }

        private void SaveOrderToDB(List<AmzOrder> orders)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            foreach (AmzOrder order in orders)
            {
                //Get map user account
                string amzAccount = "";
                foreach (var user in userMap.Users)
                {
                    if (user.FireFoxId == profileName)
                    {
                        amzAccount = user.AmzUserId;
                        break;
                    }
                }

                //Save to Table Order: Clean data before saving
                string replacedString = order.PurchasedDate.Replace(" PDT", "");
                //@@TODO: Get Account Id from configuration file
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO orders(AmzOrderId,AccountId, PurchasedDate, Country, ShipAddress, ShipPhone, Status) " +
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
                    newComm.CommandText = "INSERT INTO items(OrderId,Image, Asin, Sku, Quantity, UnitPrice, SubTotal) " +
                    "VALUES(@OrderId, @Image, @Asin,@Sku,@Quantity,@UnitPrice,@SubTotal)";

                    newComm.Parameters.AddWithValue("@OrderId", newOrderId);
                    newComm.Parameters.AddWithValue("@Image", item.ImageUrl);
                    newComm.Parameters.AddWithValue("@Asin", item.Asin);
                    newComm.Parameters.AddWithValue("@Sku", item.Sku.Replace("SKU: ", ""));
                    newComm.Parameters.AddWithValue("@Quantity", item.Quantity);
                    newComm.Parameters.AddWithValue("@UnitPrice", decimal.Parse(item.UnitPrice.Remove(0, 2), NumberStyles.Currency));
                    newComm.Parameters.AddWithValue("@SubTotal", decimal.Parse(item.SubTotal.Remove(0, 2), NumberStyles.Currency));

                    newComm.ExecuteNonQuery();
                }
            }

            conn.Close();
            conn.Dispose();
        }

        private string ConvertSkuToAliLink(string sku)
        {
            if (skuTable != null)
                foreach (DataRow row in skuTable.Rows)
                {
                    if (row["Sku"].ToString() == sku)
                        return row["Link"].ToString();
                }
            string result = "https://www.aliexpress.com/item/";
            long IdNumber;
            if (sku.Contains("-"))
            {
                string temp = sku.Split('-')[0];
                if (temp.Length >= 11)
                {
                    if (sku.Substring(0, 8) == "JH060819")
                        IdNumber = long.Parse(sku.Substring(sku.Length - 11, 11));
                    else
                        IdNumber = long.Parse(temp.Substring(temp.Length - 11, 11)) - 1;
                }
                else
                {
                    temp = sku.Split('-')[1];
                    IdNumber = long.Parse(temp);
                }
            }
            else
            {
                if (sku.Substring(0, 8) == "JH060819")
                    IdNumber = long.Parse(sku.Substring(sku.Length - 11, 11));
                else
                    IdNumber = long.Parse(sku.Substring(sku.Length - 11, 11)) - 1;
            }
            result += IdNumber.ToString() + ".html";
            return result;
        }

        private void SaveTrackingNumberToDB(List<TrackingInfos> infors)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            foreach (var infor in infors)
            {
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = "UPDATE alitracks SET AliCashAmount=@AliCashAmount,AliTrackingNumber=@AliTrackingNumber, AliTrackingDate=@AliTrackingDate WHERE Id=@Id";

                comm.Parameters.AddWithValue("@Id", infor.TrackingId);
                comm.Parameters.AddWithValue("@AliTrackingNumber", infor.TrackingNumber);
                comm.Parameters.AddWithValue("@AliTrackingDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                comm.Parameters.AddWithValue("@AliCashAmount", infor.AliAmount);
                comm.ExecuteNonQuery();

                MySqlCommand orderComm = conn.CreateCommand();
                orderComm.CommandText = "UPDATE orders SET Status=@Status WHERE Id=@Id";

                orderComm.Parameters.AddWithValue("@Id", infor.OrderId);
                orderComm.Parameters.AddWithValue("@Status", Status.Shipped.ToString());
                orderComm.ExecuteNonQuery();
            }

            conn.Close();
            conn.Dispose();
        }

        private void UpdateStatusToFinished(List<string> Ids)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            foreach (string id in Ids)
            {
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = "UPDATE orders SET Status = @Status WHERE Id=@Id";

                comm.Parameters.AddWithValue("@Id", id);
                comm.Parameters.AddWithValue("@Status", Status.Finished.ToString());
                comm.ExecuteNonQuery();
            }

            conn.Close();
            conn.Dispose();
        }

        private void GetItemsByOrderId(string orderId)
        {
            //Load data from DB for selected users
            using (MySqlConnection conn = new MySqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;
                    conn.Open();
                    string query = "SELECT * FROM items WHERE OrderId = '" + orderId + "'";
                    itemDataAdapter = new MySqlDataAdapter(query, conn);
                    DataTable data = new DataTable();
                    itemDataAdapter.Fill(data);
                    itemBindingSource.DataSource = data;
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    log.Info("Cannot load data from DB. " + ex.Message);
                }
            }
        }

        private void GetAliTrackByOrderId(string orderId)
        {
            //Load data from DB for selected users
            using (MySqlConnection conn = new MySqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;
                    conn.Open();
                    string query = "SELECT * FROM alitracks WHERE OrderId = '" + orderId + "'";
                    AliDataAdapter = new MySqlDataAdapter(query, conn);
                    DataTable data = new DataTable();
                    AliDataAdapter.Fill(data);
                    AliBindingSource.DataSource = data;
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    log.Info("Cannot load data from DB. " + ex.Message);
                }
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(link1) && !string.IsNullOrEmpty(link1))
                Process.Start(link1);
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(link2) && !string.IsNullOrEmpty(link2))
                Process.Start(link2);
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(link3) && !string.IsNullOrEmpty(link3))
                Process.Start(link3);
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(link4) && !string.IsNullOrEmpty(link4))
                Process.Start(link4);
        }

        private void LbAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(lbAddress.SelectedItem.ToString());
            }
            catch { }
        }

        private void GetAmazonOrdersToolStripMenuItem_Click(object sender, EventArgs e)
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
                    //Check have buy shipment or not ?
                    string ConfirmShipment = "";
                    int numberButton = int.Parse(ConfigurationManager.AppSettings["NoButtons"].ToString());
                    bool isHaveBuyShipment = false;
                    if (firefoxDriver.FindElements(By.ClassName("a-button-input")).Count > numberButton)
                        isHaveBuyShipment = true;
                    if (isHaveBuyShipment)
                        ConfirmShipment = ConfigurationManager.AppSettings["ConfirmShipmentInCaseBuyShipmentCSS"].ToString();
                    else
                        ConfirmShipment = ConfigurationManager.AppSettings["ConfirmShipmentCSS"].ToString();
                    //firefoxDriver.FindElement(By.XPath(ConfirmShipment)).Click();
                    firefoxDriver.FindElement(By.CssSelector(ConfirmShipment)).Click();

                    string ConfirmShipment2 = ConfigurationManager.AppSettings["ConfirmShipment2"].ToString();
                    Thread.Sleep(threadDelay);
                    if (isHaveBuyShipment)
                        firefoxDriver.FindElements(By.ClassName("a-button-input"))[6].Click();
                    else
                        firefoxDriver.FindElements(By.ClassName("a-button-input"))[5].Click();
                    //firefoxDriver.FindElement(By.CssSelector(ConfirmShipment2)).Click();

                    string ConfirmShipment3 = ConfigurationManager.AppSettings["ConfirmShipment3"].ToString();
                    ConfirmShipment3 = ConfigurationManager.AppSettings["ConfirmShipment3CSS"].ToString();
                    Thread.Sleep(threadDelay);
                    firefoxDriver.FindElement(By.CssSelector(ConfirmShipment3)).Click();
                }
                catch (Exception ex)
                {
                    log.Warn("Do not need to confirm shipment" + ex.ToString());
                }
            }

            //Save to DB
            SaveOrderToDB(amzOrders);

            //Refress datagridview
            //dgvOrders.DataSource = null;
            //dgvOrders.DataSource = ordersTable;
            MessageBox.Show("Finish get Amazon Orders");
            GetOrdersFromDB();
        }

        private void GetAliTrackingNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable trackingInfo = GetTrackingInfo("Processed");

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

            Dictionary<string, string> AliTrackingList = new Dictionary<string, string>();
            Dictionary<string, decimal> AliTrackingListAmount = new Dictionary<string, decimal>();
            List<TrackingInfos> trackingList = new List<TrackingInfos>();
            foreach (DataRow row in trackingInfo.Rows)
            {
                driver.Navigate().GoToUrl("https://trade.aliexpress.com");
                Thread.Sleep(threadDelay);

                IWebElement orderId = driver.FindElement(By.Id("order-no"));
                orderId.SendKeys(row["AliId"].ToString());
                driver.FindElement(By.Id("search-btn")).Click();

                string AliStatusXpath = ConfigurationManager.AppSettings["AliStatusXPath"];
                string status = driver.FindElement(By.XPath(AliStatusXpath)).Text;
                if (status == "Awaiting delivery")
                {
                    TrackingInfos infor = new TrackingInfos();
                    infor.OrderId = int.Parse(row["OrderId"].ToString());
                    infor.TrackingId = int.Parse(row["Id"].ToString());

                    string AliTotalAmountXpath = ConfigurationManager.AppSettings["AliTotalAmount"];
                    string totalAmountString = driver.FindElement(By.XPath(AliTotalAmountXpath)).Text;
                    infor.AliAmount = decimal.Parse(totalAmountString.Remove(0, 2), NumberStyles.Currency);

                    string AliOrderDetail = ConfigurationManager.AppSettings["AliOrderDetail"];
                    driver.Navigate().GoToUrl(AliOrderDetail + row["AliId"].ToString());
                    Thread.Sleep(threadDelay);

                    string AliTrackingNumberXpath = ConfigurationManager.AppSettings["AliTrackingNumberXpath"];
                    infor.TrackingNumber = driver.FindElement(By.XPath(AliTrackingNumberXpath)).Text;
                    trackingList.Add(infor);
                }
            }
            //Save tracking number to DB
            SaveTrackingNumberToDB(trackingList);

            MessageBox.Show("Finish get Ali Tracking Number");
            GetOrdersFromDB();
        }

        private void FillTrackingNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Get map user account
            string amzAccount = "";
            foreach (var user in userMap.Users)
            {
                if (user.FireFoxId == profileName)
                {
                    amzAccount = user.AmzUserId;
                    break;
                }
            }
            DataTable data = GetTrackingInfo("Shipped", amzAccount);

            firefoxDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOut);
            string AmzOrderURL = ConfigurationManager.AppSettings["AmzOrderURL"];
            List<string> Ids = new List<string>();
            foreach (DataRow row in data.Rows)
            {
                firefoxDriver.Navigate().GoToUrl(AmzOrderURL + row["AmzOrderId"].ToString());
                Thread.Sleep(threadDelay);
                string EditShipmentCSS = ConfigurationManager.AppSettings["EditShipmentCSS"].ToString();
                firefoxDriver.FindElement(By.CssSelector(EditShipmentCSS)).Click();

                Thread.Sleep(threadDelay);

                string AmzTrackingNumber = ConfigurationManager.AppSettings["AmzTrackingNumber"].ToString();
                firefoxDriver.FindElement(By.XPath(AmzTrackingNumber)).SendKeys(row["AliTrackingNumber"].ToString());

                string EditShipmentConfirm = ConfigurationManager.AppSettings["EditShipmentConfirm"].ToString();
                firefoxDriver.FindElement(By.XPath(EditShipmentConfirm)).Click();

                Ids.Add(row["OrderId"].ToString());
            }

            //Update status to Finished
            UpdateStatusToFinished(Ids);

            MessageBox.Show("Finish Fill Tracking Number");
            GetOrdersFromDB();
        }

        private void LoadOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvOrders.DataSource = orderBindingSource;
        }

        private void LoadProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log.Info("Start load user profile");
            string profilesFolder = ConfigurationManager.AppSettings["FireFoxProfiles"];
            string firefoxProfile = "";
            try
            {
                using (var form = new LoadProfiles())
                {
                    form.ShowDialog();
                    profileName = form.selectedProfile;
                }
            }
            catch(Exception ex) { }
            foreach (string fprofile in Directory.GetDirectories(profilesFolder))
            {
                if (fprofile.Contains(profileName))
                {
                    firefoxProfile = fprofile;
                    break;
                }
            }
            FirefoxProfile profile = new FirefoxProfile(firefoxProfile);
            FirefoxOptions opt = new FirefoxOptions();
            opt.Profile = profile;

            firefoxDriver = new FirefoxDriver(opt);

            log.Info("Finish load user profile");
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //Load data from DB for selected users
            MySqlConnection conn;
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                string query = "SELECT * FROM orders WHERE 1=1 ";

                //Add filter condition:
                //Trade date: less than
                if (!string.IsNullOrEmpty(tbSearchTradeDate.Text.ToString()) && !string.IsNullOrWhiteSpace(tbSearchTradeDate.Text.ToString()))
                {
                    query = "SELECT orders.* FROM orders INNER JOIN alitracks ON orders.Id = alitracks.OrderId WHERE ";
                    DateTime searchDate = DateTime.Now;
                    int range = 0 - int.Parse(tbSearchTradeDate.Text.ToString());
                    searchDate = searchDate.AddDays(range);
                    query += " alitracks.AliTrackingDate >='" + searchDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                }

                //Status
                if (cbbStatus.SelectedIndex > -1)
                    query += " AND orders.Status = '" + cbbStatus.SelectedItem.ToString() + "'";
                //Country
                if (cbbCountry.SelectedIndex > -1)
                    query += " AND orders.Country = '" + cbbCountry.SelectedItem.ToString() + "'";
                //AccountId
                if (cbbAccount.SelectedIndex > -1)
                    query += " AND orders.AccountId = '" + cbbAccount.SelectedItem.ToString() + "'";
                //Note: have or not
                if (cbbNote.SelectedIndex > -1)
                {
                    if (cbbNote.SelectedItem.ToString() == "Yes")
                        query += " AND orders.Note is not null";
                    else
                        query += " AND orders.Note is null";
                }
                //Amz Order Id: like
                if (!string.IsNullOrEmpty(tbSearchOrderId.Text.ToString()) && !string.IsNullOrWhiteSpace(tbSearchOrderId.Text.ToString()))
                    query += " AND orders.AmzOrderId like '%" + tbSearchOrderId.Text.ToString() + "%'";

                orderDataAdapter = new MySqlDataAdapter(query, conn);
                ordersTable = new DataTable();
                orderDataAdapter.Fill(ordersTable);
                orderBindingSource.DataSource = ordersTable;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                log.Info("Cannot load data from DB. " + ex.Message);
            }
        }


        #region MetaData

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
            NewOrder = 0,
            Processed = 1,
            Shipped = 2,
            Finished = 3,
            Refund = 4
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

        public struct TrackingInfos
        {
            public int OrderId;
            public int TrackingId;
            public decimal AliAmount;
            public string TrackingNumber;
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
        #endregion

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            orderDataAdapter.Update((DataTable)orderBindingSource.DataSource);
            itemDataAdapter.Update((DataTable)itemBindingSource.DataSource);
            AliDataAdapter.Update((DataTable)AliBindingSource.DataSource);
            SkuDataAdapter.Update((DataTable)SkuBindingSource.DataSource);
        }

        private void BtnAddAliInfo_Click(object sender, EventArgs e)
        {
            try
            {
                //Add ali tracking info
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();

                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO alitracks(OrderId,AliId, AliDate, AliCashAmount) " +
                    "VALUES(@OrderId, @AliId, @AliDate,@AliCashAmount)";

                comm.Parameters.AddWithValue("@OrderId", dgvOrders.SelectedRows[0].Cells["Id"].Value.ToString());
                comm.Parameters.AddWithValue("@AliId", tbAliId.Text.ToString());
                comm.Parameters.AddWithValue("@AliDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                comm.Parameters.AddWithValue("@AliCashAmount", tbAliCashAmount.Text);

                comm.ExecuteNonQuery();
                comm.Dispose();

                //Update Order Status
                MySqlCommand newCmd = conn.CreateCommand();
                newCmd.CommandText = "UPDATE orders SET status = @Status WHERE Id=@OrderId";
                newCmd.Parameters.AddWithValue("@OrderId", dgvOrders.SelectedRows[0].Cells["Id"].Value.ToString());
                newCmd.Parameters.AddWithValue("@Status", Status.Processed.ToString());
                newCmd.ExecuteNonQuery();

                conn.Close();
                newCmd.Dispose();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                log.Error("Add AliId to DB error. " + ex.ToString());
            }
        }

        private void BtResetSearch_Click(object sender, EventArgs e)
        {
            cbbStatus.SelectedIndex = -1;
            cbbAccount.SelectedIndex = -1;
            cbbCountry.SelectedIndex = -1;
            cbbNote.SelectedIndex = -1;

            tbSearchOrderId.Text = "";
            tbSearchTradeDate.Text = "";

            BtnSearch_Click(null, null);
        }

        private void LoadSkuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Load data from DB for selected users
            MySqlConnection conn;
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                string query = "SELECT * FROM skuToLink";
                SkuDataAdapter = new MySqlDataAdapter(query, conn);
                skuTable = new DataTable();
                SkuDataAdapter.Fill(skuTable);
                SkuBindingSource.DataSource = skuTable;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                log.Info("Cannot load Sku from DB. " + ex.Message);
            }
        }

        private void btAddSkuLink_Click(object sender, EventArgs e)
        {
            try
            {
                //Add ali tracking info
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();

                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO skuToLink(Sku,Link) " +
                    "VALUES(@Sku, @Link)";

                comm.Parameters.AddWithValue("@Sku", dgvItems.SelectedRows[0].Cells["Sku"].Value.ToString());
                comm.Parameters.AddWithValue("@Link", tbSkuLink.Text.ToString());

                comm.ExecuteNonQuery();
                comm.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                log.Error("Add AliId to DB error. " + ex.ToString());
            }
        }

        private DataTable GetTrackingInfo(string status, string userName = "")
        {
            //Load data from DB for selected users
            MySqlConnection conn;
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                string query = "SELECT * FROM alitracks INNER JOIN orders ON alitracks.OrderId = orders.Id WHERE orders.Status = '" + status + "'";
                if (!string.IsNullOrEmpty(userName) && !string.IsNullOrWhiteSpace(userName))
                {
                    query += " AND orders.AccountId = '" + userName + "'";
                }
                MySqlDataAdapter trackingDataAdapter = new MySqlDataAdapter(query, conn);
                DataTable trackingTable = new DataTable();
                trackingDataAdapter.Fill(trackingTable);
                return trackingTable;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                log.Info("Cannot load Tracking from DB. " + ex.Message);
                return null;
            }
        }
    }
}
