using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FreelancerSystem
{
    public partial class Form1 : Form
    {
        private MySqlConnection connect;
        private string connectionString;
        public Form1()
        {
            InitializeComponent();
            connectionString = "server=localhost;user id=root;password=;database=farcry;Convert Zero Datetime=True";
            connect = new MySqlConnection(connectionString);
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
           
        }

        private bool Authenticateclient(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM client WHERE username = @username AND password = @password";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }

        private bool Authenticatefreelancer(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM freelancer WHERE username = @username AND password = @password";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.panel3.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.panel2.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.panel5.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.panel5.BringToFront();
        }

        private void btnLog_Click_1(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string password = txtpassword.Text;

            if (Authenticateclient(username, password))
            {
                MessageBox.Show("Login successful!");
                Clientdasboard cdb = new Clientdasboard();
                cdb.Show();
                this.Hide();
                // Here you can navigate to another form or perform other actions
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox2.Text;
            string password = textBox1.Text;

            if (Authenticatefreelancer(username, password))
            {
                MessageBox.Show("Login successful!");
                FreelancerDash freelancerForm = new FreelancerDash();
                freelancerForm.Show();
                this.Hide();
                // Here you can navigate to another form or perform other actions
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 cdb = new Form2();
            cdb.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register cdb = new Register();
            cdb.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}