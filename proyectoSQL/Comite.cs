using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Comite : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Comite()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Comite";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Comite");
            conexion.Close();
            dgvAdquisicion.DataSource = ds.Tables["Comite"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string numeroPersonas = txtNumero.Text;
            string idBiblioteca = txtIDBiblio.Text;
            consulta = "INSERT INTO Comite (nombre, numeroPersonas, idBiblioteca) " +
               "values('" + nombre + "', '" + numeroPersonas + idBiblioteca + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();


            txtIDBiblio.Clear();
            txtNombre.Clear();
            txtNumero.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idComite = (int)dgvAdquisicion.SelectedRows[0].Cells[0].Value;
            string nombre = txtNombre.Text;
            string numeroPersonas = txtNumero.Text;
            string idBiblioteca = txtIDBiblio.Text;
            consulta = "UPDATE Comite SET nombre = '" + nombre + "',  numeroPersonas = '" + numeroPersonas + "', idBiblioteca = '" + idBiblioteca  + "' WHERE idComite = " + idComite.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDBiblio.Clear();
            txtNombre.Clear();
            txtNumero.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idComite = (int)dgvAdquisicion.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Comite SET ESTATUS = 0 WHERE idComite =" + idComite.ToString();
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

        private void Comite_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }
    }
}
