using Domain.Model;
using Domain.Services;
using System;
using System.Windows.Forms;

namespace FootballGo.UI
{
    public partial class EmpleadoDashboardForm : Form
    {
        private Empleado _empleado;
        private readonly MenuForm _menuForm;

        public EmpleadoDashboardForm(Empleado empleado, MenuForm menuForm)
        {
            InitializeComponent();
            _empleado = empleado;
            _menuForm = menuForm;
        }

        private void EmpleadoDashboardForm_Load(object sender, EventArgs e)
        {
            lblSesion.Text = $"Sesión iniciada como: ({_empleado.Nombre} {_empleado.Apellido})";
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            _menuForm.CerrarSesion();
        }

        private void btnGestionarPerfil_Click(object sender, EventArgs e)
        {

            var perfilForm = new EmpleadoDetailsForm(_empleado, _menuForm);
            _menuForm.MostrarEnPanel(perfilForm);
        }

        private void btnBajaCuenta_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "¿Está seguro de que desea eliminar su cuenta de empleado? Esta acción no se puede deshacer.",
                "Confirmar baja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                var service = new EmpleadoService();
                bool eliminado = service.Delete(_empleado.Id);

                if (eliminado)
                {
                    MessageBox.Show("Su cuenta ha sido eliminada correctamente.", "Cuenta eliminada",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void btnAlta_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de alta de canchas no implementada.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnArticulosAlta_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de alta de artículos no implementada.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGestion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de gestión de reservas no implementada.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
