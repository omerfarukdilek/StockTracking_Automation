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
using System.Data.OleDb;

namespace project
{
    public partial class Main : Form
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;

        int urunId = 0;

        public Main()
        {
            InitializeComponent();
        }

        private void btnUrunListele_Click(object sender, EventArgs e)
        {
            tabloDoldur(false, null);
        }

        private void btnUrunGuncelle_Click(object sender, EventArgs e)
        {
          
            if (urunId > 0 && dataGridView1.SelectedRows.Count != 0)
            {
                int kategoriId = comboBox1.SelectedIndex;

                SqlCommand komut = new SqlCommand("update urun  set urun_adi = @Urun_Adi,kategori_id = @Kategori_Id,urun_kodu = @Urun_Kodu,urun_adet = @Urun_Adet,fiyat = @Fiyat where id = @Id", Login.baglanti);

                komut.Parameters.AddWithValue("@Id", urunId);
                komut.Parameters.AddWithValue("@Urun_Adi", textBox1.Text);
                komut.Parameters.AddWithValue("@Kategori_Id", kategoriId);
                komut.Parameters.AddWithValue("@Urun_Kodu", textBox2.Text);
                komut.Parameters.AddWithValue("@Urun_Adet", textBox3.Text);
                komut.Parameters.AddWithValue("@Fiyat", textBox4.Text.Replace(",", "."));

                komut.ExecuteNonQuery();

                scb = new SqlCommandBuilder(sda);
                sda.Update(dt);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                comboBox1.SelectedIndex = 0;
                tabloDoldur(false, null);
            }

            else
            {
                MessageBox.Show("Ürün seçiniz!", "Uyarı");
            }


        }

        private void Main_Load(object sender, EventArgs e)
        {
            textBox5.Text = Login.gonderilecekveri;

            dataGridView1.ReadOnly = true;
            tabloDoldur(false, null);

            SqlCommand komut = new SqlCommand("SELECT * FROM kategori", Login.baglanti);

            SqlDataReader dr;

            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                string kategori = dr["kategori_adi"].ToString();
                comboBox1.Items.Add(kategori);
                satis_uruntur.Items.Add(kategori);
                alis_uruntur.Items.Add(kategori);
            }

            try
            {
                string secilikategori = dataGridView1.SelectedRows[0].Cells["kategori_adi"].Value.ToString();
                comboBox1.SelectedIndex = comboBox1.FindString(secilikategori);
            }
            catch (Exception)
            {
            }
            
            kullanicitablodoldur();
        }

        private void btnUrunCikis_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
            // programdan çıkış yap
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            int kullanici_id = Login.kullanici_id;


            if (string.IsNullOrEmpty(textBox1.Text) || comboBox1.SelectedIndex == 0 || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Ürün bilgilerini doldurunuz !", "Uyarı");
            }
            else
            {
                SqlCommand komut = new SqlCommand("insert into urun (urun_adi,kategori_id,urun_kodu,urun_adet,kullanici_id,tarih,fiyat) values('" + textBox1.Text.ToString() + "','" + comboBox1.SelectedIndex + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + kullanici_id + "','" + dateTimePicker1.Value.ToString("M/d/yyyy") + "','" + textBox4.Text.ToString() + "')", Login.baglanti);
                komut.ExecuteNonQuery();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                comboBox1.SelectedIndex = 0;
                tabloDoldur(false, null);
            }
        }

        private void BtnUrunSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["id"].Value);


                SqlCommand komut = new SqlCommand("Delete From urun where id=(" + id + ")", Login.baglanti);
                komut.ExecuteNonQuery();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                comboBox1.SelectedIndex = 0;

                tabloDoldur(false, null);
            }
            else
            {
                MessageBox.Show("Ürün seçiniz!", "Uyarı");
            }

        }

        public void tabloDoldur(bool isSearch, string keyword)
        {
            int kullanici_id = Login.kullanici_id;

            string query = "Select u.id,u.urun_adi,k.kategori_adi,u.urun_kodu,u.urun_adet,kul.adsoyad,u.tarih,u.fiyat  From urun as u INNER JOIN kullanici as kul ON u.kullanici_id = kul.id INNER JOIN kategori as k on k.id=u.kategori_id ";
            if (isSearch)
            {
                query += " and  (u.urun_adi LIKE '" + keyword + "%' or u.urun_kodu LIKE '" + keyword + "%')";
            }

            sda = new SqlDataAdapter(query, Login.baglanti);

            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count != 0)
                {
                    DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                    if (row.Cells["id"].Value.ToString() != "")
                    {
                        urunId = Convert.ToInt32(row.Cells["id"].Value);
                        textBox1.Text = row.Cells["urun_adi"].Value.ToString();
                        comboBox1.SelectedItem = row.Cells["kategori_adi"].Value.ToString();
                        textBox2.Text = row.Cells["urun_kodu"].Value.ToString();
                        textBox3.Text = row.Cells["urun_adet"].Value.ToString();
                        Convert.ToDateTime(dateTimePicker1.Value.ToString());
                        textBox4.Text = row.Cells["fiyat"].Value.ToString();
                        dateTimePicker1.Enabled = false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnKullaniciCikis_Click(object sender, EventArgs e)
        {

            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            if(textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
            {
                SqlCommand komut = new SqlCommand("insert into kullanici (adsoyad,kullanici_adi,kullanici_sifre) values('" + textBox7.Text.ToString() + "','" + textBox8.Text.ToString() + "','" + textBox9.Text.ToString() + "')", Login.baglanti);
                komut.ExecuteNonQuery();
                kullanicitablodoldur();
            }

            else
            {
                MessageBox.Show("Kullanıcı bilgilerini doldurunuz!", "Uyarı");
            }

        }

        private void btnKullaniciListele_Click(object sender, EventArgs e)
        {
            kullanicitablodoldur();
        }

        private void btnKullaniciSil_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dataGridView2.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["id"].Value);

                SqlCommand komut = new SqlCommand("Delete From kullanici where id=(" + id + ")", Login.baglanti);
                komut.ExecuteNonQuery();

                kullanicitablodoldur();
            }
            else
            {
                MessageBox.Show("Kullanıcı seçiniz!", "Uyarı");
            }

        }

        private void btnUrunAra_Click(object sender, EventArgs e)
        {
            string keyword = textBox10.Text;

            if (!string.IsNullOrEmpty(keyword))
            {
                tabloDoldur(true, keyword);
            }
            else
            {
                int kullanici_id = Login.kullanici_id;
           
                sda = new SqlDataAdapter("Select u.id,u.urun_adi,k.kategori_adi,u.urun_kodu,u.urun_adet,kul.adsoyad,u.tarih,u.fiyat  From urun as u INNER JOIN kullanici as kul ON u.kullanici_id = kul.id INNER JOIN kategori as k on k.id=u.kategori_id ", Login.baglanti);

                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (satis_urunad.Text == "" || satis_urunadet.Text == "")
            {
                MessageBox.Show("Ürün bilgilerini doğru doldurunuz !", "Uyarı");
            }
            else
            {
                SqlCommand command = new SqlCommand("select urun_adet from urun where urun_adi like '" + satis_urunad.Text + "'", Login.baglanti);
                SqlDataReader reader = command.ExecuteReader();

                int urunadedi;

                if (reader.Read())
                {
                    urunadedi = reader.GetInt32(0);

                    int sattiktansonraadet = urunadedi - Convert.ToInt32(satis_urunadet.Text);

                    if (sattiktansonraadet >= 0)
                    {
                        urunadedi = sattiktansonraadet;
                        command = new SqlCommand("update urun set urun_adet = " + urunadedi + " where urun_adi like '" + satis_urunad.Text + "'", Login.baglanti);
                        command.ExecuteNonQuery();

                        satis_urunadet.Text = "";
                        satis_uruntur.SelectedIndex = -1;
                        satis_urunad.SelectedIndex = -1;

                        MessageBox.Show("Ürün satıldı.");

                        tabloDoldur(false, null);
                    }
                    else
                    {
                        MessageBox.Show("Satış yapılamıyor. Kalan ürün adedi " + urunadedi);
                    }
                }
            }
        }
        
        private void alis_uruntur_SelectedIndexChanged(object sender, EventArgs e)
        {
            alis_urunadi.Items.Clear();
            alis_urunadi.Text = ""; 

            SqlCommand command = new SqlCommand("select urun.urun_adi from urun join kategori on urun.kategori_id = kategori.id where kategori.kategori_adi = '" + alis_uruntur.Text + "'", Login.baglanti);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                alis_urunadi.Items.Add(reader.GetString(0));
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (alis_urunadi.Text == "" || alis_urunadet.Text == "")
            {
                MessageBox.Show("Ürün bilgilerini doğru doldurunuz !", "Uyarı");
            }
            else
            {
                SqlCommand command = new SqlCommand("select urun_adet from urun where urun_adi like '" + alis_urunadi.Text + "'", Login.baglanti);             
                SqlDataReader reader = command.ExecuteReader();

                int urunadedi = 0;

                while (reader.Read())
                {
                    urunadedi = reader.GetInt32(0);
                }

                urunadedi = urunadedi + Convert.ToInt32(alis_urunadet.Text);

                command = new SqlCommand("update urun set urun_adet = " + urunadedi + " where urun_adi like '" + alis_urunadi.Text + "'", Login.baglanti);
                command.ExecuteNonQuery();

                alis_urunadet.Text = "";
                alis_uruntur.SelectedIndex = -1;
                alis_urunadi.SelectedIndex = -1;

                MessageBox.Show("Ürün alındı.");

                tabloDoldur(false, null);
            }
        }

        private void btnKullaniciGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dataGridView2.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["id"].Value);
                SqlCommand komut = new SqlCommand("update kullanici set adsoyad = @adsoyad, kullanici_adi = @kullanici_adi, kullanici_sifre = @kullanici_sifre where id = @Id", Login.baglanti);
                komut.Parameters.AddWithValue("@Id", id);
                komut.Parameters.AddWithValue("@adsoyad", textBox7.Text);
                komut.Parameters.AddWithValue("@kullanici_adi", textBox8.Text);
                komut.Parameters.AddWithValue("@kullanici_sifre", textBox9.Text);
              
                komut.ExecuteNonQuery();
              
                kullanicitablodoldur();
            }

            else
            {
                MessageBox.Show("Kullanıcı seçiniz!", "Uyarı");
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.SelectedRows.Count != 0)
                {
                    DataGridViewRow row = this.dataGridView2.SelectedRows[0];
                    if (row.Cells["id"].Value.ToString() != "")
                    {
                        textBox7.Text = row.Cells["adsoyad"].Value.ToString();
                        textBox8.Text = row.Cells["kullanici_adi"].Value.ToString();
                        textBox9.Text = row.Cells["kullanici_sifre"].Value.ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void kullanicitablodoldur()
        {
            sda = new SqlDataAdapter("Select * From kullanici", Login.baglanti);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void satis_urunadet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void alis_urunadet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void satis_uruntur_SelectedIndexChanged(object sender, EventArgs e)
        {
            satis_urunad.Items.Clear();
            satis_urunad.Text = "";

            SqlCommand komut = new SqlCommand("select urun.urun_adi from urun join kategori on urun.kategori_id = kategori.id where kategori.kategori_adi = '" + satis_uruntur.Text + "'", Login.baglanti);
            SqlDataReader reader = komut.ExecuteReader();

            while (reader.Read())
            {
                satis_urunad.Items.Add(reader.GetString(0));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = tabPage1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = tabPage2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = tabPage3;
        }
    }
}
