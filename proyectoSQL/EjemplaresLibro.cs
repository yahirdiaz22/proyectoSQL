﻿using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class EjemplaresLibro : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public EjemplaresLibro()
        {
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            InitializeComponent();
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM EjemplaresLibro";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "EjemplaresLibro");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["EjemplaresLibro"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string ejemplares = txtIDEjemplare.Text;
            string libro = txtIDLibro.Text;
            consulta = "INSERT INTO EjemplaresLibro (idEjemplares, idLibro) " +
                "values('" + ejemplares + "', '" + libro + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();


            txtIDEjemplare.Clear();
            txtIDLibro.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idEjemplaresLibro = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string ejemplares = txtIDEjemplare.Text;
            string libro = txtIDLibro.Text;
             consulta = "UPDATE EjemplaresLibro SET idEjemplares  = '" + ejemplares + "', idLibro = '" + libro + "' WHERE idEjemplaresLibro = " + idEjemplaresLibro.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDEjemplare.Clear();
            txtIDLibro.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idEjemplaresLibro = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE EjemplaresLibro SET ESTATUS = 0 WHERE idEjemplaresLibro =" + idEjemplaresLibro.ToString();
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

        private void EjemplaresLibro_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
    }
}
