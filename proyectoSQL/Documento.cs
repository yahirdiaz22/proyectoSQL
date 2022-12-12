using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Documento : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Documento()
        {
            InitializeComponent(); string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Documento";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Documento");
            conexion.Close();
            dgvActividadPrograma.DataSource = ds.Tables["Documento"];
        }

        private void Documento_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string video = txtVideo.Text;
            string cds = txtCds.Text;
            string dvd = txtDvd.Text;
            string mapas = txtMapa.Text;
            string planos = txtPlano.Text;
            string idBiblioteca = txtIDBil.Text;
            consulta = "INSERT INTO Documento (videos,cds,dvd,mapas,planos,idBiblioteca) " +
                "values('" + video + "', '" + cds + "', '" + dvd + "', '" + mapas + "','" + planos + "','" + idBiblioteca + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();


            txtVideo.Clear();
            txtCds.Clear();
            txtDvd.Clear();
            txtMapa.Clear();
            txtPlano.Clear();
            txtIDBil.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idDocumento = (int)dgvActividadPrograma.SelectedRows[0].Cells[0].Value;
            string video = txtVideo.Text;
            string cds = txtCds.Text;
            string dvd = txtDvd.Text;
            string mapas = txtMapa.Text;
            string planos = txtPlano.Text;

            string idBiblioteca = txtIDBil.Text;
            consulta = consulta = "UPDATE Documento SET videos = '" + video + "', cds =  '" + cds + "', dvd = '" + dvd + "', mapas = '" + mapas + "',planos = '" + planos + "',idBiblioteca = '" + idBiblioteca + "' WHERE idDocumento = " + idDocumento.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtVideo.Clear();
            txtCds.Clear();
            txtDvd.Clear();
            txtMapa.Clear();
            txtPlano.Clear();
            txtIDBil.Clear();

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idDocumento = (int)dgvActividadPrograma.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Documento SET ESTATUS = 0 WHERE idDocumento =" + idDocumento.ToString();
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
    }
}
