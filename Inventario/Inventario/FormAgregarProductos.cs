﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario
{
    public partial class FormAgregarProductos : Form
    {
        public FormAgregarProductos()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string codigo = txtCodigo.Text;
            decimal precio = decimal.Parse(txtPrecio.Text);
            int existencia = int.Parse(txtExistencia.Text);
            string proveedor = txtProveedor.Text;
            string categoria = txtCategoria.Text; // Obtener la categoría

            using (SqlConnection connection = new SqlConnection("Server=localhost\\SQLEXPRESS02;Database=InventarioDB;Trusted_Connection=True;"))
            {
                connection.Open();
                string query = "INSERT INTO Productos (Nombre, ProductoID, Precio, Stock, Proveedor, Categoria) VALUES (@Nombre, @ProductoID, @Precio, @Stock, @Proveedor, @Categoria)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@ProductoID", codigo);
                    command.Parameters.AddWithValue("@Precio", precio);
                    command.Parameters.AddWithValue("@Stock", existencia);
                    command.Parameters.AddWithValue("@Proveedor", proveedor);
                    command.Parameters.AddWithValue("@Categoria", categoria); // Agregar categoría

                    command.ExecuteNonQuery();
                    MessageBox.Show("Producto agregado exitosamente.");
                }
            }
            this.Close();
        }

        private void FormAgregarProductos_Load(object sender, EventArgs e)
        {

        }
    }
}
