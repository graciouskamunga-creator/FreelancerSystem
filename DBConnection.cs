using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Windows.Forms;

namespace FreelancerSystem
{
    public class DBConnection
    {
        private static DBConnection instance;
        private MySqlConnection connect;

        private DBConnection(string v)
        {
            connect = new MySqlConnection("server=localhost;username=root;database=farcry;user=root;password=");
        }

        public static DBConnection Instance
        {
            get
            {
                if (instance == null)
                {
                   
                }
                return instance;
            }
        }

        public MySqlConnection GetConnection
        {
            get { return connect; }
        }

        public void OpenConnection()
        {
            if (connect.State == System.Data.ConnectionState.Closed)
            {
                connect.Open();
            }
        }

        public void CloseConnection()
        {
            if (connect.State == System.Data.ConnectionState.Open)
            {
                connect.Close();
            }
        }
    }
}

