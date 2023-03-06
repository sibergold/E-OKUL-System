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

namespace WindowsFormsApp2
{
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=OMER\SQLEXPRESS;Initial Catalog=E-Okul;Integrated Security=True");
        void liste()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * From Tbl_Kulupler", baglanti);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void FrmKulup_Load(object sender, EventArgs e)
        {
            
            liste();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert Into Tbl_Kulupler (KulupAd) values (@p1)", baglanti);
            komut.Parameters.AddWithValue("@p1" ,txtKulupAd.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Listeye Eklendi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            liste();

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKulupId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtKulupAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from tbl_kulupler where kulupıd=@p1 ", baglanti);
            komut.Parameters.AddWithValue("@p1", txtKulupId.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme İşlemi Başarılı.", "Bilgi");
           liste ();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update Tbl_Kulupler Set kulupad=@p1 where  kulupıd=@p2",baglanti);
            komut.Parameters.AddWithValue("@p1", txtKulupAd.Text);
            komut.Parameters.AddWithValue("@p2", txtKulupId.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme Başarılı.", "Bilgi");
            liste();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
