using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace RegistroPersonas
{
    public partial class Form1 : Form
    {
        Conexion c = new Conexion();
       
        public Form1()
        {
            InitializeComponent();
           

            

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (c.personaRegistrada(Convert.ToString(textBox1.Text)) == 0)

                    {
                  MessageBox.Show( c.insertar(textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Text));
                   
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    
                }
           else
            {
                MessageBox.Show("El registro ya existe");
            }
            }catch (Exception ex) { MessageBox.Show("Llene los campos correctamente"); }

    
        }

        private void Form1_Load(object sender, EventArgs e)
        {

       
           button1.Enabled = false;
           button2.Enabled = false;
            button3.Enabled = false;

        

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {



                MessageBox.Show(c.eliminar((textBox1.Text), textBox2.Text, textBox3.Text, dateTimePicker1.Text));

                textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";

                
                
                
            }
            catch (Exception ex) { MessageBox.Show("Omg"); }

        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = false;
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
         
        { 
            try { 
            if (radioButton3.Checked == true || radioButton2.Checked == true)
            { 
            if (c.personaRegistrada(Convert.ToString(textBox1.Text)) > 0)
            {
                c.llenarTextboxConsulta(textBox1.Text,  textBox2,  textBox3,  dateTimePicker1);
                       
            }
            else
                {
                    textBox2.Text = "";
                    textBox3.Text = "";
                    button3.Enabled = true;
                }

            }
            }catch(Exception ex) {  }
           
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(c.actualizar((textBox1.Text), textBox2.Text, textBox3.Text, dateTimePicker1.Text));
         
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
                MessageBox.Show("MD");
            }
        }

        private void ReporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f2 = new Reporte();
            f2.Show();
            this.Hide();
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
