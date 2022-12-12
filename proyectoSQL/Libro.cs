﻿using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Libro : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Libro()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Libro";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Libro");
            conexion.Close();
            dgvActividad.DataSource = ds.Tables["Libro"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string pais = txtPais.Text;
            string cantidad = txtCantidad.Text;
            string tema = txtTema.Text;
            string pasta = txtIDPasta.Text;
            string presatmo = txtIDPresatmo.Text;
            string autor = txtIDAutor.Text;
            string material = txtIDMaterial.Text;
            string usuario = txtIDUsuario.Text;
            string estanteria = txtIDEstanteria.Text;
            string idBiblioteca = txtIDBiblioteca.Text;
            string adqusicion = txtIDAdquisicion.Text;
            consulta = "INSERT INTO Libro (nombreLibro,pais,cantidadPaginas,idTema,idPasta,idPrestamo,idAutor,idMaterial,idUsuario,idEstanteria,idBiblioteca,idAdquisicion) " +
                "values('" + nombre + "', '" + pais + "','" + cantidad + "', '" + tema + "','" + pasta + "', '" + presatmo + "','" + autor + "', '" + material + "','" + usuario + "', '" + estanteria + "','" + idBiblioteca + "', '" + adqusicion + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close(); MostrarDatos();
            txtNombre.Clear();
            txtPais.Clear();
            txtCantidad.Clear();
            txtTema.Clear();
            txtIDPasta.Clear();
            txtIDPresatmo.Clear();
            txtIDAutor.Clear();
            txtIDMaterial.Clear();
            txtIDUsuario.Clear();
            txtIDEstanteria.Clear();
            txtIDBiblioteca.Clear();
            txtIDAdquisicion.Clear();


        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idLibro = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            string nombre = txtNombre.Text;
            string pais = txtPais.Text;
            string cantidad = txtCantidad.Text;
            string tema = txtTema.Text;
            string pasta = txtIDPasta.Text;
            string presatmo = txtIDPresatmo.Text;
            string autor = txtIDAutor.Text;
            string material = txtIDMaterial.Text;
            string usuario = txtIDUsuario.Text;
            string estanteria = txtIDEstanteria.Text;
            string idBiblioteca = txtIDBiblioteca.Text;
            string adqusicion = txtIDAdquisicion.Text;

            consulta = consulta = "UPDATE Libro SET nombreLibro = '" + nombre + "',pais = '" + pais + "',cantidadPaginas = '" + cantidad + "', idTema ='" + tema + "',idPasta = '" + pasta + "', idPrestamo = '" + presatmo + "',idAutor = '" + autor + "', idMaterial = '" + material + "',idUsuario = '" + usuario + "',idEstanteria = '" + estanteria + "',idBiblioteca = '" + idBiblioteca + "', idAdquisicion = '" + adqusicion + "' WHERE idLibro = " + idLibro.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtPais.Clear();
            txtCantidad.Clear();
            txtTema.Clear();
            txtIDPasta.Clear();
            txtIDPresatmo.Clear();
            txtIDAutor.Clear();
            txtIDMaterial.Clear();
            txtIDUsuario.Clear();
            txtIDEstanteria.Clear();
            txtIDBiblioteca.Clear();
            txtIDAdquisicion.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idLibro = (int)dgvActividad.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Libro SET ESTATUS = 0 WHERE idLibro =" + idLibro.ToString();
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

        private void Libro_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
    }
}
