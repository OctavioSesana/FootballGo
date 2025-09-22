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
            InicializarMenu();
        }

        private void InicializarMenu()
        {
            var menuStrip = new MenuStrip();

            var perfilMenu = new ToolStripMenuItem("Perfil");
            perfilMenu.BackColor = System.Drawing.Color.LightGreen;
            perfilMenu.ForeColor = System.Drawing.Color.DarkGreen;

            var gestionarPerfilItem = new ToolStripMenuItem("Gestionar Perfil", null, (s, e) => btnGestionarPerfil_Click(s, e));
            gestionarPerfilItem.BackColor = System.Drawing.Color.LightGray;
            gestionarPerfilItem.ForeColor = System.Drawing.Color.DimGray;
            perfilMenu.DropDownItems.Add(gestionarPerfilItem);

            var cerrarSesionItem = new ToolStripMenuItem("Cerrar Sesión", null, (s, e) => btnCerrarSesion_Click(s, e));
            cerrarSesionItem.BackColor = System.Drawing.Color.LightBlue;
            cerrarSesionItem.ForeColor = System.Drawing.Color.DarkBlue;
            perfilMenu.DropDownItems.Add(cerrarSesionItem);

            var bajaCuentaItem = new ToolStripMenuItem("Baja de Cuenta", null, (s, e) => btnBajaCuenta_Click(s, e));
            bajaCuentaItem.BackColor = System.Drawing.Color.LightSalmon;
            bajaCuentaItem.ForeColor = System.Drawing.Color.DarkRed;
            perfilMenu.DropDownItems.Add(bajaCuentaItem);

            var gestionMenu = new ToolStripMenuItem("Gestión");
            var altaCanchasItem = new ToolStripMenuItem("Alta de Canchas", null, (s, e) => btnAlta_Click_1(s, e));
            altaCanchasItem.BackColor = System.Drawing.Color.LightGray;
            altaCanchasItem.ForeColor = System.Drawing.Color.DimGray;
            gestionMenu.DropDownItems.Add(altaCanchasItem);

            var altaArticulosItem = new ToolStripMenuItem("Alta de Artículos", null, (s, e) => btnArticulosAlta_Click_1(s, e));
            altaArticulosItem.BackColor = System.Drawing.Color.LightGray;
            altaArticulosItem.ForeColor = System.Drawing.Color.DimGray;
            gestionMenu.DropDownItems.Add(altaArticulosItem);

            var gestionReservasItem = new ToolStripMenuItem("Gestión de Reservas", null, (s, e) => btnGestion_Click(s, e));
            gestionReservasItem.BackColor = System.Drawing.Color.LightGray;
            gestionReservasItem.ForeColor = System.Drawing.Color.DimGray;
            gestionMenu.DropDownItems.Add(gestionReservasItem);

            menuStrip.Items.Add(perfilMenu);
            menuStrip.Items.Add(gestionMenu);

            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
            menuStrip.Dock = DockStyle.Top;
        }

        private void EmpleadoDashboardForm_Load(object sender, EventArgs e)
        {
            //lblSesion.Text = $"Sesión iniciada como: ({_empleado.Nombre} {_empleado.Apellido})";
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

        private void btnClientes_Click(object sender, EventArgs e)
        {
            // Paso 1: Verificar si ya existe un control de tipo DataGridView para evitar duplicados
            var dgvExistente = this.Controls["dgvClientesEmbed"];
            if (dgvExistente != null)
            {
                dgvExistente.BringToFront();
                return;
            }

            // Paso 2: Obtener la lista de clientes usando ClienteService
            var clienteService = new ClienteService();
            var clientes = clienteService.GetAll();

            // Paso 3: Crear y configurar el DataGridView
            var dgv = new DataGridView
            {
                Name = "dgvClientesEmbed",
                DataSource = clientes.ToList(),
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Location = new System.Drawing.Point(10, 60), // Debajo del botón (ajustar según sea necesario)
                Width = this.ClientSize.Width - 20,
                Height = 250,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            // Paso 4: Agregar el DataGridView al formulario
            this.Controls.Add(dgv);
            dgv.BringToFront();
        }
    }
}