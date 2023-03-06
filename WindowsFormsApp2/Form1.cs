using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmNotlar frmNotlar= new FrmNotlar();
            frmNotlar.numara = textBox1.Text;
            frmNotlar.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            FrmOgretmen frmOgretmen = new FrmOgretmen();
            frmOgretmen.Show();
        }
    }
}
