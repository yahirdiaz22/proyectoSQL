using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class FichaTecnica : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public FichaTecnica()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM FichaTecnica";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "FichaTecnica");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["FichaTecnica"];
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string año = txtFecha.Text;
            string sinopsis = txtSinopsis.Text;
            string idioma = txtIdioma.Text;
            string titulo = txtTitulo.Text;
            string ilustrador = txtIlustrador.Text;
            string libro = txtIDLibro.Text;
            consulta = "INSERT INTO FichaTecnica (año,sinopsis,idiomaOriginal,titulo,ilustradorOriginal,idLibro) " +
                "values('" + año + "', '" + sinopsis + "','" + idioma + "', '" + titulo + "','" + idioma + "', '" + libro +"')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();
            txtTitulo.Clear();
            txtFecha.Clear();
            txtSinopsis.Clear();
            txtIdioma.Clear();
            txtIlustrador.Clear();
            txtIDLibro.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idFichaTecnica = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string año = txtFecha.Text;
            string sinopsis = txtSinopsis.Text;
            string idioma = txtIdioma.Text;
            string titulo = txtTitulo.Text;
            string ilustrador = txtIlustrador.Text;
            string libro = txtIDLibro.Text;
            consulta = consulta = "UPDATE FichaTecnica SET año = '" + año + "', '" + sinopsis + "','" + idioma + "', '" + titulo + "','" + idioma + "', '" + libro + "' WHERE idFichaTecnica = " + idFichaTecnica.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtTitulo.Clear();
            txtFecha.Clear();
            txtSinopsis.Clear();
            txtIdioma.Clear();
            txtIlustrador.Clear();
            txtIDLibro.Clear();

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idFichaTecnica = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE iichaTecnica SET ESTATUS = 0 WHERE idFichaTecnica =" + idFichaTecnica.ToString();
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

        private void FichaTecnica_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }
    }
}
