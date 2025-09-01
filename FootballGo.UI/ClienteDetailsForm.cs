using Domain.Model;
using System;
using System.Windows.Forms;

namespace FootballGo.UI
{
    public partial class ClienteDetailsForm : Form
    {
        // Esta variable guardará el cliente que estamos editando. Si es nulo, estamos agregando uno nuevo.
        private Cliente? _cliente;

        // Constructor para agregar un nuevo cliente
        public ClienteDetailsForm()
        {
            InitializeComponent();
            this.Text = "Agregar Cliente";
        }

        // Constructor para editar un cliente existente
        public ClienteDetailsForm(Cliente clienteAEditar)
        {
            InitializeComponent();
            this.Text = "Editar Cliente";
            _cliente = clienteAEditar;
            CargarDatosEnFormulario(clienteAEditar);
        }

        // Método para cargar los datos del cliente en los controles del formulario
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

        // Lógica del botón Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) || string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                MessageBox.Show("Por favor, complete al menos el nombre, apellido y DNI.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Si _cliente es nulo, estamos creando un nuevo cliente
                if (_cliente == null)
                {
                    // Crea un nuevo cliente con un ID temporal. El servicio asignará el ID final.
                    _cliente = new Cliente(
                        0, // ID temporal, el servicio lo actualizará
                        txtNombre.Text,
                        txtApellido.Text,
                        txtEmail.Text,
                        int.Parse(txtDNI.Text),
                        int.Parse(txtTel.Text),
                        dtpFechaAlta.Value,
                        txtContrasenia.Text
                    );
                }
                else
                {
                    // Si _cliente no es nulo, estamos editando uno existente
                    _cliente.SetNombre(txtNombre.Text);
                    _cliente.SetApellido(txtApellido.Text);
                    _cliente.SetEmail(txtEmail.Text);
                    _cliente.SetDNI(int.Parse(txtDNI.Text));
                    _cliente.SetTelefono(int.Parse(txtTel.Text));
                    _cliente.SetFechaAlta(dtpFechaAlta.Value);
                    _cliente.SetContrasenia(txtContrasenia.Text);
                }

                // Indica que la operación fue exitosa
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ArgumentException ex)
            {
                // Captura las excepciones de validación de la clase Cliente
                MessageBox.Show(ex.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Captura otros errores, como la conversión de tipos
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Lógica del botón Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Simplemente cierra el formulario sin hacer nada
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ClienteDetailsForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Propiedad para acceder al cliente desde el formulario principal
        public Cliente? ClienteResult => _cliente;
    }
}