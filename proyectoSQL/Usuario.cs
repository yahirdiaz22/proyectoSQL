using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Usuario : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Usuario()
        {
            InitializeComponent(); string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Usuario";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Usuario");
            conexion.Close();
            dgvActividadPrograma.DataSource = ds.Tables["Usuario"];
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string aPaterno = txtApaterno.Text;
            string aMaterno = txtAmaterno.Text;
            string calle = txtCalle.Text;
            string numero = txtNumero.Text;
            string cuidad = txtCuidadd.Text;
            string estado = txtEstado.Text;
            string pais = txtPais.Text;
            string telefono = txtTelefono.Text;
            consulta = "INSERT INTO Usuario (nombre,apellidoPaterno,apellidoMaterno,calle,colonia,numeroExterior,cuidad,estado,pais,telefono) " +
                "values('" + nombre + "', '" + aPaterno + "','" + aMaterno + "','" + calle + "','" + numero + "','" + cuidad + "','" + estado + "','" + pais + "','" + telefono + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtApaterno.Clear();
            txtAmaterno.Clear();
            txtCalle.Clear();
            txtNumero.Clear();
            txtCuidadd.Clear();
            txtEstado.Clear();
            txtPais.Clear();
            txtTelefono.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idUsuario = (int)dgvActividadPrograma.SelectedRows[0].Cells[0].Value;
            string nombre = txtNombre.Text;
            string aPaterno = txtApaterno.Text;
            string aMaterno = txtAmaterno.Text;
            string calle = txtCalle.Text;
            string numero = txtNumero.Text;
            string cuidad = txtCuidadd.Text;
            string estado = txtEstado.Text;
            string pais = txtPais.Text;
            string telefono = txtTelefono.Text;
            consulta = consulta = "UPDATE Usuario SET nombre = '" + nombre + "', apellidoPaterno = '" + aPaterno + "',apellidoMaterno = '" + aMaterno + "',calle = '" + calle + "',numeroExterior = '" + numero + "',cuidad = '" + cuidad + "',estado = '" + estado + "',pais = '" + pais + "',telefono = '" + telefono + "' WHERE idUsuario = " + idUsuario.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtApaterno.Clear();
            txtAmaterno.Clear();
            txtCalle.Clear();
            txtNumero.Clear();
            txtCuidadd.Clear();
            txtEstado.Clear();
            txtPais.Clear();
            txtTelefono.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idUsuario = (int)dgvActividadPrograma.SelectedRows[0].Cells[0].Value;
            string nombre = txtNombre.Text;
            string aPaterno = txtApaterno.Text;
            string aMaterno = txtAmaterno.Text;
            string calle = txtCalle.Text;
            string numero = txtNumero.Text;
            string cuidad = txtCuidadd.Text;
            string estado = txtEstado.Text;
            string pais = txtPais.Text;
            string telefono = txtTelefono.Text;
            consulta = consulta = "UPDATE Usuario SET nombre = '" + nombre + "', '" + aPaterno + "','" + aMaterno + "','" + calle + "','" + numero + "','" + cuidad + "','" + estado + "','" + pais + "','" + telefono + "' WHERE idUsuario = " + idUsuario.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtApaterno.Clear();
            txtAmaterno.Clear();
            txtCalle.Clear();
            txtNumero.Clear();
            txtCuidadd.Clear();
            txtEstado.Clear();
            txtPais.Clear();
            txtTelefono.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            Hide();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }
    }
}
