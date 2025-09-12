using System;
using System.Windows.Forms;
using Domain.Services;

namespace FootballGo.UI
{
    public partial class MenuForm : Form
    {
        private readonly IServiceProvider _provider;

        public MenuForm(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            var loginForm = (LoginForm)_provider.GetService(typeof(LoginForm));
            if (loginForm.ShowDialog() == DialogResult.OK && loginForm.ClienteLogueado != null)
            {
                var dashboard = new ClienteDashboardForm(loginForm.ClienteLogueado);
                dashboard.ShowDialog();
            }
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            var loginForm = (EmpleadoLoginForm)_provider.GetService(typeof(EmpleadoLoginForm));
            if (loginForm.ShowDialog() == DialogResult.OK && loginForm.EmpleadoLogueado != null)
            {
                var dashboard = new EmpleadoDashboardForm(loginForm.EmpleadoLogueado);
                dashboard.ShowDialog();
            }
        }
    }
}
