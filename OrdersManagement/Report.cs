using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdersManagement
{
    public partial class Report : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string connectionString = ConfigurationManager.AppSettings["MySQLConnection"];
        DataTable totalTable;
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {            
            //Load data from DB for selected users
            MySqlConnection conn;
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                string query = "SELECT * FROM exchange";
                MySqlDataAdapter exchangeDataAdapter = new MySqlDataAdapter(query, conn);
                DataTable exchangeTable = new DataTable();
                exchangeDataAdapter.Fill(exchangeTable);

                tbCan2Usd.Text = exchangeTable.Rows[0].ItemArray[0].ToString();
                tbMex2Usd.Text = exchangeTable.Rows[0].ItemArray[1].ToString();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                log.Info("Cannot load data from exchange. " + ex.Message);
            }
            GetData();
            CalculateData();
            GetIssueOrders();
        }

        private void GetData()
        {
            //Load and calculate total data
            MySqlConnection conn = new MySqlConnection();
            try
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                string query = "SELECT orders.Id, orders.Country, COALESCE(SUM(items.SubTotal),0) AS Amz, ";
                query += "COALESCE(SUM(alitracks.AliCashAmount),0) AS Ali, COALESCE(SUM(orders.Refund) ,0) AS Refund";
                query += " FROM orders LEFT OUTER JOIN items ON orders.Id = items.OrderId";
                query += " LEFT OUTER JOIN alitracks ON orders.Id = alitracks.OrderId";
                query += " GROUP BY orders.Id, orders.Country";
                MySqlDataAdapter totalDataAdapter = new MySqlDataAdapter(query, conn);
                totalTable = new DataTable();
                totalDataAdapter.Fill(totalTable);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                log.Info("Cannot get total data. " + ex.Message);
            }
            conn.Close();
            conn.Dispose();
        }

        private void CalculateData()
        {
            if (totalTable == null || totalTable.Rows.Count == 0)
                return;
            double totalRefund = 0;
            double totalAli = 0;
            double totalAmz = 0;
            double can2Usd = 1;
            double mex2Usd = 1;
            try
            {
                can2Usd = double.Parse(tbCan2Usd.Text);
                mex2Usd = double.Parse(tbMex2Usd.Text);
            }
            catch { }

            foreach(DataRow row in totalTable.Rows)
            {
                try
                {
                    if (row["Country"].ToString().Contains(".ca"))
                    {
                        totalRefund += double.Parse(row["Refund"].ToString()) * can2Usd;
                        totalAli += double.Parse(row["Ali"].ToString()) * can2Usd;
                        totalAmz += double.Parse(row["Amz"].ToString()) * can2Usd;
                    }
                    else if (row["Country"].ToString().Contains(".mx"))
                    {
                        totalRefund += double.Parse(row["Refund"].ToString()) * mex2Usd;
                        totalAli += double.Parse(row["Ali"].ToString()) * mex2Usd;
                        totalAmz += double.Parse(row["Amz"].ToString()) * mex2Usd;
                    }
                    else
                    {
                        totalRefund += double.Parse(row["Refund"].ToString());
                        totalAli += double.Parse(row["Ali"].ToString());
                        totalAmz += double.Parse(row["Amz"].ToString());
                    }
                }
                catch(Exception ex)
                {
                    log.Error("Error in exchange money. " + ex.ToString());
                }
            }
            lbTotalAli.Text = "Total Ali: " + totalAli.ToString();
            lbTotalAmz.Text = "Total Amz: " + totalAmz.ToString();
            lbTotalRefund.Text = "Total Refund: " + totalRefund.ToString();

            double roiPercentage = double.Parse(ConfigurationManager.AppSettings["RoiPercentage"]);
            double roi = (totalAmz * roiPercentage - totalRefund) / totalAli;
            lbRoi.Text = "ROI: " + roi.ToString();
        }

        private void BtUpdate_Click(object sender, EventArgs e)
        {
            CalculateData();
            //Update Exchange rate
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = "UPDATE exchange SET Can2Usd=@Can2Usd, Mex2Usd=@Mex2Usd";

                comm.Parameters.AddWithValue("@Can2Usd", double.Parse(tbCan2Usd.Text.ToString()));
                comm.Parameters.AddWithValue("@Mex2Usd", double.Parse(tbMex2Usd.Text.ToString()));

                comm.ExecuteNonQuery();
                comm.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                log.Error("Update exchange error. " + ex.ToString());
                MessageBox.Show("Cannot update Exchange rate");
            }
        }

        private void GetIssueOrders()
        {
            string range = ConfigurationManager.AppSettings["ReportRange"];
            MySqlConnection conn = new MySqlConnection();
            try
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                string query = "SELECT * FROM orders WHERE Status = 'Processed' AND PurchasedDate < NOW() - Interval " + range + " DAY";
                MySqlDataAdapter orderDataAdapter = new MySqlDataAdapter(query, conn);
                DataTable orderTable = new DataTable();
                orderDataAdapter.Fill(orderTable);
                dataGridView1.DataSource = orderTable;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                log.Info("Cannot get order data. " + ex.Message);
            }
            conn.Close();
            conn.Dispose();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Clipboard.SetText(dataGridView1.CurrentCell.Value.ToString());
            }
            catch { }
        }
    }
}
