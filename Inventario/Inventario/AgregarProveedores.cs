using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Inventario
{
    public partial class AgregarProveedores : Form
    {
        public AgregarProveedores()
        {
            InitializeComponent();
        }

        private void AgregarProveedores_Load(object sender, EventArgs e)
        {

        }
        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        [Obsolete]
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Server=localhost\\SQLEXPRESS02;Database=InventarioDB;Trusted_Connection=True;"))
            {
                connection.Open();
                string query = "INSERT INTO Proveedores (Nombre, Contacto, Direccion, Telefono) VALUES (@Nombre, @Contacto, @Direccion, @Telefono)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", txtNombreEmpresa.Text);
                    command.Parameters.AddWithValue("@Contacto", txtContacto.Text);
                    command.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                    command.Parameters.AddWithValue("@Telefono", txtTelefono.Text);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Proveedor agregado con éxito.");
                        this.Close(); // Cierra el formulario al terminar
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar el proveedor.");
                    }
                }
                connection.Close();
            }
        }
    }
}
