﻿using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Taller : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Taller()
        {
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            InitializeComponent();
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Taller";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Taller");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["Taller"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string fecha = txtFecha.Text;
            string descripcion = txtDesripcion.Text;
            string idBiblioteca = txtIDBiblioteca.Text;
            consulta = "INSERT INTO Taller (nombre,fecha,descripcion,idBiblioteca) " +
                "values('" + nombre + "', '" + fecha + "','" + descripcion + "', '" + idBiblioteca + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();

            txtDesripcion.Clear();
            txtNombre.Clear();
            txtFecha.Clear();
            txtIDBiblioteca.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idTaller = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string nombre = txtNombre.Text;
            string fecha = txtFecha.Text;
            string descripcion = txtDesripcion.Text;
            string idBiblioteca = txtIDBiblioteca.Text;
            consulta = consulta = "UPDATE idTaller SET nombre = '" + descripcion + idBiblioteca + "' WHERE idTaller = " + idTaller.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtDesripcion.Clear();
            txtNombre.Clear();
            txtFecha.Clear();
            txtIDBiblioteca.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idTaller = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Taller SET ESTATUS = 0 WHERE idTaller =" + idTaller.ToString();
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

        private void Taller_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }
    }
}
