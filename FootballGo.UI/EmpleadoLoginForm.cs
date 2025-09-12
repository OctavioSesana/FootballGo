using Domain.Model;
using Domain.Services;
using System;
using System.Windows.Forms;

namespace FootballGo.UI
{
    public partial class EmpleadoLoginForm : Form
    {
        private readonly EmpleadoService _empleadoService;
        public Empleado? EmpleadoLogueado { get; private set; }

        public EmpleadoLoginForm()
        {
            InitializeComponent();
            _empleadoService = new EmpleadoService();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string contrasenia = txtContrasenia.Text.Trim();

            if (!int.TryParse(txtDni.Text, out int dni))
            {
                MessageBox.Show("Ingrese un DNI válido.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var empleado = _empleadoService.Login(nombre, apellido, dni, contrasenia);

            if (empleado != null)
            {
                EmpleadoLogueado = empleado;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Datos incorrectos. Verifique Nombre, Apellido, DNI y Contraseña.",
                    "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            var registroForm = new EmpleadoDetailsForm();
            if (registroForm.ShowDialog() == DialogResult.OK)
            {
                var nuevoEmpleado = registroForm.EmpleadoEditado;
                if (nuevoEmpleado != null)
                {
                    _empleadoService.Add(nuevoEmpleado);
                    MessageBox.Show("Registro exitoso. Ahora puede iniciar sesión.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
