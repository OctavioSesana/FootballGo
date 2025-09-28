using System.Windows.Forms;
using Domain.Model;
using Domain.Services;
using EmpleadoDTO = DTOs.Empleado;

namespace FootballGo.UI
{
    public partial class EmpleadoDashboardForm : Form
    {
        private readonly Empleado _empleado;
        private readonly MenuForm _menuForm;

        private Form? _child; // form embebido actual

        public EmpleadoDashboardForm(Empleado empleado, MenuForm menuForm)
        {
            InitializeComponent();
            _empleado = empleado;
            _menuForm = menuForm;

            CrearMenu(); // armamos los ítems del menú en tiempo de ejecución
        }

        private void EmpleadoDashboardForm_Load(object? sender, System.EventArgs e)
        {
            //lblSesion.Text = $"Bienvenido! Usuario : {_empleado.Nombre} {_empleado.Apellido}";
        }

        // 👉 PÚBLICO: otros forms lo llaman para navegar dentro del panel
        public void CargarEnPanel(Form child)
        {
            if (_child != null)
            {
                _child.Close();
                _child.Dispose();
                _child = null;
            }

            _child = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;

            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(child);
            child.Show();
        }

        private void CrearMenu()
        {
            menuStrip.Items.Clear();

            // Perfil
            var mPerfil = new ToolStripMenuItem("Perfil");
            var itPerfil = new ToolStripMenuItem("Gestionar Perfil", null, btnGestionarPerfil_Click);
            var itCerrar = new ToolStripMenuItem("Cerrar Sesión", null, btnCerrarSesion_Click);
            var itBaja = new ToolStripMenuItem("Baja de Cuenta", null, btnBajaCuenta_Click);
            mPerfil.DropDownItems.AddRange(new[] { itPerfil, itCerrar, itBaja });

            // Gestión
            var mGestion = new ToolStripMenuItem("Gestión");
            var itAltaCanchas = new ToolStripMenuItem("Alta de Canchas", null, btnAlta_Click_1);
            var itListado = new ToolStripMenuItem("Listado de Canchas", null, btnListadoCanchas_Click);
            var itAltaArt = new ToolStripMenuItem("Alta de Artículos", null, btnArticulosAlta_Click_1);
            var itReservas = new ToolStripMenuItem("Gestión de Reservas", null, btnGestion_Click);
            mGestion.DropDownItems.AddRange(new[] { itAltaCanchas, itListado, itAltaArt, itReservas });

            menuStrip.Items.Add(mPerfil);
            menuStrip.Items.Add(mGestion);
        }

        // ===== Handlers del menú =====
        private void btnCerrarSesion_Click(object? sender, System.EventArgs e) => _menuForm.CerrarSesion();

        private EmpleadoDTO MapToDto(Domain.Model.Empleado e)
        {
            return new EmpleadoDTO
            {
                IdEmpleado = e.Id,
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                Dni = e.Dni,
                Contrasenia = e.contrasenia,
                SueldoSemanal = e.SueldoSemanal,
                EstaActivo = e.EstaActivo,
                FechaIngreso = e.FechaIngreso
            };
        }


        private void btnGestionarPerfil_Click(object? sender, System.EventArgs e)
        {
            // Corregimos el constructor para que coincida con la firma esperada
            var perfilForm = new EmpleadoDetailsForm(MapToDto(_empleado), _menuForm);
            _menuForm.MostrarEnPanel(perfilForm);
        }

        private async void btnBajaCuenta_Click(object? sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "¿Está seguro de que desea eliminar su cuenta de empleado? Esta acción no se puede deshacer.",
                "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                // Llamamos al back usando la API REST
                await API.Clients.EmpleadoApiClient.DeleteAsync(_empleado.Id);

                MessageBox.Show("Cuenta eliminada correctamente.", "OK");
                DialogResult = DialogResult.Abort;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo eliminar la cuenta. Detalle: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnArticulosAlta_Click_1(object? sender, System.EventArgs e)
        {
            MessageBox.Show("Funcionalidad de alta de artículos no implementada.", "Info");
        }

        private void btnGestion_Click(object? sender, System.EventArgs e)
        {
            MessageBox.Show("Funcionalidad de gestión de reservas no implementada.", "Info");
        }

        // ------- Navegación embebida -------
        private void btnAlta_Click_1(object? sender, System.EventArgs e)
        {
            CargarEnPanel(new FrmCanchaEdicion());   // alta en el mismo form
        }

        private void btnListadoCanchas_Click(object? sender, System.EventArgs e)
        {
            CargarEnPanel(new FrmCanchas());         // listado en el mismo form
        }

        private void contentPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
