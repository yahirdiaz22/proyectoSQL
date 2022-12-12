using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Adquisicion : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Adquisicion()
        {
            
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Adquisicion";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Adquisicion");
            conexion.Close();
            dgvAdquisicion.DataSource = ds.Tables["Adquisicion"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string compra = txtCompar.Text;
            string suscripcion = txtSuscripcion.Text;
            string intercambio = txtIntercambio.Text;
            string donacion = txtDonacion.Text;
            consulta = "INSERT INTO Adquisicion (compra,suscripcion,intercambio,donacion) values ('" + compra + "','" + suscripcion + "','" + intercambio + "','" + donacion + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtCompar.Clear();
            txtSuscripcion.Clear();
            txtIntercambio.Clear();
            txtDonacion.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string compra = txtCompar.Text;
            string suscripcion = txtSuscripcion.Text;
            string intercambio = txtIntercambio.Text;
            string donacion = txtDonacion.Text;
            int idAdquisicion = (int)dgvAdquisicion.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Adquisicion SET compra ='" + compra + "', suscripcion ='" + suscripcion + "',intercambio  ='" + intercambio + "',donacion ='" + donacion + "' WHERE idAdquisicion = " + idAdquisicion.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtCompar.Clear();
            txtSuscripcion.Clear();
            txtIntercambio.Clear();
            txtDonacion.Clear();
        }

        private void Adquisicion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idAdquisicion = (int)dgvAdquisicion.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Adquisicion SET ESTATUS = 0 WHERE idAdquisicion =" + idAdquisicion.ToString();
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
