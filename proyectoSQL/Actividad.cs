using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Actividad : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        
        public Actividad()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string fecha = txtFecha.Text;
            string descripcion = txtDescripcion.Text;
            string idEmpleado = txtidEmpleado.Text;
            consulta = "INSERT INTO Actividad (nombreActividad,fecha,descripcion,idEmpleado) values ('" + nombre + "','" + fecha + "','" + descripcion + "','"+idEmpleado+"')";
            conexion.Open();
            comando = new SqlCommand(consulta,conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtFecha.Clear();
            txtDescripcion.Clear();
            txtidEmpleado.Clear();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos ()
        {
            consulta = "SELECT * FROM Actividad";
            conexion.Open ();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Actividad");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["Actividad"];

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string fecha = txtFecha.Text;
            string descripcion = txtDescripcion.Text;
            string idEmpelado = txtidEmpleado.Text;
            int idActividad = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Actividad SET nombreActividad ='" + nombre + "',fecha ='" + fecha + "',descripcion = '" + descripcion + "',idEmpleado ='"+idEmpelado+"'WHERE idActividad = "+idActividad.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtFecha.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtidEmpleado.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idActividad = (int) dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Actividad SET ESTATUS = 0 WHERE idActividad =" + idActividad.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void txtFecha_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtidEmpleado_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dgvActividad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtFecha_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Menu regresar = new Menu();
            regresar.Show();
        }
    }
}
