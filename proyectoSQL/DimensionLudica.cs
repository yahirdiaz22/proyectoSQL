﻿using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class DimensionLudica : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public DimensionLudica()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM DimensionLudica";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "DimensionLudica");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["DimensionLudica"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string representacion = txtRepresentacion.Text;
            string debate = txtDebate.Text;
            string proyeccion = txtProyeccion.Text;
            string seccion = txtSeccion.Text;
            string idBiblioteca = txtidBiblio.Text;
            consulta = "INSERT INTO DimensionLudica (representacion,debates,proyeccionPeliculasDocumentos,seccionJuegoMeasa,idBiblioteca) " +
                "values('" + representacion + "', '" + debate + "', '" + proyeccion + "', '" + seccion + "', '" + idBiblioteca + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();


            txtRepresentacion.Clear();
            txtDebate.Clear();
            txtProyeccion.Clear();
            txtSeccion.Clear();
            txtidBiblio.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idDimensionLudica = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string representacion = txtRepresentacion.Text;
            string debate = txtDebate.Text;
            string proyeccion = txtProyeccion.Text;
            string seccion = txtSeccion.Text;
            string idBiblioteca = txtidBiblio.Text;
            consulta = consulta = "UPDATE DimensionLudica SET representacion = '" + representacion + "', '" + debate + "', '" + proyeccion + "', '" + seccion + "', '" + idBiblioteca + "' WHERE idDimensionLudica = " + idDimensionLudica.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idDimensionLudica = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE DimensionLudica SET ESTATUS = 0 WHERE idDimensionLudica =" + idDimensionLudica.ToString();
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

        private void DimensionLudica_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
    }
}
