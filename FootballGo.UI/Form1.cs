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
        private readonly ClienteService _clienteService;

        public Form1(ClienteService clienteService)
        {
            InitializeComponent();
            _clienteService = clienteService;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                IEnumerable<Cliente> clientes = _clienteService.GetAll();
                dgvCliente.DataSource = clientes.ToList();
                dgvCliente.ReadOnly = true;
                dgvCliente.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar los clientes: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCliente.SelectedRows.Count > 0)
            {
                var clienteSeleccionado = (Cliente)dgvCliente.SelectedRows[0].DataBoundItem;

                var confirm = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar a {clienteSeleccionado.Nombre} {clienteSeleccionado.Apellido}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    bool eliminado = _clienteService.Delete(clienteSeleccionado.Id);

                    if (eliminado)
                    {
                        MessageBox.Show("Cliente eliminado exitosamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarClientes();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el cliente. El ID podría no existir.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para eliminar.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCliente.SelectedRows.Count > 0)
            {
                Cliente? clienteSeleccionado = dgvCliente.SelectedRows[0].DataBoundItem as Cliente;

                if (clienteSeleccionado != null)
                {
                    var clienteDetailsForm = new ClienteDetailsForm(clienteSeleccionado);
                    if (clienteDetailsForm.ShowDialog() == DialogResult.OK)
                    {
                        Cliente? clienteActualizado = clienteDetailsForm.ClienteResult;
                        if (clienteActualizado != null)
                        {
                            _clienteService.Update(clienteActualizado);
                            CargarClientes();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para editar.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var clienteDetailsForm = new ClienteDetailsForm();

            if (clienteDetailsForm.ShowDialog() == DialogResult.OK)
            {
                Cliente? nuevoCliente = clienteDetailsForm.ClienteResult;
                if (nuevoCliente != null)
                {
                    _clienteService.Add(nuevoCliente);
                    CargarClientes();
                }
            }
        }
    }
}
