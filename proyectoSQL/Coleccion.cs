using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Coleccion : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Coleccion()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Coleccion";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Coleccion");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["Coleccion"];
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string desrcipcion = txtDescripcion.Text;
            string numero = txtNumero.Text;
            consulta = "INSERT INTO Coleccion (descripcion,numero) " +
                "values('" + desrcipcion + "', '" + numero + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();

            txtNumero.Clear();
            txtDescripcion.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idColeccion = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string descripcion = txtDescripcion.Text;
            string numero = txtNumero.Text;

            consulta = "UPDATE Coleccion SET descripcion = '" + descripcion + "', numeroColeccion ='" + numero +  "' WHERE idColeccion = " + idColeccion.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNumero.Clear();
            txtDescripcion.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idColeccion = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Coleccion SET ESTATUS = 0 WHERE idColeccion =" + idColeccion.ToString();
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

        private void Coleccion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
    }
}
