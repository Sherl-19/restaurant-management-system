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
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main main = new Main();
            main.Show();

        }

        private void Order_Load_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Order_Load.DataSource = GetOrders();
            Order_Load.DataSource = GetOrdersFromAPI();
            Order_Load.AutoGenerateColumns = true;
            Order_Load.DataSource = GetOrdersFromAPI();
            Order_Load.Refresh();
        }
        public DataTable GetOrders()
        {
            DBConnect db = new DBConnect();
            DataTable table = new DataTable();

            try
            {
                db.OpenConnection();

                string query = "SELECT id, u_id, title, quantity, price, status, date FROM users_orders";

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
        public DataTable GetOrdersFromAPI()
        {
            DataTable dt = new DataTable();

            try
            {
                WebClient client = new WebClient();

                string json = client.DownloadString(
                    "http://localhost/FoodOrderingSystem-main/api/get_orders.php"
                );

                dt = JsonConvert.DeserializeObject<DataTable>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dt;
        }
        private void update_btn_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();

            if (Order_Load.CurrentRow != null)
            {
                int id = Convert.ToInt32(Order_Load.CurrentRow.Cells["id"].Value);

                try
                {
                    db.OpenConnection();

                    string query = "UPDATE users_orders SET status='completed' WHERE id=@id";

                    MySql.Data.MySqlClient.MySqlCommand cmd =
                        new MySql.Data.MySqlClient.MySqlCommand(query, db.GetConnection());

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    db.CloseConnection();

                    MessageBox.Show("Order updated!");

                   Order_Load.DataSource = GetOrders();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Order_Load_1(object sender, EventArgs e)
        {
            Order_Load.DataSource = GetOrders();
            Order_Load.DataSource = GetOrdersFromAPI();
            Order_Load.AutoGenerateColumns = true;
            Order_Load.DataSource = GetOrdersFromAPI();
            Order_Load.Refresh();
        }
    }
}
