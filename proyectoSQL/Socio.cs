﻿using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Socio : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Socio()
        {
            InitializeComponent(); string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Socio";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Socio");
            conexion.Close();
            dgvActividadPrograma.DataSource = ds.Tables["Socio"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string aPaterno = txtApaterno.Text;
            string aMaterno = txtAmaterno.Text;
            string calle = txtCalle.Text;
            string colonia = txtColonia.Text;
            string numero = txtNumero.Text;
            string cuidad = txtCuidadd.Text;
            string estado = txtEstado.Text;
            string pais = txtPais.Text;
            string telefono = txtTelefono.Text;
            string idPrestamo = txtIDPrestamo.Text;
            consulta = "INSERT INTO Socio (nombre,apellidoPaterno,apellidoMaterno,calle,colonia,numeroExterior,cuidad,estado,pais,telefono,idPrestamo) " +
                "values('" + nombre + "', '" + aPaterno + "','" + aMaterno + "','" + calle + "','" + colonia + "','" + numero + "','" + cuidad + "','" + estado + "','" + pais + "','" + telefono + "','" + idPrestamo + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtApaterno.Clear();
            txtAmaterno.Clear();
            txtCalle.Clear();
            txtColonia.Clear();
            txtNumero.Clear();
            txtCuidadd.Clear();
            txtEstado.Clear();
            txtPais.Clear();
            txtTelefono.Clear();
            txtIDPrestamo.Clear();
           
        
    }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idSocio = (int)dgvActividadPrograma.SelectedRows[0].Cells[0].Value; string nombre = txtNombre.Text;
            string aPaterno = txtApaterno.Text;
            string aMaterno = txtAmaterno.Text;
            string calle = txtCalle.Text;
            string colonia = txtColonia.Text;
            string numero = txtNumero.Text;
            string cuidad = txtCuidadd.Text;
            string estado = txtEstado.Text;
            string pais = txtPais.Text;
            string telefono = txtTelefono.Text;
            string idPrestamo = txtIDPrestamo.Text; consulta = consulta = "UPDATE Socio SET nombre = '" + nombre + "', '" + aPaterno + "','" + aMaterno + "','" + calle + "','" + colonia + "','" + numero + "','" + cuidad + "','" + estado + "','" + pais + "','" + telefono + "','" + idPrestamo + "' WHERE idPrestamo = " + idPrestamo.ToString();
        conexion.Open();
        comando = new SqlCommand(consulta, conexion);
        comando.ExecuteNonQuery();
        conexion.Close();
        MostrarDatos();
        txtNombre.Clear();
        txtApaterno.Clear();
        txtAmaterno.Clear();
        txtCalle.Clear();
        txtColonia.Clear();
        txtNumero.Clear();
        txtCuidadd.Clear();
        txtEstado.Clear();
        txtPais.Clear();
        txtTelefono.Clear();
        txtIDPrestamo.Clear();
    }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idSocio = (int)dgvActividadPrograma.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Socio SET ESTATUS = 0 WHERE idSocio =" + idSocio.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtApaterno.Clear();
            txtAmaterno.Clear();
            txtCalle.Clear();
            txtColonia.Clear();
            txtNumero.Clear();
            txtCuidadd.Clear();
            txtEstado.Clear();
            txtPais.Clear();
            txtTelefono.Clear();
            txtIDPrestamo.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            Hide();
        }

        private void Socio_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }
    }
}
