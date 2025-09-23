using System;
using System.Windows.Forms;
using Domain.Model;       // EstadoCancha
using Domain.Services;    // CanchaService

namespace FootballGo.UI
{
    public partial class FrmCanchaEdicion : Form
    {
        private readonly CanchaService _service = new CanchaService();

        public FrmCanchaEdicion()
        {
            InitializeComponent();
            // Si el diseñador no creó estos handlers:
            // this.Load += FrmCanchaEdicion_Load;
            // btnGuardar.Click += btnGuardar_Click;
            // btnCancelar.Click += btnCancelar_Click;
        }

        private void FrmCanchaEdicion_Load(object? sender, EventArgs e)
        {
            // Estado de cancha
            cboEstado.DataSource = Enum.GetValues(typeof(EstadoCancha));

            // Nro
            nudNro.Minimum = 1;

            // Tipo (5 o 7)
            cboTipoCancha.Items.Clear();
            cboTipoCancha.Items.Add(5);
            cboTipoCancha.Items.Add(7);
            cboTipoCancha.SelectedIndex = 0;

            // Precio
            nudPrecio.DecimalPlaces = 2;
            nudPrecio.Minimum = 0;
            nudPrecio.Maximum = 10000; // ajustá a tu realidad

            Text = "Alta de cancha";
        }

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                int nro = (int)nudNro.Value;
                var estado = (EstadoCancha)cboEstado.SelectedItem!;
                int tipo = (int)cboTipoCancha.SelectedItem!;
                decimal precio = nudPrecio.Value;

                // 👇 NUEVA firma con tipo + precio
                _service.Crear(nro, estado, tipo, precio);

                MessageBox.Show("Cancha creada correctamente.",
                    "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
