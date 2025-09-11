using Domain.Model;
using System;
using System.Windows.Forms;

namespace FootballGo.UI
{
    public partial class ClienteDashboardForm : Form
    {
        private readonly Cliente _cliente;

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
                MessageBox.Show("Perfil actualizado con éxito", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReservarCancha_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de reservar cancha no implementada aún.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
