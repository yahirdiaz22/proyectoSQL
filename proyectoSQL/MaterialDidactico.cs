using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class MaterialDidactico : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public MaterialDidactico()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM MaterialDidactico";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "MaterialDidactico");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["MaterialDidactico"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string globo = txtGlobo.Text;
            string descripcion = txtDescripcion.Text;
            string juegos = txtJuego.Text;
            string mapas = txtMapa.Text;
            string laminas = txtLamina.Text;
            string biblioteca = txtIDBiblioteca.Text;

            consulta = "INSERT INTO MateiralDidactico (globoTerraqueo,descripcion,juegosDidacticos,mapas,laminas,idBiblioteca) " +
                "values('" + globo + "', '" + descripcion + "','" + juegos + "','" + mapas + "','" + laminas + "','" + biblioteca + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();

            txtJuego.Clear();
            txtDescripcion.Clear();
            txtGlobo.Clear();
            txtLamina.Clear();
            txtMapa.Clear();
            txtIDBiblioteca.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idMaterialDidactico = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string globo = txtGlobo.Text;
            string descripcion = txtDescripcion.Text;
            string juegos = txtJuego.Text;
            string mapas = txtMapa.Text;
            string laminas = txtLamina.Text;
            string biblioteca = txtIDBiblioteca.Text;
            consulta = consulta = "UPDATE MaterialDidactico SET globoTerraqueo = '" + globo + "', descripcion = '" + descripcion + "',juegosDidacticos = '" + juegos + "',mapas = '" + mapas + "',laminas = '" + laminas + "',idBiblioteca = '" + biblioteca + "' WHERE idMaterialDidactico = " + idMaterialDidactico.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtJuego.Clear();
            txtDescripcion.Clear();
            txtGlobo.Clear();
            txtLamina.Clear();
            txtMapa.Clear();
            txtIDBiblioteca.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idMaterialDidactico = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE MaterialDidactico SET ESTATUS = 0 WHERE idMaterialDidactico =" + idMaterialDidactico.ToString();
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

        private void MaterialDidactico_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }
    }
}
