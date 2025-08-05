using Domain.Model;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FootballGo.UI
{
    public partial class Form1 : Form
    {
        private ClienteService _clienteService;

        public Form1()
        {
            InitializeComponent();
            _clienteService = new ClienteService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                // Usamos el servicio para obtener la lista de clientes
                // Este método GetAll() ahora usará la clase ClienteInMemory que está en tu capa Data
                IEnumerable<Cliente> clientes = _clienteService.GetAll();
                dgvCliente.DataSource = clientes.ToList();
                dgvCliente.ReadOnly = true;
                dgvCliente.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar los clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Verifica si hay una fila seleccionada
            if (dgvCliente.SelectedRows.Count > 0)
            {
                // Obtiene el objeto Cliente completo desde la fila seleccionada
                var clienteSeleccionado = (Cliente)dgvCliente.SelectedRows[0].DataBoundItem;

                // Muestra un mensaje de confirmación
                DialogResult dialogResult = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar a {clienteSeleccionado.Nombre} {clienteSeleccionado.Apellido}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    // Llama al método Delete del servicio
                    bool eliminado = _clienteService.Delete(clienteSeleccionado.Id);

                    if (eliminado)
                    {
                        MessageBox.Show("Cliente eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Recargamos el DataGridView para reflejar el cambio
                        CargarClientes();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el cliente. El ID podría no existir.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Verifica si hay una fila seleccionada
            if (dgvCliente.SelectedRows.Count > 0)
            {
                // Obtiene el cliente seleccionado del DataGridView
                Cliente? clienteSeleccionado = dgvCliente.SelectedRows[0].DataBoundItem as Cliente;

                if (clienteSeleccionado != null)
                {
                    // Creamos una nueva instancia del formulario de detalles, pasándole el cliente a editar
                    ClienteDetailsForm clienteDetailsForm = new ClienteDetailsForm(clienteSeleccionado);
                    DialogResult result = clienteDetailsForm.ShowDialog();

                    // Si el usuario guardó (hizo clic en el botón Guardar)
                    if (result == DialogResult.OK)
                    {
                        Cliente? clienteActualizado = clienteDetailsForm.ClienteResult;
                        if (clienteActualizado != null)
                        {
                            // Llama al servicio para actualizar el cliente
                            _clienteService.Update(clienteActualizado);

                            // Recarga la lista para que se muestren los datos actualizados
                            CargarClientes();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Creamos una nueva instancia del formulario de detalles
            ClienteDetailsForm clienteDetailsForm = new ClienteDetailsForm();

            // Mostramos el formulario de forma modal (bloquea el formulario principal)
            DialogResult result = clienteDetailsForm.ShowDialog();

            // Si el usuario guardó (hizo clic en el botón Guardar)
            if (result == DialogResult.OK)
            {
                Cliente? nuevoCliente = clienteDetailsForm.ClienteResult;

                if (nuevoCliente != null)
                {
                    // Llama al servicio para agregar el nuevo cliente
                    _clienteService.Add(nuevoCliente);

                    // Recarga la lista para que el nuevo cliente aparezca en la tabla
                    CargarClientes();
                }
            }
        }
    }
}