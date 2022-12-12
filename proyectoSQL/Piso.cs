using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Piso : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Piso()
        {
            InitializeComponent(); string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Piso";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Piso");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["Piso"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string descripcion = txtDesrcipcion.Text;
            string numero = txtNumero.Text;
            string idBiblioteca = txtIDBiblioteca.Text;

            consulta = "INSERT INTO Piso (descripcion,numPiso,idBiblioteca) " +
                "values('" + descripcion + "', '" + numero + "','" + idBiblioteca + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();

            txtIDBiblioteca.Clear();
            txtDesrcipcion.Clear();
            txtNumero.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idPiso = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string descripcion = txtDesrcipcion.Text;
            string numero = txtNumero.Text;
            string idBiblioteca = txtIDBiblioteca.Text;
            consulta = "UPDATE Piso  SET descripcion = '" + descripcion + "', numPiso = '" + numero + "', idBiblioteca = '" + idBiblioteca + "' WHERE idPiso = " + idPiso.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDBiblioteca.Clear();
            txtDesrcipcion.Clear();
            txtNumero.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idPiso = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Piso SET ESTATUS = 0 WHERE idPiso =" + idPiso.ToString();
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

        private void Piso_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }
    }
}
