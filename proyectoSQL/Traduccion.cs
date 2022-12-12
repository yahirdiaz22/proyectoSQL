using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Traduccion : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Traduccion()
        {
            InitializeComponent(); string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Traduccion";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Traduccion");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["Traduccion"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string traduccion = txtTraduccion.Text;
            string descripcion = txtDescripcion.Text;
            string nombre = txtNombre.Text;
            string año = txtFecha.Text;
            string pais = txtPais.Text;
            string idLibro = txtIdLibro.Text;
            consulta = "INSERT INTO Traduccion (traduccion,descripcion,nombre,año,pais,idLibro) " +
                "values('" + traduccion + "', '" + descripcion + "','" + nombre + "', '" + año + "','" + pais + "', '" + idLibro + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();
            txtTraduccion.Clear();
            txtDescripcion.Clear();
            txtNombre.Clear();
            txtFecha.Clear();
            txtPais.Clear();
            txtIdLibro.Clear();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idTraduccion = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string traduccion = txtTraduccion.Text;
            string descripcion = txtDescripcion.Text;
            string nombre = txtNombre.Text;
            string año = txtFecha.Text;
            string pais = txtPais.Text;
            string idLibro = txtIdLibro.Text;
            consulta = consulta = "UPDATE Traduccion SET traduccion = '" + traduccion + "',descripcion =  '" + descripcion + "',nombre = '" + nombre + "', año = '" + año + "',pais = '" + pais + "', idLibro = '" + idLibro + "' WHERE idTraduccion = " + idTraduccion.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtTraduccion.Clear();
            txtDescripcion.Clear();
            txtNombre.Clear();
            txtFecha.Clear();
            txtPais.Clear();
            txtIdLibro.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idTraduccion = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Traduccion SET ESTATUS = 0 WHERE idTraduccion =" + idTraduccion.ToString();
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

        private void Traduccion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
    }
}
