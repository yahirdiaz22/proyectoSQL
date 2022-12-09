﻿using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class AreaMuseo : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public AreaMuseo()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM AreaMuseo";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "AreaMuseo");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["AreaMuseo"];

        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcio.Text;
            string idBiblioteca = txtIdBiblioteca.Text;
            consulta = "INSERT INTO AreaMuseo (nombre,descripcion,idBiblioteca) values ('" + nombre + "','" + descripcion + "','" + idBiblioteca + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtDescripcio.Clear();
            txtIdBiblioteca.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcio.Text;
            string idBiblioteca = txtIdBiblioteca.Text;
            int idAreaMuseo = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE AreaMuseo SET nombre ='" + nombre + "','" + descripcion        + "','" + idBiblioteca + "'WHERE idAreaMuseo = " + idAreaMuseo.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtIdBiblioteca.Clear();
        }

        private void AreaMuseo_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idAreaMuseo = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE AreaMuseo SET ESTATUS = 0 WHERE idAreaMuseo =" + idAreaMuseo.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Menu regresar = new Menu();
            regresar.Show();
        }
    }
}
