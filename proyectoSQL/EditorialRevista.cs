﻿using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace proyectoSQL
{
    public partial class EditorialRevista : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public EditorialRevista()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM EditorialRevista";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Boveda");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["Boveda"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idRevista = txtIDLibro.Text;
            string idEditorial = txtIDColeccion.Text;
            consulta = "INSERT INTO EditorialRevista (idEditorial,idRevista) " +
                "values('" + idEditorial + "', '" + idRevista + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();


            txtIDColeccion.Clear();
            txtIDLibro.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idEditorialRevista = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string idEditorial = txtIDColeccion.Text;
            string idLibro = txtIDLibro.Text;
            consulta = consulta = "UPDATE idEditorialRevista SET idEditorial = '" + idEditorial + "', '" + idLibro + "' WHERE idEditorialRevista = " + idEditorialRevista.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDColeccion.Clear();
            txtIDLibro.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idEditorialRevista = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE EditorialRevista SET ESTATUS = 0 WHERE idEditorialRevista =" + idEditorialRevista.ToString();
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

        private void EditorialRevista_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }
    }
}
