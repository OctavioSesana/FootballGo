using Domain.Model;
using Domain.Services;
using System;
using System.Windows.Forms;

namespace FootballGo.UI
{
    public partial class ClienteDetailsForm : Form
    {
        private Cliente _cliente;
        private readonly MenuForm _menuForm;
        private readonly bool _esRegistro; // true si es registro, false si es edición

        // Constructor para agregar un nuevo cliente
        public ClienteDetailsForm(MenuForm menuForm, bool esRegistro = true, Cliente? cliente = null)
        {
            InitializeComponent();
            _menuForm = menuForm;
            _esRegistro = esRegistro;
            _cliente = cliente;

            if (_esRegistro)
            {
                Text = "Registrar Cliente";
            }
            else
            {
                Text = "Editar Perfil";
                if (_cliente != null)
                    CargarDatosEnFormulario(_cliente);
            }
        }

        // Constructor para editar un cliente existente
        public ClienteDetailsForm(Cliente clienteAEditar, MenuForm menuForm)
        {
            InitializeComponent();
            this.Text = "Editar Cliente";
            _menuForm = menuForm;
            _cliente = clienteAEditar;
            CargarDatosEnFormulario(clienteAEditar);
        }

        private void CargarDatosEnFormulario(Cliente cliente)
        {
            txtNombre.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            txtEmail.Text = cliente.Email;
            txtContrasenia.Text = cliente.Contrasenia;
            txtDNI.Text = cliente.dni.ToString();
            txtTel.Text = cliente.telefono.ToString();
            dtpFechaAlta.Value = cliente.FechaAlta;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtContrasenia.Text))
                {
                    MessageBox.Show("Debe ingresar una contraseña.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtContrasenia.Text.Length < 6)
                {
                    MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _cliente.SetNombre(txtNombre.Text);
                _cliente.SetApellido(txtApellido.Text);
                _cliente.SetEmail(txtEmail.Text);
                _cliente.SetDNI(int.Parse(txtDNI.Text));
                _cliente.SetTelefono(int.Parse(txtTel.Text));
                _cliente.SetFechaAlta(dtpFechaAlta.Value);
                _cliente.SetContrasenia(txtContrasenia.Text.Trim()); // 👈 ESTA LÍNEA ES CLAVE

                var service = new ClienteService();

                if (_cliente.Id == 0)
                    service.Add(_cliente);
                else
                    service.Update(_cliente);

                MessageBox.Show("Cliente guardado con éxito", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                var dashboard = new ClienteDashboardForm(_cliente, _menuForm);
                _menuForm.MostrarEnPanel(dashboard);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_esRegistro)
            {
                // Si era registro, volvemos al login
                _menuForm.MostrarEnPanel(new LoginForm(_menuForm));
            }
            else
            {
                // Si era edición, volvemos al dashboard del cliente
                if (_cliente != null)
                {
                    var dashboard = new ClienteDashboardForm(_cliente, _menuForm);
                    _menuForm.MostrarEnPanel(dashboard);
                }
            }
        }
    }
}
