using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace disconnectedmimari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti=new SqlConnection
            ("Data Source=103A-8;Initial Catalog=KuzeyYeli;Integrated Security=True");//GLOBAL DA TANIMLADIK

        private void Form1_Load(object sender, EventArgs e)
        {
            //CTRL. YAPARSAN KUTUPHANE GELİR
            // CNTRL+R+M DERSEK OTOMATİK METOT
            NewMethod();
            //EKLEME YAPILDIKTAN SONRA TEKRAR DATAGRİDVİEW 
        }

        private void NewMethod()
        {
            SqlDataAdapter adp = new SqlDataAdapter
                ("select*from Urunler", baglanti);
            DataTable dt=new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["UrunID"].Visible= false;  //KOLON GİZLE
        }

        private void button1_Click(object sender, EventArgs e) /// ekle butonu
        {
            string adi = textBox1.Text;
            decimal Fiyat = numericUpDown1.Value;
            decimal stok = numericUpDown2.Value;
            if (adi ==""||Fiyat == 0|| stok==0)
            {
                MessageBox.Show("tüm alanları eksiksiz doldurun");

            }
            SqlCommand komut=new SqlCommand();
            komut.CommandText=string.Format
                ("Insert Urunler (UrunAdi,Fiyat,Stok) values ('{0}',{1},{2})" ,adi,Fiyat, stok);
            komut.Connection=baglanti;
            baglanti.Open();
            int etkilenen = komut.ExecuteNonQuery();
            if (etkilenen>0)
            {
                MessageBox.Show("kayıt eklendi");
                NewMethod();

            }
            else
            {
                MessageBox.Show("kaydınız aklenemedi");

            }
            baglanti.Close();


        }

        private void button2_Click(object sender, EventArgs e)//// kaydet butonu
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = string.Format
                ("update Urunler" + " set UrunAdi='{0}',Fiyat={1}, Stok={2}" + " where UrunID={3}",
                textBox1.Text,numericUpDown1.Value,numericUpDown2.Value,textBox1.Tag);

            command.Connection = baglanti;
            baglanti.Open();

            try
            {
                int etk = command.ExecuteNonQuery();
                baglanti.Close();
                if(etk>0)
                {
                    MessageBox.Show("kayıt güncellendi");
                    NewMethod();////kayıt güncellenmiş halini çağırıyor.
                }
                else
                {
                    MessageBox.Show("kayıt güncellenirken hata oluştu");
                }

            }
            catch (Exception ex)
            {
                baglanti.Close();

                MessageBox.Show("kayıt güncellenirken hata oluştu" + ex.Message);

                //yeni ürün ekle sonra güncelle
                //olan urun güncellenirken fiyatta sorun var fazla sfır atıyor
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //event-cell click çift tıkla
            //cell click hücrede boş alanda daçalısır
            //cell contect clıck değere tıklarsa ancak çalısır.
            //cell double clıck çif5t tıklmada işlem olur.

            //dgvıexden seçili satırı alma işlemi
            textBox1.Text = dataGridView1.CurrentRow.Cells["UrunAdi"].Value.ToString();
            textBox1.Tag = dataGridView1.CurrentRow.Cells["UrunID"].Value;
            //TAG İLE CEPTE ID SAKLAMIŞ OLDUK

            numericUpDown1.Value = (decimal)dataGridView1.CurrentRow.Cells["Fiyat"].Value;
            //numericupdown cast edip money değerini decimale cevirdik.

            numericUpDown2.Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Stok"].Value);
            //short veri tipi bu şekilde cast edemiyoruz!! cast benzer tiplerde kullanılır.
            //short tam sayı decimal ondalıklı olduğundan hata verir!!
            //convert etmemiz gerkir.

        }

        private void button3_Click(object sender, EventArgs e)
        {
            kategori ktgr = new kategori();
            ktgr.ShowDialog();
            //from1 deki kategori butonuna tıklanıldığında kategori fromunun açılmasını sağladık
           /* ktgr.Show();*///sadece show dwewk iki penceeyi de acarız.
        }
    }
}
