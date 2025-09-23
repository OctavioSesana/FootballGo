using System;
using System.Windows.Forms;
using Domain.Model;
using Domain.Services;

namespace FootballGo.UI
{
    public partial class FrmCanchaEdicion : Form
    {
        private readonly CanchaService _service = new CanchaService();
        private readonly Cancha? _cancha;  // null = alta, != null = edición

        public FrmCanchaEdicion()  // Alta
        {
            InitializeComponent();
        }

        public FrmCanchaEdicion(Cancha cancha) : this()  // Edición
        {
            _cancha = cancha;     // 👈 clave: guardamos la seleccionada
        }

        private void FrmCanchaEdicion_Load(object? sender, EventArgs e)
        {
            // Estado
            cboEstado.DataSource = Enum.GetValues(typeof(EstadoCancha));

            // Número
            nudNro.Minimum = 1;

            // Tipo (5 o 7)
            cboTipoCancha.Items.Clear();
            cboTipoCancha.Items.Add(5);
            cboTipoCancha.Items.Add(7);

            // Precio
            nudPrecio.DecimalPlaces = 2;
            nudPrecio.Minimum = 0;
            nudPrecio.Maximum = 10000;

            if (_cancha != null)
            {
                // --- MODO EDICIÓN ---
                nudNro.Value = _cancha.NroCancha;
                cboEstado.SelectedItem = _cancha.EstadoCancha;
                cboTipoCancha.SelectedItem = _cancha.TipoCancha;
                nudPrecio.Value = _cancha.PrecioPorHora;
                Text = $"Editar cancha #{_cancha.NroCancha}";
            }
            else
            {
                // --- MODO ALTA ---
                cboTipoCancha.SelectedIndex = 0;
                Text = "Alta de cancha";
            }
        }

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                int nro = (int)nudNro.Value;
                var estado = (EstadoCancha)cboEstado.SelectedItem!;
                int tipo = (int)cboTipoCancha.SelectedItem!;
                decimal precio = nudPrecio.Value;

                if (_cancha == null)
                {
                    _service.Crear(nro, estado, tipo, precio);              // alta
                    MessageBox.Show("Cancha creada correctamente.", "OK");
                }
                else
                {
                    _service.Actualizar(_cancha.IdCancha, nro, estado, tipo, precio); // edición
                    MessageBox.Show("Cancha actualizada correctamente.", "OK");
                }

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
