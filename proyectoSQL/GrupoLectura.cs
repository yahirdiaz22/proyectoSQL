﻿using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class GrupoLectura : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public GrupoLectura()
        {
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            InitializeComponent();
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM GrupoLectura";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "GrupoLectura");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["GrupoLectura"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string descripcion = txtDesrcipcion.Text;
            string idBiblioteca = txtIDBiblioteca.Text;
            string idUSuario = txtIDUsuario.Text;
            consulta = "INSERT INTO GrupoLectura (descripcion,idUsuario,idBiblioteca) " +
                "values('" + descripcion + "', '" + idUSuario + "','" + idBiblioteca + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();

            txtDesrcipcion.Clear();
            txtIDBiblioteca.Clear();
            txtIDUsuario.Clear();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idGrupoLectura = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string descripcion = txtDesrcipcion.Text;
            string idBiblioteca = txtIDBiblioteca.Text;
            string idUSuario = txtIDUsuario.Text;
            consulta = "UPDATE GrupoLectura  SET descripcion = '" + descripcion + "', idBiblioteca = '" + idBiblioteca + "',idUsuario = '" + idUSuario+  "'  WHERE idGrupoLectura  = "+ idGrupoLectura.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtDesrcipcion.Clear();
            txtIDBiblioteca.Clear();
            txtIDUsuario.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idGrupoLectura = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE GrupoLectura SET ESTATUS = 0 WHERE idGrupoLectura =" + idGrupoLectura.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void GrupoLectura_Load(object sender, EventArgs e)
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
