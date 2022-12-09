using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Ejemplares : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Ejemplares()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Ejemplares";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Ejemplares");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["Ejemplares"];
        }
        private void Ejemplares_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string desrcipcion = txtEjemplare.Text;
            string numero = txtDescripcion.Text;
            consulta = "INSERT INTO Ejemplares (totalEjemplares,descripcion) " +
                "values('" + desrcipcion + "', '" + numero + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();

            txtDescripcion.Clear();
            txtEjemplare.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idEjemplares = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string Total = txtEjemplare.Text;
            string descripcion = txtDescripcion.Text;

            consulta = consulta = "UPDATE Ejemplares SET totalEjemplares = '" + Total + "', '" + descripcion + "' WHERE idEjemplares = " + idEjemplares.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtDescripcion.Clear();
            txtEjemplare.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idEjemplares = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string descripcion = txtDescripcion.Text;
            string numero = txtEjemplare.Text;

            consulta = consulta = "UPDATE Ejemplares SET descripcion = '" + descripcion + "', '" + numero + "' WHERE idEjemplares = " + idEjemplares.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtEjemplare.Clear();
            txtDescripcion.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            Hide();
        }
    }
}
