using DeliveryAppGrupo0008.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryAppGrupo0008.Forms
{
    public partial class ClienteDashboardForm : Form
    {
        private Usuario _usuario;
        public ClienteDashboardForm(Usuario usuario)
        {
            _usuario = usuario;
            InitializeComponent();
            Text = "Panel de clientes";
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClienteDashboardForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Bienvenido Cliente";
        }

    }
}
