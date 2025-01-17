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
    public partial class AgregarCategoria : Form
    {
        public AgregarCategoria()
        {
            InitializeComponent();
        }

        private string connectionString = "Server=localhost\\SQLEXPRESS02;Database=InventarioDB;Trusted_Connection=True;";

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Categorias (Nombre) VALUES (@Nombre)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", txtNombreCategoria.Text);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Categoría agregada con éxito.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar la categoría.");
                    }
                }
                connection.Close();
            }
        }
    }
}
