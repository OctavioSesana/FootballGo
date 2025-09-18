using Domain.Model;
using Domain.Services;
using System;
using System.Windows.Forms;

namespace FootballGo.UI
{
    public partial class ClienteDashboardForm : Form
    {
        private Cliente _cliente;
        private readonly MenuForm _menuForm; // referencia al contenedor principal

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
            // en vez de ShowDialog(), cargamos el form en el panel principal
            var perfilForm = new ClienteDetailsForm(_cliente, _menuForm);
            _menuForm.MostrarEnPanel(perfilForm);
        }


        private void btnReservarCancha_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de reservar cancha no implementada aún.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "¿Está seguro de que desea eliminar su cuenta? Esta acción no se puede deshacer.",
                "Confirmar baja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                var service = new ClienteService();
                bool eliminado = service.Delete(_cliente.Id);

                if (eliminado)
                {
                    MessageBox.Show("Su cuenta ha sido eliminada correctamente.", "Cuenta eliminada",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Volvemos al inicio tras borrar la cuenta
                    _menuForm.MostrarBienvenida();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la cuenta. Intente nuevamente.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
