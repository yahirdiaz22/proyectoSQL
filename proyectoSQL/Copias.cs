﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Copias : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Copias()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Copias";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Copias");
            conexion.Close();
            dgvActividadPrograma.DataSource = ds.Tables["Copias"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string numero = txtNumero.Text;
            string descripcion = txtDescripcion.Text;
            string fecha  = txtfecg.Text;
            string idLibro = txtLibro.Text;
            consulta = "INSERT INTO Copias (numero,decripcion,fecha,idLibro) " +
                "values('" + numero + "', '" + descripcion + "', '" + fecha + "', '" + idLibro + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();


            txtNumero.Clear();
            txtDescripcion.Clear();
            txtLibro.Clear();
            txtfecg.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idCopias = (int)dgvActividadPrograma.SelectedRows[0].Cells[0].Value;
            string numero = txtNumero.Text;
            string descripcion = txtDescripcion.Text;
            string fecha = txtfecg.Text;
            string idLibro = txtLibro.Text;
            consulta = consulta = "UPDATE Copias SET numCopias = '" + numero + "', descripcion = '" + descripcion + "', fecha = '" + fecha + "', idLibro = '" + idLibro + "' WHERE idCopias = " + idCopias.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNumero.Clear();
            txtDescripcion.Clear();
            txtLibro.Clear();
            txtfecg.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idCopias = (int)dgvActividadPrograma.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Copias SET ESTATUS = 0 WHERE idCopias =" + idCopias.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void Copias_Load(object sender, EventArgs e)
        {
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
