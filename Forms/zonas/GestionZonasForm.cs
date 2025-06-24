using DeliveryAppGrupo0008.Models;
using DeliveryAppGrupo0008.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DeliveryAppGrupo0008.Forms.zonas
{
    public partial class GestionZonasForm : Form
    {
        private ZoneService _zonaService;

        public GestionZonasForm(ZoneService zonaService)
        {
            InitializeComponent();
            _zonaService = zonaService;

            btnAgregarZona.Click += BtnAgregarZona_Click;
        }

        private void GestionZonasForm_Load(object sender, EventArgs e)
        {
            CargarZonasEnGrid();
        }

        private void CargarZonasEnGrid()
        {
            var zonas = _zonaService.GetZonas()
                .Select(z => new
                {
                    z.ZonaID,
                    z.Nombre,
                    z.Descripcion,
                    PrecioDelivery = z.PrecioDelivery.ToString("C")
                }).ToList();

            dgvZonas.DataSource = zonas;
            dgvZonas.Columns["ZonaID"].HeaderText = "ID";
            dgvZonas.Columns["Nombre"].HeaderText = "Nombre";
            dgvZonas.Columns["Descripcion"].HeaderText = "Descripción";
            dgvZonas.Columns["PrecioDelivery"].HeaderText = "Precio Delivery";
        }

        private void BtnAgregarZona_Click(object sender, EventArgs e)
        {

            string nombre = txtNombre.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();
            bool precioValido = decimal.TryParse(txtPrecioDelivery.Text.Trim(), out decimal precio);

            if (string.IsNullOrEmpty(nombre) || !precioValido)
            {
                MessageBox.Show("Complete todos los campos correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool exito = _zonaService.RegistrarZona(nombre, descripcion, precio);

            if (exito)
            {
                MessageBox.Show("Zona agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Clear();
                txtDescripcion.Clear();
                txtPrecioDelivery.Clear();
                CargarZonasEnGrid();
                tabControlZonas.SelectedTab = tabPageLista;
            }
            else
            {
                MessageBox.Show("Ocurrió un error al agregar la zona.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
