using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace FreelancerSystem
{
    public partial class Register : Form
    {
        string connString = "server=localhost;username=root;database=farcry;user=root;password=";
        public Register()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (btnLogin.Enabled == false)
            {
                btnLogin.Enabled = true;
            }
            else if (btnLogin.Enabled == true)
            {
                btnLogin.Enabled = false;
            }
            
            
        }

        private void textBox1_enter(object sender, EventArgs e)
        {
            if (txtname.Text == "Name")
            {
                txtname.ForeColor = Color.Gray;
            }
        }

        private void textBox2_enter(object sender, EventArgs e)
        {
            if (txtemail.Text == "Email")
            {
                txtemail.ForeColor = Color.Gray;
            }
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 cdb = new Form1();
            cdb.Show();
            this.Hide();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string name = txtname.Text.Trim();
            string email = txtemail.Text.Trim();
            string password = txtpassword.Text.Trim();
            string confirmPassword = txtconfirmPass.Text.Trim();

            if (name == "" && email == "" && password == "" && confirmPassword == "")
            {
                MessageBox.Show("All fields required!");
                return;
            }
            else if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match");
                return;
            }
            else
            {
                // Perf orm registration logics here

                try
                {
                    MySqlConnection conn = new MySqlConnection(connString);
                    using (conn)
                    {
                        conn.Open();
                        string query = "INSERT INTO client (username,email,password) values (@name, @email, @password)";

                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@name", name.ToLower());
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@email", email);

                        int status = cmd.ExecuteNonQuery();

                        if (status > 0)
                        {
                            MessageBox.Show("Account Created Successfully!");
                            Clientdasboard cdb = new Clientdasboard();
                            cdb.Show();
                            this.Hide();
                            conn.Close();
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void NameClear(object sender, EventArgs e)
        {
            txtname.Text = "";
        }

        private void emailClear(object sender, EventArgs e)
        {
            txtemail.Text = "";
        }

        private void PasswordClear(object sender, EventArgs e)
        {
            txtpassword.Text = "";
        }

        private void txtconfirmPass_Click(object sender, EventArgs e)
        {
            txtconfirmPass.Text = "";
        }

    }
}