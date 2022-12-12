using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class ColeccionLibro : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public ColeccionLibro()
        {
            InitializeComponent(); string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);

        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM ColeccionLibro";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "ColeccionLibro");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["ColeccionLibro"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idLibro = txtIDLibro.Text;
            string idColeccion = txtIDColeccion.Text;
            consulta = "INSERT INTO ColeccionLibro (idColeccion,idLibro) " +
                "values('" + idColeccion + "', '" + idLibro +"')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();


            txtIDColeccion.Clear();
            txtIDLibro.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idColeccionLibro = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string idColeccion = txtIDColeccion.Text;
            string idLibro = txtIDLibro.Text;
             consulta = "UPDATE ColeccionLibro SET idColeccion = '" + idColeccion + "', idLibro = '" + idLibro + "' WHERE idColeccionLibro = " + idColeccionLibro.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDColeccion.Clear();
            txtIDLibro.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idColeccionLibro = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ColeccionLibro SET ESTATUS = 0 WHERE idColeccionLibro =" + idColeccionLibro.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            Hide();
        }

        private void ColeccionLibro_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }
    }
}
