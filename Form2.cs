using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FreelancerSystem
{
    public partial class Form2 : Form
    {
        string connString = "server=localhost;username=root;database=farcry;user=root;password=";
        public Form2()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
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
                        string query = "INSERT INTO freelancer (username,email,password) values (@name, @email, @password)";

                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@name", name.ToLower());
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@email", email);

                        int status = cmd.ExecuteNonQuery();

                        if (status > 0)
                        {
                            MessageBox.Show("Account Created Successfully!");
                            FreelancerDash cdb = new FreelancerDash();
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 cdb = new Form1();
            cdb.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
