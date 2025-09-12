using Domain.Model;
using Domain.Services;
using System;
using System.Windows.Forms;

namespace FootballGo.UI
{
    public partial class EmpleadoDashboardForm : Form
    {
        private Empleado _empleado;

        public EmpleadoDashboardForm(Empleado empleado)
        {
            InitializeComponent();
            _empleado = empleado;
        }

        private void EmpleadoDashboardForm_Load(object sender, EventArgs e)
        {
            lblSesion.Text = $"Sesión iniciada como: ({_empleado.Nombre} {_empleado.Apellido})";
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort; // vuelve al login/menú
            Close();
        }

        private void btnGestionarPerfil_Click(object sender, EventArgs e)
        {
            var perfilForm = new EmpleadoDetailsForm(_empleado);
            if (perfilForm.ShowDialog() == DialogResult.OK)
            {
                var empleadoActualizado = perfilForm.EmpleadoEditado;
                if (empleadoActualizado != null)
                {
                    var service = new EmpleadoService();
                    if (service.Update(empleadoActualizado))
                    {
                        MessageBox.Show("Perfil actualizado con éxito", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // refresco el objeto local
                        _empleado = empleadoActualizado;
                        lblSesion.Text = $"Sesión iniciada como: ({_empleado.Nombre} {_empleado.Apellido})";
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el perfil", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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

        private void btnAlta_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de alta de empleados no implementada.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGestion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de gestión de empleados no implementada.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
