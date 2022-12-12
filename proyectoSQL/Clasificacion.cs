using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Clasificacion : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Clasificacion()
        {
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            InitializeComponent();
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Clasificacion";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Clasificacion");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["Clasificacion"];
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string descripcion = txtDescripcion.Text;
            string idBiblioteca = txtIdBiblio.Text;
            consulta = "INSERT INTO Clasificacion (nombre, tematica, calidad) " +
                "values('" + descripcion + "', '" + idBiblioteca + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();


            txtDescripcion.Clear();
            txtIdBiblio.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idClasificacion = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string descripcion = txtDescripcion.Text;
            string idBiblioteca = txtIdBiblio.Text;
            consulta = consulta = "UPDATE Clasificacion SET descripcion = '" + descripcion + "', idBiblioteca = '" + idBiblioteca + "' WHERE idClasificacion = " + idClasificacion.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtDescripcion.Clear();
            txtIdBiblio.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idClasificacion = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Clasificacion SET ESTATUS = 0 WHERE idClasificaion =" + idClasificacion.ToString();
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

        private void Clasificacion_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }
    }
}
