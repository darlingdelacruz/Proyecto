using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroPersonas
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void RegistroDePersonaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f100 = new Form1();
            f100.Show();
            this.Hide();
        }

        private void ReporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f101 = new Reporte();
            f101.Show();
            this.Hide();
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
