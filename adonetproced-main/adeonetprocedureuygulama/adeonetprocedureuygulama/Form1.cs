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

namespace adeonetprocedureuygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection
           ("Data Source=103A-8;Initial Catalog=KuzeyYeli;Integrated Security=True");//GLOBAL DA TANIMLADIK

        private void Form1_Load(object sender, EventArgs e)
        {
            UrunListesi();
        }

        private void UrunListesi()//güncel sonrası listeleme yapmada
        {
            SqlDataAdapter adp = new SqlDataAdapter
                ("select*from Urunler where Sonlandi=0", baglanti);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sqlcommand cmd=neew sqlcommand();
            //stored procedure ile işlem

            SqlCommand cmd = new SqlCommand("UrunEkle", baglanti);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UrunAdi", textBox1.Text);

            cmd.Parameters.AddWithValue("@fiyat", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@stok",numericUpDown2.Value);
            baglanti.Open();
            int etk=cmd.ExecuteNonQuery();
            if (etk > 0)
            {
                MessageBox.Show("kayıt eklendi");
                UrunListesi();

            }
            else
                MessageBox.Show("kayıt eklenirken hata oluştu");

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow!= null)
            {
                SqlCommand cmd = new SqlCommand("UrunSil", baglanti);
                cmd.CommandType= CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@urunId", dataGridView1.CurrentRow.Cells["UrunID"].Value);

                baglanti.Open();
                int etk=cmd.ExecuteNonQuery();
                baglanti.Close();
                if (etk > 0)
                {
                    MessageBox.Show("kayıt silindi");
                    UrunListesi();

                }
                else
                    MessageBox.Show("kaydınız silinemedi");
            }

        }


    }
}
