﻿using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Revista : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Revista()
        {
            InitializeComponent(); string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Revista";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Revista");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["Revista"];
        }
        private void Revista_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string editorial = txtEditorial.Text;
            string numeroPagina = txtNumero.Text;
            string pais = txtPais.Text;
            consulta = "INSERT INTO Revista (nombre,editorial,numeroPagina,pais) " +
                "values('" + nombre + "', '" + editorial + "','" + numeroPagina + "', '" + pais + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();

            txtNumero.Clear();
            txtEditorial.Clear();
            txtNombre.Clear();
            txtPais.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idRevista = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string nombre = txtNombre.Text;
            string editorial = txtEditorial.Text;
            string numeroPagina = txtNumero.Text;
            string pais = txtPais.Text;
            consulta = consulta = "UPDATE Revista SET nombre = '" + nombre + "', editorial  =  '" + editorial + "',numeroPagina = '" + numeroPagina + "',pais =  '" + pais + "' WHERE idRevista = " + idRevista.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNumero.Clear();
            txtEditorial.Clear();
            txtNombre.Clear();
            txtPais.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idRevista = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Revista SET ESTATUS = 0 WHERE idRevista =" + idRevista.ToString();
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
