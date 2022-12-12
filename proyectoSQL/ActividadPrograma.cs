using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class ActividadPrograma : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;

        public ActividadPrograma()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void ActividadPrograma_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM ActividadPrograma";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "ActividadPrograma");
            conexion.Close();
            dgvActividadPrograma.DataSource = ds.Tables["ActividadPrograma"];

        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string fecha = txtFecha.Text;
            string idEmpleado = txtidEmpleado.Text;
            consulta = "INSERT INTO ActividadPrograma (nombre,fecha,idEmpleado) values ('" + nombre + "','" + fecha + "','" + idEmpleado + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtidEmpleado.Clear();
            txtFecha.Clear();  
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string BD = "";
            string nombre = txtNombre.Text;
            string fecha = txtFecha.Text;
            string idEmpelado = txtidEmpleado.Text;
            int idActividadPrograma = (int)dgvActividadPrograma.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE ActividadPrograma SET nombre ='" + nombre + "',fecha = '" + fecha +  "',idEmpleado = '" + idEmpelado + "'WHERE idActividadPrograma = " + idActividadPrograma.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtidEmpleado.Clear();
            txtFecha.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idActividadPrograma = (int)dgvActividadPrograma.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ActividadPrograma SET ESTATUS = 0 WHERE idActividadPrograma =" + idActividadPrograma.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            Menu regresar = new Menu();
            regresar.Show();
        }
    }
}
