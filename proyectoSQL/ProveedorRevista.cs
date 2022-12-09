using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class ProveedorRevista : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public ProveedorRevista()
        {
            InitializeComponent(); string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM ProveedorRevista";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "ProveedorRevista");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["ProveedorRevista"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idProveedor = txtIDProveedor.Text;
            string revista = txtRevista.Text;
            consulta = "INSERT INTO ProveedorRevista (idProveedor,idRevista) " +
                "values('" + idProveedor + "', '" + revista + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idProveedorRevista = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string idProveedor = txtIDProveedor.Text;
            string revista = txtRevista.Text;
            consulta = consulta = "UPDATE ProveedorRevista SET idProveedor = '" + idProveedor + txtRevista + "' WHERE idProveedorRevista = " + idProveedorRevista.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDProveedor.Clear();
            txtRevista.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idProveedorRevista = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ProveedorRevista SET ESTATUS = 0 WHERE idProveedorRevista =" + idProveedorRevista.ToString();
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

        private void ProveedorRevista_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }
    }
}
