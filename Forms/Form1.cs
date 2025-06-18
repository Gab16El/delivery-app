using System;
using System.Linq;
using System.Windows.Forms;

namespace DeliveryAppGrupo0008
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Llamamos a la función para cargar datos cuando se inicie el formulario
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                var clientes = Program.DbContext.Clientes.ToList();

                dgvClientes.DataSource = clientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando clientes: {ex.Message}");
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
