using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario
{
    public partial class ConsultarProveedores : Form
    {
        public ConsultarProveedores()
        {
            InitializeComponent();
        }
        private string connectionString = "Server = localhost\\SQLEXPRESS02;Database=InventarioDB;Trusted_Connection=True;";
        private void dataGridViewProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCargarProveedores_Click(object sender, EventArgs e)
        {
            CargarProveedores();
        }
        private void CargarProveedores()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT ProveedorID, Nombre, Contacto, Direccion, Telefono FROM Proveedores";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        dataGridViewProveedores.DataSource = dataTable;
                    }
                }
                

                
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al conectar con la base de datos" + ex.Message);

            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrio un error" + ex.Message);
            }
        }
    }
}
