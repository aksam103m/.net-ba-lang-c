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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sqlvec_komutları
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //global alana bağlantı adresini tanımladık

        SqlConnection baglantim = new SqlConnection("Data Source=103A-8;Initial Catalog=KITAPLIK;Integrated Security=True");



        private void button1_Click(object sender, EventArgs e) //// tabloyu göstermek için.
        {
            //disconnected mimari
            SqlDataAdapter dk = new SqlDataAdapter("select * from kitap3", baglantim);
            //sqldatadapter dataset ile sql arasında köprüyü sağlar.
            DataSet ds = new DataSet();
            dk.Fill(ds, "kitap3");
            //dk.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0]; ile de çalışır!!


            dataGridView1.DataSource = ds.Tables["kitap3"];

            //tables[0]--ilk tablom
            //tables[1]--2.tablo olur
            //her click de datagridview kitap table ile dolduruyoruz

            //dataGridView1.DataSource = null;ise her click de grid içini temizliyor

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'kITAPLIKDataSet.kitap3' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.kitap3TableAdapter.Fill(this.kITAPLIKDataSet.kitap3);
            //----eski veriyi getirmemesi için yorum satırı yaptık

        }

        private void button2_Click(object sender, EventArgs e) /// kayıt ekleme
        {
            ///connected mimari
            ///parametreli güvenlik için yapılıyor.
            ///
            
            SqlCommand kayitekle = new SqlCommand
              ("insert into kitap3 (KitapNo,KitapAd,KitapYazar,KitapTur,KitapFiyat,Vergi)" +
                "values(@k1,@k2,@k3,@k4,@k5,@k6)", baglantim);

            ///txtbox veri çekme yöntemi 2 tanedir.
            ///a.txtboxt1.text
            ///b.parametre ile --biz @parametre ile karışıklığı önledik
            ///
            //kitapno sqlde identity yes!!

            kayitekle.Parameters.AddWithValue("@k1", textBox1.Text);
            kayitekle.Parameters.AddWithValue("@k2", textBox2.Text);
            kayitekle.Parameters.AddWithValue("@k3", textBox3.Text);
            kayitekle.Parameters.AddWithValue("@k4", textBox4.Text);
            kayitekle.Parameters.AddWithValue("@k5", textBox5.Text);
            kayitekle.Parameters.AddWithValue("@k6", textBox6.Text);

            baglantim.Open();
            kayitekle.ExecuteNonQuery(); ///girilen degerleri sql e göndermeye yarar
            MessageBox.Show("kayıt eklendi");
            baglantim.Close();
            //executenonquery--parametre uzerinde değişiklik için kullanılır.
        }

        private void button3_Click(object sender, EventArgs e) //// silme işlemi
        {
            baglantim.Open();
            SqlCommand kayitsil = new SqlCommand("delete from kitap3 where KitapAd=@ad", baglantim);
            kayitsil.Parameters.AddWithValue("@ad", textBox2.Text);
            //TEXTBOX2 GİRİLEN KİTAP ADINI SİLECEK

            MessageBox.Show("KAYIT SİLİNDİ");
            kayitsil.ExecuteNonQuery();
            baglantim.Close();

            //SqlConnection ,open baglanti açar, bazı özelliklerini görüntüler.
            //Bağlantı, bloğun sonunda otomatik olarak kapatılır (close)


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DATAGRIEDVIEW EVENTS-CELLCLICK ÇİFT TIKLA!!
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            //secilen satırı hafızaya aldı!!
            string KitapNo = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            string KitapAd = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            string KitapYazar = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            string KitapTur = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            string KitapFiyat = dataGridView1.Rows[secim].Cells[4].Value.ToString();
            string Vergi = dataGridView1.Rows[secim].Cells[5].Value.ToString();

            //hafızaya sırayla her sütunu yazdık yani indeksleri yazdık!!
            textBox1.Text = KitapNo;
            textBox2.Text = KitapAd;
            textBox3.Text = KitapYazar;
            textBox4.Text = KitapTur;
            textBox5.Text = KitapFiyat;
            textBox6.Text = Vergi;
        }

        private void button4_Click(object sender, EventArgs e) //// güncelleme işlemi
        {

            //veri göster-datagridview seçili satırdaki datalar textbox içine gelecek
            //düzenleme yapıp güncelle butonuna bas(önce datagridview cellclick kod yazılır)

            baglantim.Open();
            SqlCommand kayitgüncelleme = new SqlCommand
            ("update Kitap3 set KitapNo=@m1,KitapAd=@m2,KitapYazar=@m3,KitapTur=@m4,KitapFiyat=@m5,Vergi=@m6 where KitapNo=@m1", baglantim);
            
            kayitgüncelleme.Parameters.AddWithValue("@m1", textBox1.Text);
            kayitgüncelleme.Parameters.AddWithValue("@m2", textBox2.Text);
            kayitgüncelleme.Parameters.AddWithValue("@m3", textBox3.Text);
            kayitgüncelleme.Parameters.AddWithValue("@m4", textBox4.Text);
            kayitgüncelleme.Parameters.AddWithValue("@m5", textBox5.Text);
            kayitgüncelleme.Parameters.AddWithValue("@m6", textBox6.Text);


            kayitgüncelleme.ExecuteNonQuery();
            MessageBox.Show("Güncelleme Gerçekleşti");
            baglantim.Close();

        }

        private void button5_Click(object sender, EventArgs e)////max değer
        {
            baglantim.Open();
            SqlCommand hesapla = new SqlCommand("SELECT MAX(KitapFiyat) from kitap3", baglantim);
            SqlDataReader okuma = hesapla.ExecuteReader();
            while (okuma.Read())
            {
                label10.Text = okuma[0].ToString();
                //0.indeks =max fiyat baska bir okuma işlemi yok!!
            }
            baglantim.Close();
        }

        private void button6_Click(object sender, EventArgs e)////toplam kayıt sayısı
        {
            //aynı değişken adı versen de komutlar çalışır!
            baglantim.Open();
            SqlCommand hesapla1 = new SqlCommand("select count(KitapNo) from kitap3", baglantim);
            SqlDataReader okuma1 = hesapla1.ExecuteReader();
            while (okuma1.Read())
            {
                label12.Text = okuma1[0].ToString();
                //0.indeks =count baska bir okuma işlemi yok!!
            }
            baglantim.Close();
        }

        private void button7_Click(object sender, EventArgs e)  ////fiyat toplamı
        {
            baglantim.Open();
            SqlCommand hesapla1 = new SqlCommand("select sum(KitapFiyat) from kitap3", baglantim);
            SqlDataReader okuma1 = hesapla1.ExecuteReader();
            while (okuma1.Read())
            {
                label14.Text = okuma1[0].ToString();

            }
            baglantim.Close();
        }

        private void button8_Click(object sender, EventArgs e)  //// ortalama fiyat
        {
            baglantim.Open();
            SqlCommand hesapla1 = new SqlCommand("select avg(KitapFiyat) from kitap3", baglantim);
            SqlDataReader okuma1 = hesapla1.ExecuteReader();
            while (okuma1.Read())
            {
                label16.Text = okuma1[0].ToString();

            }
            baglantim.Close();
        }

        private void button9_Click(object sender, EventArgs e) //aranılan kitap ne
        {
            //baglantim.Open();
            ////dataadapter kullanırsan baglantı açıp kapadığı için open-close yapmaya gerek yok!!
            ///
            SqlDataAdapter db = new SqlDataAdapter("select * from kitap3 where KitapAd ='" + textBox9.Text + "'", baglantim);
            DataSet ds = new DataSet();
            db.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            textBox9.Clear();


            //sql ' ' arasına veri girdiğimiz için tek tırnak kullanıldı
            //c# da "" arasına veri yazdığımız için kullanıldı
            //direk textbox yazılamaz.Syntax hatası olur!!


        }
    }
}
