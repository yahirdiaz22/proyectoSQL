using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace proyectoSQL
{
    public partial class Boveda : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Boveda()
        {
            
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);

        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Boveda";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Boveda");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["Boveda"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string mobiliario = txtMobiliario.Text;
            string material = txtMaterial.Text;
            string idBiblioteca = txtidBiblio.Text;
            consulta = "INSERT INTO Adorno (nombre, tematica, calidad) " +
                "values('" + nombre + "', '" + mobiliario + "', '" + material + "', '" + idBiblioteca + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();


            txtNombre.Clear();
            txtMobiliario.Clear();
            txtMaterial.Clear();
            txtidBiblio.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idBoveda = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string nombre = txtNombre.Text;
            string mobiliario = txtMobiliario.Text;
            string material = txtMaterial.Text;
            string idBiblioteca = txtidBiblio.Text;
           consulta = "UPDATE Boveda SET nombreLibro = '" + nombre + "',mobiliario =  '" + mobiliario + "', material = '" + material + "', idBiblioteca = '" + idBiblioteca + "' WHERE idBoveda = " + idBoveda.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtMobiliario.Clear();
            txtMaterial.Clear();
            txtidBiblio.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idBoveda = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Boveda SET ESTATUS = 0 WHERE idBoveda =" + idBoveda.ToString();
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

        private void Boveda_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }
    }
}
