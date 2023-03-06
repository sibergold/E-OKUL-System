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
    public partial class FrmSinavNotlari : Form
    {
        public FrmSinavNotlari()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.Tbl_NotlarTableAdapter ds = new DataSet1TableAdapters.Tbl_NotlarTableAdapter();

        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(txtOgrenciId.Text));
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=OMER\SQLEXPRESS;Initial Catalog=E-Okul;Integrated Security=True");
        private void FrmSinavNotlari_Load(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From tbl_dersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbDersAd.DisplayMember = "DERSAD";
            cmbDersAd.ValueMember = "DERSID";
            cmbDersAd.DataSource = dt;
            baglanti.Close();
        }
        int notid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtOgrenciId.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();





        }
        int sinav1, sinav2, sinav3, proje;
        double ortalama;
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            
            sinav1=Convert.ToInt16(txtSinav1.Text);
            sinav2 = Convert.ToInt16(txtSinav2.Text);
            sinav3 = Convert.ToInt16(txtSinav3.Text);
            proje = Convert.ToInt16(txtProje.Text);
            ortalama=(sinav1+sinav2+sinav3+proje)/4;
            txtOrtalama.Text = ortalama.ToString();
            if(ortalama>=50)
            {
                txtDurum.Text = "True";
            }
            else { txtDurum.Text = "False";}


        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(cmbDersAd.SelectedValue.ToString()),int.Parse(txtOgrenciId.Text), byte.Parse(txtSinav1.Text.ToString()), byte.Parse(txtSinav2.Text.ToString()), byte.Parse(txtSinav3.Text.ToString()), 
                byte.Parse(txtProje.Text.ToString()), byte.Parse(txtOrtalama.Text.ToString()), bool.Parse(txtDurum.Text),notid);
        
            
            }
    }
}
