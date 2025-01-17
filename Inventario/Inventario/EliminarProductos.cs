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
    public partial class EliminarProductos : Form
    {
        public EliminarProductos()
        {
            InitializeComponent();
        }

        private string connectionString = "Server = localhost\\SQLEXPRESS02;Database=InventarioDB;Trusted_Connection=True;";

        
        private void EliminarProductos_Load(object sender, EventArgs e)
        {
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
              string codigoProducto= txtCodigo.Text;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Productos WHERE ProductoID = @ProductoID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductoID", codigoProducto);
                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Producto eliminado exitosamente.");
                    }
                    else
                    {
                        MessageBox.Show("Producto no encontrado.");
                    }
                }

            }
            this.Close();
        }
    }
}
