﻿using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Biblioteca : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Biblioteca()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Biblioteca";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Biblioteca");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["Biblioteca"];
        }
        private void Biblioteca_Load(object sender, EventArgs e)
        {
           MostrarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Menu regresar = new Menu();
            regresar.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string calle = txtCalle.Text;
            string colonia = txtColonia.Text;
            string numeroExterior = txtNumeroExterior.Text;
            string telefono = txtTelefono.Text;
            string cuidad = txtCuidad.Text;
            string estado = txtEstado.Text;
            string pais = txtPais.Text;
            consulta = "INSERT INTO Biblioteca (nombre,calle,colonia,numeroExterior,telefono,cuidad,estado,pais) values ('" + nombre + "','" + calle + "','" + colonia + "','" + numeroExterior + "','" + telefono + "','" + cuidad + "','" + estado + "','" + pais + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtPais.Clear();
            txtEstado.Clear();
            txtCuidad.Clear();
            txtTelefono.Clear();
            txtNumeroExterior.Clear();
            txtColonia.Clear();
            txtCalle.Clear();
            txtNombre.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string calle = txtCalle.Text;
            string colonia = txtColonia.Text;
            string numeroExterior = txtNumeroExterior.Text;
            string telefono = txtTelefono.Text;
            string cuidad = txtCuidad.Text;
            string estado = txtEstado.Text;
            string pais = txtPais.Text;
            int idBiblioteca = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Biblioteca SET nombre ='" + nombre + "','" + calle + "','" + colonia + "','" + numeroExterior + "','" + telefono + "','" + cuidad + "','" + estado + "','" + pais +  "'WHERE idAdquisicion = " + idBiblioteca.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtPais.Clear();
            txtEstado.Clear();
            txtCuidad.Clear();
            txtTelefono.Clear();
            txtNumeroExterior.Clear();
            txtColonia.Clear();
            txtCalle.Clear();
            txtNombre.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idBiblioteca = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Biblioteca SET ESTATUS = 0 WHERE idBiblioteca =" + idBiblioteca.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }
    }
}
