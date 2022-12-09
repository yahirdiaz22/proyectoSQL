using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Galeria : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Galeria()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Galeria";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Galeria");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["Galeria"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string artista = txtArtista.Text;
            string fechainiico = txtFechaInicio.Text;
            string fechafinal = txtFechaFinal.Text;
            string idBiblioteca = txtIDBiblioteca.Text;
            consulta = "INSERT INTO Galeria (nombre,nombreArtista,fechaInicio,fechaFinal,idBiblioteca) " +
                "values('" + nombre + "', '" + artista + "','" + fechainiico + "', '" + fechafinal + "','" + idBiblioteca + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();

            txtNombre.Clear();
            txtArtista.Clear();
            txtFechaInicio.Clear();
            txtIDBiblioteca.Clear();
            txtFechaFinal.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idGaleria = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string nombre = txtNombre.Text;
            string artista = txtArtista.Text;
            string fechainiico = txtFechaInicio.Text;
            string fechafinal = txtFechaFinal.Text;
            string idBiblioteca = txtIDBiblioteca.Text; ;
            consulta = consulta = "UPDATE Galeria SET nombre = '" + nombre + "', '" + artista + "','" + fechainiico + "', '" + fechafinal + "','" + idBiblioteca + "' WHERE idGaleria = " + idGaleria.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtArtista.Clear();
            txtFechaInicio.Clear();
            txtIDBiblioteca.Clear();
            txtFechaFinal.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idGaleria = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Galeria SET ESTATUS = 0 WHERE idGaleria =" + idGaleria.ToString();
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

        private void Galeria_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }
    }
}
