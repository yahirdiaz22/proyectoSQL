﻿using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class RegistroVisita : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public RegistroVisita()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM RegistroVisita";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "RegistroVisita");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["RegistroVisita"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string fechallegada = txtFechallegada.Text;
            string fechaida = txtFechaIda.Text;
            string nombre = txtNombre.Text;
            string aPaterno = txtApaterno.Text;
            string aMaterno = txtAMaterno.Text;
            string idUsuario = txtIDUsuario.Text;
            consulta = "INSERT INTO RegistroVisita (fechaLlegada,fechaIda,nombre,apellidoPaterno,apellidoMaterno,idUsuario) " +
                "values('" + fechallegada + "', '" + fechaida + "','" + nombre + "', '" + aPaterno + "','" + aMaterno + "', '" + idUsuario + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtApaterno.Clear();
            txtNombre.Clear();
            txtFechallegada.Clear();
            txtFechaIda.Clear();
            txtAMaterno.Clear();
            txtIDUsuario.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idRegistroVisita = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string fechallegada = txtFechallegada.Text;
            string fechaida = txtFechaIda.Text;
            string nombre = txtNombre.Text;
            string aPaterno = txtApaterno.Text;
            string aMaterno = txtAMaterno.Text;
            string idUsuario = txtIDUsuario.Text;
            consulta = "UPDATE RegistroVisita SET fechaLlegada = '" + fechallegada + "', fechaIda =  '" + fechaida + "',nombre = '" + nombre + "', apellidoPaterno = '" + aPaterno + "', apellidoMaterno = '" + aMaterno + "', idUsuario = '" + idUsuario + "' WHERE idRegistroVisita = " + idRegistroVisita.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtApaterno.Clear();
            txtNombre.Clear();
            txtFechallegada.Clear();
            txtFechaIda.Clear();
            txtAMaterno.Clear();
            txtIDUsuario.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idRegistroVisita = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE RegistroVisita SET ESTATUS = 0 WHERE idRegistroVisita =" + idRegistroVisita.ToString();
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

        private void RegistroVisita_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }
    }
}
