using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Articulo : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Articulo()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcio.Text;
            string fecha = txtFecha.Text;
            string idUsuario = txtidUsuario.Text;
            string idEditorial = txtidEditorial.Text;
            consulta = "INSERT INTO Articulo (nombreArticulo,descripcion,año,idUsuario,idEditorial) values ('" + nombre + "','" + descripcion + "','" + fecha + "','" + idUsuario + "','" + idEditorial + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtDescripcio.Clear();
            txtFecha.Clear();
            txtidEditorial.Clear();
            txtidUsuario.Clear();
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Articulo";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Articulo");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["Articulo"];

        }
        private void Articulo_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcio.Text;
            string fecha = txtFecha.Text;
            string idUsuario = txtidUsuario.Text;
            string idEditorial = txtidEditorial.Text;
            int idArticulo = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Articulo SET nombreArticulo ='" + nombre + "',descripcion = '" + descripcion + "',año = '" + fecha + "',idUsuario = '" + idUsuario + "',idEditorial = '" + idEditorial + "' WHERE idArticulo = " + idArticulo.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtDescripcio.Clear();
            txtFecha.Clear();
            txtidEditorial.Clear();
            txtidUsuario.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idAreaMuseo = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE AreaMuseo SET ESTATUS = 0 WHERE idAreaMuseo =" + idAreaMuseo.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
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
