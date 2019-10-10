using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            getConnection();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-42NE200V\\SQLEXPRESS;Initial Catalog=stoktakip;Integrated Security=True;MultipleActiveResultSets=True");
        }
        public static OdbcConnection getConnection()
        {
            OdbcConnection con = new OdbcConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["Stok"].ConnectionString
            };
            return con;
        }
    }
}
