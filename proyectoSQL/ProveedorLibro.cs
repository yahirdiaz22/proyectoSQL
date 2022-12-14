using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class ProveedorLibro : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public ProveedorLibro()
        {
            InitializeComponent(); string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM ProveedorLibro";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "ProveedorLibro");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["ProveedorLibro"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idProveedor = txtIDProveedor.Text;
            string idLibro = txtIDLibro.Text;
            consulta = "INSERT INTO ProveedorLibro (idProveedor,idLibro) " +
                "values('" + idProveedor + "', '" + idLibro + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();


            txtIDProveedor.Clear();
            txtIDLibro.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idProveedorLibro = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string idProveedor = txtIDProveedor.Text;
            string idLibro = txtIDLibro.Text;
            consulta = "UPDATE ProveedorLibro  SET idProveedor = '" + idProveedor + "', idLibro = '" + idLibro + "' WHERE idProveedorLibro = " + idProveedorLibro.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDProveedor.Clear();
            txtIDLibro.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idProveedorLibro = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ProveedorLibro SET ESTATUS = 0 WHERE idProveedorLibro =" + idProveedorLibro.ToString();
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

        private void ProveedorLibro_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }
    }
}
