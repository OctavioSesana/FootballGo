using API.Clients;
using Domain.Model;
using Domain.Services;
using System;
using System.Windows.Forms;
using ClienteDTO = DTOs.Cliente;

namespace FootballGo.UI
{
    public partial class ClienteDashboardForm : Form
    {
        private Cliente _cliente;
        private readonly MenuForm _menuForm;
        private Form? _child;

        public ClienteDashboardForm(Cliente cliente, MenuForm menuForm)
        {
            InitializeComponent();
            _cliente = cliente;
            _menuForm = menuForm;
        }

        private void ClienteDashboardForm_Load(object sender, EventArgs e)
        {
            lblSesion.Text = $"Sesión iniciada como: {_cliente.Email} ({_cliente.Nombre} {_cliente.Apellido})";
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Volvemos a la pantalla de bienvenida sin cerrar toda la app
            _menuForm.CerrarSesion();
        }

        private void btnGestionarPerfil_Click(object sender, EventArgs e)
        {
            var dto = new ClienteDTO
            {
                Id = _cliente.Id,
                Nombre = _cliente.Nombre,
                Apellido = _cliente.Apellido,
                Email = _cliente.Email,
                dni = _cliente.dni,
                telefono = _cliente.telefono,
                FechaAlta = _cliente.FechaAlta,
                Contrasenia = _cliente.Contrasenia
            };
            var perfilForm = new ClienteDetailsForm(menuForm: _menuForm, esRegistro: false, cliente: dto);
            _menuForm.MostrarEnPanel(perfilForm);
        }


        private void btnReservarCancha_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de reservar cancha no implementada aún.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "¿Está seguro de que desea eliminar su cuenta? Esta acción no se puede deshacer.",
                "Confirmar baja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    await ClienteApiClient.DeleteAsync(_cliente.Id);

                    MessageBox.Show("Su cuenta ha sido eliminada correctamente.", "Cuenta eliminada",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Volvemos al inicio tras borrar la cuenta
                    _menuForm.MostrarEnPanel(new LoginForm(_menuForm));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo eliminar la cuenta. Detalle: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
