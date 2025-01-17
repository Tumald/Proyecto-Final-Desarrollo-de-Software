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
    public partial class EliminarProveedor : Form
    {
        public EliminarProveedor()
        {
            InitializeComponent();
        }

    

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Server=localhost\\SQLEXPRESS02;Database=InventarioDB;Trusted_Connection=True;"))
            {
                connection.Open();
                string query = "DELETE FROM Proveedores WHERE ProveedorID = @ProveedorID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProveedorID", txtIdProveedor.Text);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Proveedor eliminado con éxito.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el proveedor. Verifique el ID.");
                    }
                }
                connection.Close();
            }
        }
    }
}
