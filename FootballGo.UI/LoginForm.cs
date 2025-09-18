using Domain.Services;
using Domain.Model;
using System;
using System.Windows.Forms;

namespace FootballGo.UI
{
    public partial class LoginForm : Form
    {
        private readonly ClienteService _clienteService;
        private readonly MenuForm _menuForm;

        public Cliente? ClienteLogueado { get; private set; }

        // ahora recibe referencia al MenuForm
        public LoginForm(MenuForm menuForm)
        {
            InitializeComponent();
            _clienteService = new ClienteService();
            _menuForm = menuForm;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim();
            var pass = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Debe ingresar Email y Contraseña", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cliente = _clienteService.Login(email, pass);

            if (cliente != null)
            {
                ClienteLogueado = cliente;

                // Mostrar bienvenida en el MenuForm
                _menuForm.MostrarBienvenidaUsuario(cliente.Nombre, cliente.Apellido, "Cliente");

                // Mostrar dashboard en el panel
                var dashboard = new ClienteDashboardForm(cliente, _menuForm);
                _menuForm.MostrarEnPanel(dashboard);
            }
            else
            {
                MessageBox.Show("Email o contraseña incorrectos", "Error de acceso",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            // Mostrar el formulario de registro dentro del mismo panel
            var registroForm = new ClienteDetailsForm(_menuForm, esRegistro: true);
            _menuForm.MostrarEnPanel(registroForm);
        }
    }
}
