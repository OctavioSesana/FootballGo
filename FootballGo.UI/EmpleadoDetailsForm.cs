using Domain.Model;
using Domain.Services;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace FootballGo.UI
{
    public partial class EmpleadoDetailsForm : Form
    {
        private Empleado _empleado;
        private readonly MenuForm _menuForm;
        private readonly bool _esRegistro; // true si es registro, false si es edición

        // Constructor para nuevo empleado
        public EmpleadoDetailsForm(MenuForm menuForm, bool esRegistro = true, Empleado? empleado = null)
        {
            InitializeComponent();
            _menuForm = menuForm;
            _esRegistro = esRegistro;
            _empleado = empleado ?? new Empleado();

            if (_esRegistro)
            {
                Text = "Registrar Cliente";
            }
            else
            {
                Text = "Editar Perfil";
                if (_empleado != null)
                    CargarDatosEnFormulario(_empleado);
            }
        }

        // Constructor para edición
        public EmpleadoDetailsForm(Empleado empleadoAEditar, MenuForm menuForm)
        {
            InitializeComponent();
            this.Text = "Editar Empleado";
            _menuForm = menuForm;
            _empleado = empleadoAEditar;
            CargarDatosEnFormulario(empleadoAEditar);
        }

        private void CargarDatosEnFormulario(Empleado empleado)
        {
            txtNombre.Text = empleado.Nombre;
            txtApellido.Text = empleado.Apellido;
            txtDNI.Text = empleado.Dni.ToString();
            txtSueldo.Text = empleado.SueldoSemanal.ToString("N2", CultureInfo.CurrentCulture);
            dtpFechaIngreso.Value = empleado.FechaIngreso;
            txtContrasenia.Text = empleado.contrasenia;
        }

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            { MessageBox.Show("El nombre es obligatorio."); return; }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            { MessageBox.Show("El apellido es obligatorio."); return; }

            if (!int.TryParse(txtDNI.Text.Trim(), out int dni))
            {
                MessageBox.Show("DNI inválido.");
                return;
            }

            var sueldoTxt = txtSueldo.Text.Trim();
            decimal sueldo;
            if (!decimal.TryParse(sueldoTxt, NumberStyles.Number, CultureInfo.CurrentCulture, out sueldo))
            {
                var normalized = sueldoTxt.Replace(".", "").Replace(",", ".");
                if (!decimal.TryParse(normalized, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out sueldo))
                {
                    MessageBox.Show("Sueldo inválido.");
                    return;
                }
            }

            try
            {
                _empleado.SetNombre(txtNombre.Text.Trim());
                _empleado.SetApellido(txtApellido.Text.Trim());
                _empleado.SetDni(dni);
                _empleado.SetSueldoSemanal(sueldo);
                _empleado.SetFechaIngreso(dtpFechaIngreso.Value);
                _empleado.SetContrasenia(txtContrasenia.Text.Trim());

                var service = new EmpleadoService();
                if (_empleado.Id == 0)
                {
                    service.Add(_empleado);
                }
                else
                {
                    service.Update(_empleado);
                }

                MessageBox.Show("Empleado guardado con éxito", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // volvemos al dashboard
                var dashboard = new EmpleadoDashboardForm(_empleado, _menuForm);
                _menuForm.MostrarEnPanel(dashboard);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_esRegistro)
            {
                // Si era registro, volvemos al login
                _menuForm.MostrarEnPanel(new EmpleadoLoginForm(_menuForm));
            }
            else
            {
                // Si era edición, volvemos al dashboard del cliente
                if (_empleado != null)
                {
                    var dashboard = new EmpleadoDashboardForm(_empleado, _menuForm);
                    _menuForm.MostrarEnPanel(dashboard);
                }
            }
        }

    }
}
