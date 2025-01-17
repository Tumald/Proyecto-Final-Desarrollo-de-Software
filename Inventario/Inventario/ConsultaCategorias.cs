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
    public partial class ConsultaCategorias : Form
    {
        public ConsultaCategorias()
        {
            InitializeComponent();
        }
        private string connectionString = "Server = localhost\\SQLEXPRESS02;Database=InventarioDB;Trusted_Connection=True;";

        private void btnCerrar_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ConsultaCategorias_Load(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Categorias"; 

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridViewCategorias.DataSource = dataTable;
                }
            }
        }
    }
}
