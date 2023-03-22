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

namespace ado.net
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection();
            baglan.ConnectionString = "Data Source=103A-8;Initial Catalog=KuzeyYeli;Integrated Security=True";


            SqlCommand kmt = new SqlCommand();
            kmt.CommandText = "select*from Urunler";
            kmt.Connection = baglan;
            baglan.Open();
            SqlDataReader reader = kmt.ExecuteReader();//çalıştır ve oku
            while (reader.Read()) ;
            {
                string isim = reader["UrunAdi"].ToString();
                string fiyat= reader["Fiyat"].ToString() ;
                string stok = reader["Stok"].ToString();
                listBox1.Items.Add(String.Format("{0}-{1}-{2}",isim,fiyat,stok));
            }
            baglan.Close();//açılan baglantı her zaman kapatılmak zorunda
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kategori ktgry= new kategori();
            ktgry.ShowDialog();
        }
    }
}
