﻿using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Seccion : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Seccion()
        {
            InitializeComponent(); string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Secciones";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Secciones");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["Secciones"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string lectura = txtLectura.Text;
            string video = txtVideo.Text;
            string foto = txtVideo.Text;
            string hemeroteca = txtHemeroteca.Text;
            string coleccion = txtColeccion.Text;
            string autoservicio = txtCopias.Text;
            string idBiblioteca = txtIDBiblioteca.Text;
            consulta = "INSERT INTO Secciones (lecturaConsulta,videoteka,fonoteca,hemeroteca,coleccionLocal,autoServicioFotoCopias,idBiblioteca) " +
                "values('" + lectura + "', '" + video + "','" + foto +"', '" + hemeroteca + "','" + coleccion + "', '" + autoservicio + "','" + idBiblioteca + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();
            txtColeccion.Clear();
            txtLectura.Clear();
            txtVideo.Clear();
            txtHemeroteca.Clear();
            txtCopias.Clear();
            txtIDBiblioteca.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idSeccion = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string lectura = txtLectura.Text;
            string video = txtVideo.Text;
            string foto = txtVideo.Text;
            string hemeroteca = txtHemeroteca.Text;
            string coleccion = txtColeccion.Text;
            string autoservicio = txtCopias.Text;
            string idBiblioteca = txtIDBiblioteca.Text;
            consulta = consulta = "UPDATE Secciones SET lecturaConsulta = '" + lectura + "', '" + video + "','" + foto + "', '" + hemeroteca + "','" + coleccion + "', '" + autoservicio + "','" + idBiblioteca + "' WHERE idSecciones = " + idSeccion.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtColeccion.Clear();
            txtLectura.Clear();
            txtVideo.Clear();
            txtHemeroteca.Clear();
            txtCopias.Clear();
            txtIDBiblioteca.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idSeccion = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Secciones SET ESTATUS = 0 WHERE idSecciones =" + idSeccion.ToString();
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

        private void Seccion_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }
    }
}
