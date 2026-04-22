using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;

namespace restaurantSystem
{
    public partial class Inbox : Form
    {
        public Inbox()
        {
            InitializeComponent();
        }

        private void back_btn_Click(object sender, EventArgs e)
        {

            this.Hide();
            Main main = new Main();
            main.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            inbox_table.DataSource = GetOrders();
        }

        private void inbox_table_CellContentClick(object sender, EventArgs e)
        {
         
            inbox_table.DataSource = GetOrders();
        }
        public DataTable GetOrders()
        {
            DBConnect db = new DBConnect();
            DataTable table = new DataTable();

            try
            {
                db.OpenConnection();

                string query = "SELECT uo.id, u.username, uo.title, uo.quantity, uo.price, uo.status, uo.date " +
                               "FROM users_orders uo " +
                               "JOIN users u ON uo.u_id = u.u_id " +
                               "WHERE uo.status = 'pending'";

                MySql.Data.MySqlClient.MySqlCommand cmd =
                    new MySql.Data.MySqlClient.MySqlCommand(query, db.GetConnection());

                MySql.Data.MySqlClient.MySqlDataAdapter adapter =
                    new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);

                adapter.Fill(table);

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return table;
        }
        
        private void Inbox_Load(object sender, EventArgs e)
        {
            inbox_table.AutoGenerateColumns = true;
            inbox_table.DataSource = GetPendingOrders();
            
        }
    
    public DataTable GetPendingOrders()
        {
            DataTable dt = new DataTable();

            try
            {
                WebClient client = new WebClient();

                string json = client.DownloadString(
                    "http://localhost/FoodOrderingSystem-main/api/get_pending.php"
                );

                var list = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);

                if (list != null && list.Count > 0)
                {
                    // create columns
                    foreach (var col in list[0].Keys)
                        dt.Columns.Add(col);

                    // add rows
                    foreach (var row in list)
                    {
                        DataRow dr = dt.NewRow();

                        foreach (var col in row)
                            dr[col.Key] = col.Value;

                        dt.Rows.Add(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("API Error: " + ex.Message);
            }

            return dt;
        }

        private void complete_btn_Click(object sender, EventArgs e)
        {
            if (inbox_table.CurrentRow != null)
            {
                string id = inbox_table.CurrentRow.Cells["id"].Value.ToString();

                try
                {
                    WebClient client = new WebClient();

                    var data = new System.Collections.Specialized.NameValueCollection();
                    data["id"] = id;

                    byte[] response = client.UploadValues(
                        "http://localhost/FoodOrderingSystem-main/api/update_status.php",
                        data
                    );

                    string result = Encoding.UTF8.GetString(response);

                    if (result == "success")
                    {
                        MessageBox.Show("Order Completed!");

                        // refresh inbox
                        inbox_table.DataSource = GetPendingOrders();
                    }
                    else
                    {
                        MessageBox.Show("Update failed");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
    

