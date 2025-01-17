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
    public partial class EliminarCategoria : Form
    {
        public EliminarCategoria()
        {
            InitializeComponent();
        }
        private string connectionString = "Server = localhost\\SQLEXPRESS02;Database=InventarioDB;Trusted_Connection=True;";

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(btnEliminar.Text))
            {
                MessageBox.Show("Ingresa el ID de una categoria");
                return;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Categorias WHERE CategoriaID = @CategoriaID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoriaID", txtIdCategoria.Text);
                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Categoría eliminada con éxito.");
                        this.Close();
                    }
                    else
                    {

                    }
                }
                connection.Close();
            }
        }
    }
}
