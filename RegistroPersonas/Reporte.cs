using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;



namespace RegistroPersonas
{
    public partial class Reporte : Form
    {
        Conexion c = new Conexion();
        public Reporte()
        {
            InitializeComponent();
        }

        private void Reporte_Load(object sender, EventArgs e)
        {
            c.cargarPersonas(dataGridView1);
           

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            exportar exp = new exportar();
            exp.exportarexcell(dataGridView1);
        }

        private void RegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

       

        private void PictureBox2_Click(object sender, EventArgs e)
        {

            PrintDocument doc = new PrintDocument();
            doc.DefaultPageSettings.Landscape = true;
            doc.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            PrintPreviewDialog ppd = new PrintPreviewDialog { Document = doc };
            ((Form)ppd).WindowState = FormWindowState.Maximized;

            doc.PrintPage += delegate (object ev, PrintPageEventArgs ep)
            {
                const int DGV_ALTO = 35;
                int left = ep.MarginBounds.Left, top = ep.MarginBounds.Top;

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    ep.Graphics.DrawString(col.HeaderText, new Font("Segoe UI", 16, FontStyle.Bold), Brushes.DeepSkyBlue, left, top);
                    left += col.Width;

                    if (col.Index < dataGridView1.ColumnCount - 1)
                        ep.Graphics.DrawLine(Pens.Gray, left - 5, top, left - 5, top + 43 + (dataGridView1.RowCount - 1) * DGV_ALTO);
                }
                left = ep.MarginBounds.Left;
                ep.Graphics.FillRectangle(Brushes.Black, left, top + 40, ep.MarginBounds.Right - left, 3);
                top += 43;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Index == dataGridView1.RowCount - 1) break;
                    left = ep.MarginBounds.Left;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        ep.Graphics.DrawString(Convert.ToString(cell.Value), new Font("Segoe UI", 13), Brushes.Black, left, top + 4);
                        left += cell.OwningColumn.Width;
                    }
                    top += DGV_ALTO;
                    ep.Graphics.DrawLine(Pens.Gray, ep.MarginBounds.Left, top, ep.MarginBounds.Right, top);
                }
            };
            ppd.ShowDialog();
        }
    }
}
