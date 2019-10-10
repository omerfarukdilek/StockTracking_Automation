using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace project
{
    public partial class Login : Form
    {
        public static string gonderilecekveri;
        public static int kullanici_id;
        public static SqlConnection baglanti;

        public Login()
        {
            InitializeComponent();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            if (kadi.Text != "" && ksifre.Text != "")
            {
                SqlCommand komut = new SqlCommand("Select * From kullanici Where kullanici_adi='" + kadi.Text 
                    + "' and kullanici_sifre='" + ksifre.Text + "'", baglanti);
                SqlDataReader oku = komut.ExecuteReader();

                if (oku.Read())
                {
                    gonderilecekveri = kadi.Text;
                    kullanici_id = Convert.ToInt32(oku["id"].ToString());
                    Main ss = new Main();
                    this.Hide();
                    ss.Show();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya Şifre Hatalı..");
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş olamaz!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["Stok"].ConnectionString;

            baglanti = new SqlConnection(connectionstring);
            baglanti.Open();

            ksifre.PasswordChar = '*';
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            baglanti.Close();
            Application.Exit();
        }

        private void kadi_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                btnGirisYap.PerformClick();
            }
        }

        private void ksifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnGirisYap.PerformClick();
            }
        }
    }
}
