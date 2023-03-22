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
    public partial class kategoriler : Form
    {
        public kategoriler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection
          ("Data Source=103A-8;Initial Catalog=KuzeyYeli;Integrated Security=True");//GLOBAL DA TANIMLADIK


        private void kategoriler_Load(object sender, EventArgs e)
        {
            KategoriListesi();

        }
        private void KategoriListesi()
        {
            SqlDataAdapter adp = new SqlDataAdapter
                ("prc_KategoriListele", baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dt=new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)//buton yok seçili satıra gelip düzenleme yapacagız.
        {
            //hücreye çift tıkladığında güncelleme yapıp hücreden çıktığında güncellemyi kaydetmesini sagladık.

            SqlCommand command = new SqlCommand("prc_KategoriGuncelle",baglanti);
            command.CommandType= CommandType.StoredProcedure;
            DataGridViewRow row = dataGridView1.CurrentRow;
            command.Parameters.AddWithValue("@id", row.Cells["KategoriID"].Value);
            command.Parameters.AddWithValue("@adi", row.Cells["KategoriAdi"].Value);
            command.Parameters.AddWithValue("@tanim", row.Cells["Tanimi"].Value);
            baglanti.Open();
            int etk=command.ExecuteNonQuery();
            baglanti.Close();
            if (etk>0)
            {
                MessageBox.Show("güncelleme basarılı");
                KategoriListesi();

            }
            else
            {
                MessageBox.Show("güncelleme gerçekleşmedi");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("prc_KategoriEkle", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@adi", textBox1.Text);
            komut.Parameters.AddWithValue("@tanim", textBox2.Text);
            baglanti.Open();
            int etk = komut.ExecuteNonQuery();
            baglanti.Close();
            if (etk > 0)
            {
                MessageBox.Show("kayıt basarılı");
                KategoriListesi();

            }
            else
            {
                MessageBox.Show("kayıt gerçekleşmedi");
            }

        }
    }
}
