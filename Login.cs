using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace FreelancerSystem
{
    public partial class Login_form : Form
    {
        private MySqlConnection connect;
        private string connectionstring;
        private void Login_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            connectionstring = "server=localhost;user id=root;password=;database=farcry;Convert Zero Datetime=True";
            connect = new MySqlConnection(connectionstring);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = textpassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Username and Password required!");
                return;
            }
            else
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionstring)) 
                    {
                        connection.Open();
                        string query = "SELECT username, password, FROM users WHERE username=@name AND password=@password";

                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@name", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string userType = reader["usertype"].ToString();

                                // Check the userType and redirect accordingly
                                if (userType == "Freelancer")
                                {
                                    // Redirect to Freelancer dashboard
                                    FreelancerDash freelancerForm = new FreelancerDash();
                                    freelancerForm.Show();
                                    this.Hide();

                                    MessageBox.Show("You are logged in as a freelancer!");
                                }
                                else if (userType == "Client")
                                {
                                    // Redirect to Client dashboard
                                    Clientdasboard clientForm = new Clientdasboard();
                                    clientForm.Show();
                                    this.Hide();    

                                    MessageBox.Show("You are logged in as a client!");
                                }
                                else
                                {
                                    MessageBox.Show("Invalid user type!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password!");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = !checkBox1.Checked;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void Username_leave(object sender, EventArgs e)
        {
            if (textpassword.Text == "")
            {
                textpassword.Text = "Username";
                textpassword.ForeColor = Color.DarkGray;
            }
        }
        private void UsernameClear(object sender, EventArgs e)
        {
            txtUsername.Text = "";
        }

        private void PasswordClear(object sender, EventArgs e)
        {
            textpassword.Text = "";
        }
       
        private void textBox1_enter(object sender, EventArgs e)
        {
            if (textpassword.Text == "Password")
            {
                textpassword.ForeColor = Color.Gray;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

