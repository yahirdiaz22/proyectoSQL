using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Tema : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Tema()
        {
            InitializeComponent(); string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Tema";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Tema");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["Tema"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string tema = txtTema.Text;
            string descripcion = txtDescripcion.Text;
            consulta = "INSERT INTO Tema (tema,descripcion) " +
                "values('" + tema + "', '" + descripcion + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();


            txtDescripcion.Clear();
            txtTema.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idTema = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string tema = txtTema.Text;
            string descripcion = txtDescripcion.Text;
            consulta = "UPDATE Tema  SET tema = '" + tema + "', desrcipcion = '" + descripcion + "' WHERE idTema = " + idTema.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtDescripcion.Clear();
            txtTema.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idTema = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Tema SET ESTATUS = 0 WHERE idTema =" + idTema.ToString();
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

        private void Tema_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }
    }
}
