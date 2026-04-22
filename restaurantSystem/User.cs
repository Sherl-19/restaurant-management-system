
using MySql.Data.MySqlClient;
using Sitecore.FakeDb;
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
using System.Text;


namespace restaurantSystem
{
    

    public partial class User : Form
    { 
                MySqlConnection connection = new MySqlConnection("server=localhost;port=3308;username=root;password=;database=restaurant");

        

        public User()
        {
            InitializeComponent();
            this.txtPassword.AutoSize = false;
            this.txtPassword.Size = new Size(this.txtPassword.Size.Width, 20);
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                if (username == "" || password == "")
                {
                    MessageBox.Show("Please enter username and password");
                    return;
                }

                WebClient client = new WebClient();

                var data = new System.Collections.Specialized.NameValueCollection();
                data["username"] = username;
                data["password"] = password;

                byte[] response = client.UploadValues(
                    "http://localhost/FoodOrderingSystem-main/api/login.php",
                    data
                );

                string result = Encoding.UTF8.GetString(response).Trim();

                // DEBUG (pwede nimo tangtangon later)
                MessageBox.Show("Server Response: " + result);

                if (result == "success")
                {
                    string type = comboBox1.Text;

                    if (type == "Admin")
                    {
                        this.Hide();
                        new Main().Show();
                    }
                    else if (type == "Cashier")
                    {
                        this.Hide();
                        new Cashier().Show();
                    }
                    else if (type == "Chef")
                    {
                        this.Hide();
                        new Chef().Show();
                    }
                    else if (type == "Rider")
                    {
                        this.Hide();
                        new Rider().Show();
                    }
                    else if (type == "Waiter")
                    {
                        this.Hide();
                        new Waiter().Show();
                    }
                    else
                    {
                        MessageBox.Show("Select Role!");
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void labelGoToSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegisterForm registerform = new RegisterForm();
            registerform.Show();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {

            //        comboBox1.SelectedText.
            comboBox1.ForeColor = Color.Black;

        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {

            comboBox1.SelectionLength = 0;


                comboBox1.ForeColor = Color.Black;

           
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
           // MessageBox.Show(comboBox1.SelectedText, "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => { comboBox1.Select(0, 0); }));
        
        }

        private void comboBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           // MessageBox.Show(comboBox1.SelectedText, "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => { comboBox1.Select(0, 0); }));
        }

        private void comboBox1_DropDownStyleChanged(object sender, EventArgs e)
        {
       //     MessageBox.Show(comboBox1.SelectedText, "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void User_Load(object sender, EventArgs e)
        {

        }
    }
}
