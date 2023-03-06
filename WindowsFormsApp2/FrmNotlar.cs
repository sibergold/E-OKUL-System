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
namespace WindowsFormsApp2
{
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=OMER\SQLEXPRESS;Initial Catalog=E-Okul;Integrated Security=True");
        public string numara;
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select DersAd,sınav1,sınav2,sınav3,projenotu,ortalama,durum From Tbl_Notlar inner join tbl_dersler on tbl_notlar.dersıd=tbl_Dersler.dersıd where ogrenciıd=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
           SqlDataAdapter da= new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource= dt;
        }
    }
}
