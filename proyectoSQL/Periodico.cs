﻿using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Periodico : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Periodico()
        {
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            InitializeComponent();
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Periodico";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Periodico");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["Periodico"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string imprenta = txtNombreImprenta.Text;
            string fecha = txtFecha.Text;
            string descripcion = txtDescripcion.Text;
            string titulo = txtTitulo.Text;
            string idImprenta = txtIDImprenta.Text;
            consulta = "INSERT INTO Periodico (nombre,nombreImprenta,fecha,descripcion,titulo,idImprenta) " +
                "values('" + nombre + "', '" + imprenta + "','" + fecha + "','" + descripcion +"','" + titulo + "','" + idImprenta + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();

            txtFecha.Clear();
            txtNombre.Clear();
            txtNombreImprenta.Clear();
            txtDescripcion.Clear();
                txtTitulo.Clear();
            txtIDImprenta.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idPeriodico = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string nombre = txtNombre.Text;
            string imprenta = txtNombreImprenta.Text;
            string fecha = txtFecha.Text;
            string descripcion = txtDescripcion.Text;
            string titulo = txtTitulo.Text;
            string idImprenta = txtIDImprenta.Text;
            consulta = consulta = "UPDATE Periodico SET nombre = '" + nombre + "', '" + imprenta + "','" + fecha + "','" + descripcion + "','" + titulo + "','" + idImprenta + "' WHERE idPeriodico = " + idPeriodico.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtFecha.Clear();
            txtNombre.Clear();
            txtNombreImprenta.Clear();
            txtDescripcion.Clear();
            txtTitulo.Clear();
            txtIDImprenta.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idPeriodico = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Periodico SET ESTATUS = 0 WHERE idPeriodico =" + idPeriodico.ToString();
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

        private void Periodico_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }
    }
}
