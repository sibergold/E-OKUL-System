using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            FrmKulup frmKulup = new FrmKulup();
            frmKulup.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDersler frmdersler= new FrmDersler();
            frmdersler.Show();

        }

        private void FrmOgretmen_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSinavNotlari frmSinavNotlari = new FrmSinavNotlari();
            frmSinavNotlari.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmOgrenci frmOgrenci= new FrmOgrenci();
            frmOgrenci.Show();
        }
    }
}
