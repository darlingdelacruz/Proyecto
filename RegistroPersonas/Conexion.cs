using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RegistroPersonas
{
    class Conexion
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
        SqlDataAdapter da;
        

        public Conexion()
        {

            try
            {
                cn = new SqlConnection("Data Source=FIN-07\\SQLEXPRESS;Initial Catalog=Tutorial;Integrated Security=True");
                cn.Open();
                
            }

            catch (Exception ex)
            {
                MessageBox.Show("No se conecto con la base de datos" + ex.ToString());
            }


        }
        public string insertar(string id, string nombre, string apellidos, string fecha)
        {
            string salida = "Se se inserto";
            try
            {
                cmd = new SqlCommand("Insert into Persona(cedula,Nombre,Apellidos,Fecha) values('" + id + "','" + nombre + "','" + apellidos + "','" + fecha + "')", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "No se conecto: " + ex.ToString();
            }
            return salida;
        }



        public int personaRegistrada(string id)
        {
            int contador = 0;
            try
            {
                cmd = new SqlCommand("Select * from Persona where cedula='" + id + "'", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    contador++;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo consultar bien: " + ex.ToString());
            }
            return contador;
        }
        public void cargarPersonas(DataGridView dgv)
        {
            try
            {
                da = new SqlDataAdapter("Select * from Persona", cn);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo llamar el datagrieView: " + ex.ToString());
            }
        }
        public void llenarTextboxConsulta(string cedula,  TextBox textBox2, TextBox textBox3, DateTimePicker dateTimePicker1)
        {
            try
            {
                cmd = new SqlCommand("Select * from Persona where cedula= '" + cedula + "'", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                   
                    textBox2.Text = dr["Nombre"].ToString();
                    textBox3.Text = dr["Apellidos"].ToString();
                    dateTimePicker1.Text = dr["Fecha"].ToString();
                }
                dr.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("No se pudo encontar por : " + ex.ToString());
            }
        }

        public string actualizar(string cedula, string nombre, string apellidos, string fecha)
        {
            string salida = "Se actualizaron los datos";
            try
            {
                cmd = new SqlCommand("Update Persona set Nombre ='" +nombre+"',Apellidos= '"+apellidos+"',Fecha= '"+fecha+"' where cedula='"+cedula+"'", cn);
                cmd.ExecuteNonQuery();
            }catch (Exception ex)
            {
                salida = "No se actualizo"+ex.ToString();
            }
            return salida;
        }

        public string eliminar(string cedula, string nombre, string apellidos, string fecha)
        {
            string salida = "Se elimino la persona";
            try
            {
                cmd = new SqlCommand("Delete Persona where nombre ='" + nombre + "'and Apellidos= '" + apellidos + "'and Fecha= '" + fecha + "'and cedula='" + cedula + "'", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "No se elimino" + ex.ToString();
            }
            return salida;
        }
    }
}
