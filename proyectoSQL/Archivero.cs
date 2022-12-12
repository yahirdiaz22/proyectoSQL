using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Archivero : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Archivero()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string folletos = txtFolletos.Text;
            string recortes = txtRecortes.Text;
            string ilustraciones = txtIlustraciones.Text;
            string volantes = txtVolantes.Text;
            string avisos = txtAvisos.Text;
            string idBiblioteca = txtidbiblio.Text;
            consulta = "INSERT INTO Archivero (folletos,recortes,ilustraciones,volantes,avisos,idBiblioteca) values ('" + folletos + "','" + recortes + "','" + ilustraciones + "','" + volantes + "','" + avisos + "','" + idBiblioteca + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtFolletos.Clear();
            txtRecortes.Clear();
            txtIlustraciones.Clear();
            txtVolantes.Clear();
            txtAvisos.Clear();
            txtidbiblio.Clear();
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Archivero";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Archivero");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["Archivero"];

        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            string folletos = txtFolletos.Text;
            string recortes = txtRecortes.Text;
            string ilustraciones = txtIlustraciones.Text;
            string volantes = txtVolantes.Text;
            string avisos = txtAvisos.Text;
            string idBiblioteca = txtidbiblio.Text;
            int idArchivero = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Archivero SET folletos ='" + folletos + "', recortes ='" + recortes + "',ilustraciones ='" + ilustraciones + "',volantes ='" + volantes + "',avisos ='" + avisos + "',idBiblioteca ='" + idBiblioteca + "' WHERE idArchivero = " + idArchivero.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtFolletos.Clear();
            txtRecortes.Clear();
            txtIlustraciones.Clear();
            txtVolantes.Clear();
            txtAvisos.Clear();
            txtidbiblio.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idArchivero = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Archivero SET ESTATUS = 0 WHERE idArchivero =" + idArchivero.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void Archivero_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Menu regresar = new Menu();
            regresar.Show();
        }
    }
}
