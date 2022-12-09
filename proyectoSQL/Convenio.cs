using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Convenio : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Convenio()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Convenio";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Convenio");
            conexion.Close();
            dgvAdquisicion.DataSource = ds.Tables["Convenio"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string descripcion = txtDescripcion.Text;
            string fechainicio = txtFechaInicio.Text;
            string fechafinal = txtFechaFinal.Text;
            string idBiblioteca = txtIDBiblio.Text;
            consulta = "INSERT INTO Convenio (descripcion,fechaInicio,fechaFinal,idBiblioteca) " +
                "values('" + descripcion + "', '" + fechainicio + "', '" + fechafinal + "', '" + idBiblioteca + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();

            txtDescripcion.Clear();
            txtFechaInicio.Clear();
            txtFechaFinal.Clear();
            txtIDBiblio.Clear();
        
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idConvenio = (int)dgvAdquisicion.SelectedRows[0].Cells[0].Value;
            string descripcion = txtDescripcion.Text;
            string fechainicio = txtFechaInicio.Text;
            string fechafinal = txtFechaFinal.Text;
            string idBiblioteca = txtIDBiblio.Text;
            consulta = consulta = "UPDATE Convenio SET descripcion = '" + descripcion + "', '" + fechainicio + "', '" + fechafinal + "', '" + idBiblioteca + "' WHERE idConvenio = " + idConvenio.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtDescripcion.Clear();
            txtFechaInicio.Clear();
            txtFechaFinal.Clear();
            txtIDBiblio.Clear();

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idConvenio = (int)dgvAdquisicion.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Convenio SET ESTATUS = 0 WHERE idConvenio =" + idConvenio.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void Convenio_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            Hide();
        }
    }
}
