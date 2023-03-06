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
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        DataSet1TableAdapters.DataTable1TableAdapter ds=new DataSet1TableAdapters.DataTable1TableAdapter();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource= ds.OgrenciListesi();
            SqlConnection baglanti = new SqlConnection(@"Data Source=OMER\SQLEXPRESS;Initial Catalog=E-Okul;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From tbl_kulupler", baglanti);
            SqlDataAdapter da=new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbOgrenciKulup.DisplayMember= "KULUPAD";
            cmbOgrenciKulup.ValueMember= "KULUPID";
            cmbOgrenciKulup.DataSource= dt;
            baglanti.Close();

        }
        string c = "";
        private void btnEkle_Click(object sender, EventArgs e)
        {
          
            
            ds.OgrenciyiEkle(txtOgrenciAd.Text, txtOgrenciSoyad.Text,byte.Parse(cmbOgrenciKulup.SelectedValue.ToString()),c);
            MessageBox.Show("Ekleme Başarılı.", "Bilgi");
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void cmbOgrenciKulup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(txtOgrenciId.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtOgrenciId.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtOgrenciAd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtOgrenciSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbOgrenciKulup.Text= dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()=="Erkek")
            {
                radioErkek.Checked = true;
               
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() == "Kız")
            {
                radioKiz.Checked = true;
               
            }

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(txtOgrenciAd.Text, txtOgrenciSoyad.Text, byte.Parse(cmbOgrenciKulup.SelectedValue.ToString()),c,int.Parse(txtOgrenciId.Text));
        }

        private void radioKiz_CheckedChanged(object sender, EventArgs e)
        {
            if (radioKiz.Checked == true)
            {
                c = "Kız";
            }
            
        }

        private void radioErkek_CheckedChanged(object sender, EventArgs e)
        {
            if (radioErkek.Checked == true)
            {
                c = "Erkek";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciGetir(txtAra.Text);
        }
    }
}
