using Domain.Model;
using Domain.Services;
using System;
using System.Windows.Forms;

namespace FootballGo.UI
{
    public partial class ClienteDashboardForm : Form
    {
        private Cliente _cliente; // Removed readonly modifier

        public ClienteDashboardForm(Cliente cliente)
        {
            InitializeComponent();
            _cliente = cliente;
        }

        private void ClienteDashboardForm_Load(object sender, EventArgs e)
        {
            lblSesion.Text = $"Sesión iniciada como: {_cliente.Email} ({_cliente.Nombre} {_cliente.Apellido})";
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort; // vuelve al login
            Close();
        }

        private void btnGestionarPerfil_Click(object sender, EventArgs e)
        {
            var perfilForm = new ClienteDetailsForm(_cliente);
            if (perfilForm.ShowDialog() == DialogResult.OK)
            {
                var clienteActualizado = perfilForm.ClienteResult;
                if (clienteActualizado != null)
                {
                    var service = new ClienteService();
                    if (service.Update(clienteActualizado))
                    {
                        MessageBox.Show("Perfil actualizado con éxito", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // refresco el objeto local
                        _cliente = clienteActualizado;
                        lblSesion.Text = $"Sesión iniciada como: {_cliente.Email} ({_cliente.Nombre} {_cliente.Apellido})";
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el perfil", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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

                    // Cerrar sesión y volver al login/menú
                    DialogResult = DialogResult.Abort;
                    Close();
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
