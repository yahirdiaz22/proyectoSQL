using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Multa : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Multa()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Multa";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Multa");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["Multa"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string descripcion = txtDescripcion.Text;
            string precio = txtPrecio.Text;
            string usuario = txtIDUsuario.Text;
            consulta = "INSERT INTO Multa (descripcion,precio,idUsuario) " +
                "values('" + descripcion + "', '" + precio + "','" + usuario + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();

            txtIDUsuario.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idMulta = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string descripcion = txtDescripcion.Text;
            string precio = txtPrecio.Text;
            string usuario = txtIDUsuario.Text;
            consulta = "UPDATE Multa SET descripcion = '" + descripcion + "', precio = '" + precio + "',idUsuario = '" + usuario + "' WHERE idMulta = " + idMulta.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDUsuario.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idMulta = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Multa SET ESTATUS = 0 WHERE idMulta =" + idMulta.ToString();
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

        private void Multa_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
    }
}
