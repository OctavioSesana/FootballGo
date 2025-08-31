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
            var formClientes = (Form1)_provider.GetService(typeof(Form1));
            formClientes.ShowDialog();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            var formEmpleados = (Form2)_provider.GetService(typeof(Form2));
            formEmpleados.ShowDialog();
        }
    }
}
