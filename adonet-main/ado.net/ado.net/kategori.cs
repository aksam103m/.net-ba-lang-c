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
    public partial class kategori : Form
    {
        public kategori()
        {
            InitializeComponent();
        }

        private void kategori_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'kuzeyYeliDataSet.Kategoriler' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.kategorilerTableAdapter.Fill(this.kuzeyYeliDataSet.Kategoriler);

            SqlConnection baglan = new SqlConnection
             ("Data Source = 103A - 8; Initial Catalog = KuzeyYeli; Integrated Security = True");

            SqlCommand cmd = new SqlCommand("select*from Kategoriler", baglan);
            baglan.Open();

            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string adi = rdr["KategoriAdi"].ToString();
                string tanimi= rdr["Tanimi"].ToString() ;
                string stok = rdr["Stok"].ToString();
                listBox1.Items.Add(String.Format("{0}-{1}",adi,tanimi));
            }
            baglan.Close();

        }
    }
}
