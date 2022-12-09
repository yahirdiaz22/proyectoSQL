﻿using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoSQL
{
    public partial class Proveedor : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Proveedor()
        {
            InitializeComponent(); string cadena = @"Server=localhost\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Proveedor";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Proveedor");
            conexion.Close();
            dgvActividadPrograma.DataSource = ds.Tables["Proveedor"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string aPaterno = txtApaterno.Text;
            string aMaterno = txtAmaterno.Text;
            string rfc = txtRFC.Text;
            string calle = txtCalle.Text;
            string colonia = txtColonia.Text;
            string numero = txtNumero.Text;
            string cuidad = txtCuidadd.Text;
            string estado = txtEstado.Text;
            string pais = txtPais.Text;
            string telefono = txtTelefono.Text;
            string idPedido = txtIDPedido.Text;
            consulta = "INSERT INTO Proveedor (nombre,apellidoPaterno,apellidoMaterno,rfc,calle,colonia,numeroExterior,cuidad,estado,pais,telefono,idPedido) " +
                "values('" + nombre + "', '" + aPaterno + "','" + aMaterno + "','" + rfc + "','" + calle + "','" + colonia + "','" + numero +"','" + cuidad + "','" + estado + "','" + pais + "','" + telefono + "','" + idPedido + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtApaterno.Clear();
            txtAmaterno.Clear();
            txtRFC.Clear();
            txtCalle.Clear();
            txtColonia.Clear();
            txtNumero.Clear();
            txtCuidadd.Clear();
            txtEstado.Clear();
            txtPais.Clear();
            txtTelefono.Clear();
            txtIDPedido.Clear();        
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            Hide();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idProveedor = (int)dgvActividadPrograma.SelectedRows[0].Cells[0].Value;
            string nombre = txtNombre.Text;
            string aPaterno = txtApaterno.Text;
            string aMaterno = txtAmaterno.Text;
            string rfc = txtRFC.Text;
            string calle = txtCalle.Text;
            string colonia = txtColonia.Text;
            string numero = txtNumero.Text;
            string cuidad = txtCuidadd.Text;
            string estado = txtEstado.Text;
            string pais = txtPais.Text;
            string telefono = txtTelefono.Text;
            string idPedido = txtIDPedido.Text;
            consulta = consulta = "UPDATE Proveedor SET nombre = '" + nombre + "', '" + aPaterno + "','" + aMaterno + "','" + rfc + "','" + calle + "','" + colonia + "','" + numero + "','" + cuidad + "','" + estado + "','" + pais + "','" + telefono + "','" + idPedido + "' WHERE idProveedor = " + idProveedor.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtApaterno.Clear();
            txtAmaterno.Clear();
            txtRFC.Clear();
            txtCalle.Clear();
            txtColonia.Clear();
            txtNumero.Clear();
            txtCuidadd.Clear();
            txtEstado.Clear();
            txtPais.Clear();
            txtTelefono.Clear();
            txtIDPedido.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idProveedor = (int)dgvActividadPrograma.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Proveedor SET ESTATUS = 0 WHERE idProveedor =" + idProveedor.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtApaterno.Clear();
            txtAmaterno.Clear();
            txtRFC.Clear();
            txtCalle.Clear();
            txtColonia.Clear();
            txtNumero.Clear();
            txtCuidadd.Clear();
            txtEstado.Clear();
            txtPais.Clear();
            txtTelefono.Clear();
            txtIDPedido.Clear();

        }

        private void Proveedor_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }
    }
}
