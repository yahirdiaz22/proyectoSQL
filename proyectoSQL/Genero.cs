using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Genero : Form
    {  SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Genero()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Genero";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Genero");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["Genero"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string genero = txtGenero.Text;
            string descripcion = txtDescripcion.Text;
            string libro = txtIDLibro.Text;

            consulta = "INSERT INTO Genero (genero, descripcion, idLibro) " +
                "values('" + genero + "', '" + descripcion + "','" + libro + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();


            txtGenero.Clear();
            txtDescripcion.Clear();
            txtIDLibro.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idGenero = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string genero = txtGenero.Text;
            string descripcion = txtDescripcion.Text;
            string libro = txtIDLibro.Text; ;
            consulta = "UPDATE Genero SET genero = '" + genero + "', descripcion ='" + descripcion + "',idLibro = '" + libro + "' WHERE idGenero = " + idGenero.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtGenero.Clear();
            txtDescripcion.Clear();
            txtIDLibro.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idGenero = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Genero SET ESTATUS = 0 WHERE idGenero =" + idGenero.ToString();
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

        private void Genero_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }
    }
}
