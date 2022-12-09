using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Prestamo : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Prestamo()
        {
            InitializeComponent(); string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Prestamo";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Prestamo");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["Prestamo"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string fecha = txtPrestamo.Text;
            string fechaEntrega = txtFechaEntrega.Text;
            string credencial = txtIDCredencial.Text;

            consulta = "INSERT INTO Prestamo (fecha,fechaEntrega,idCredencial) " +
                "values('" + fecha + "', '" + fechaEntrega + "','" + credencial + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();

            txtIDCredencial.Clear();
            txtPrestamo.Clear();
            txtFechaEntrega.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idPrestamo = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string fecha = txtPrestamo.Text;
            string fechaEntrega = txtFechaEntrega.Text;
            string credencial = txtIDCredencial.Text;
            consulta = consulta = "UPDATE Prestamo SET fecha = '" + fecha + "', '" + fechaEntrega + "','" + credencial + "' WHERE idPrestamo = " + idPrestamo.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDCredencial.Clear();
            txtPrestamo.Clear();
            txtFechaEntrega.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idPrestamo = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Prestamo SET ESTATUS = 0 WHERE idPrestamo =" + idPrestamo.ToString();
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

        private void Prestamo_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }
    }
}
