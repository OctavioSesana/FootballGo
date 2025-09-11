using Domain.Services;
using Domain.Model;
using System;
using System.Windows.Forms;

namespace FootballGo.UI
{
    public partial class LoginForm : Form
    {
        private readonly ClienteService _clienteService;

        public Cliente? ClienteLogueado { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            _clienteService = new ClienteService();
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
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Email o contraseña incorrectos", "Error de acceso",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            var registroForm = new ClienteDetailsForm();
            if (registroForm.ShowDialog() == DialogResult.OK)
            {
                var nuevoCliente = registroForm.ClienteResult;
                if (nuevoCliente != null)
                {
                    _clienteService.Add(nuevoCliente);
                    MessageBox.Show("Registro exitoso. Ahora puede iniciar sesión.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
