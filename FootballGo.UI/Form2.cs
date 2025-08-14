using Domain.Model;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FootballGo.UI
{
    public partial class Form2 : Form
    {
        private readonly EmpleadoService _empleadoService = new EmpleadoService();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
        }

        private void CargarEmpleados()
        {
            try
            {
                IEnumerable<Empleado> empleados = _empleadoService.GetAll();
                dgvCliente.DataSource = null;
                dgvCliente.DataSource = empleados.ToList();
                dgvCliente.ReadOnly = true;
                dgvCliente.AllowUserToAddRows = false;
                dgvCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvCliente.MultiSelect = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar los empleados: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using var frm = new EmpleadoDetailsForm();
            if (frm.ShowDialog(this) == DialogResult.OK && frm.EmpleadoEditado != null)
            {
                _empleadoService.Add(frm.EmpleadoEditado);
                CargarEmpleados();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCliente.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un empleado para editar.");
                return;
            }

            var seleccionado = dgvCliente.SelectedRows[0].DataBoundItem as Empleado;
            if (seleccionado == null)
            {
                MessageBox.Show("No se pudo obtener el empleado.");
                return;
            }

            using var frm = new EmpleadoDetailsForm(seleccionado);
            if (frm.ShowDialog(this) == DialogResult.OK && frm.EmpleadoEditado != null)
            {
                _empleadoService.Update(frm.EmpleadoEditado);
                CargarEmpleados();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCliente.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un empleado para eliminar.");
                return;
            }

            var seleccionado = dgvCliente.SelectedRows[0].DataBoundItem as Empleado;
            if (seleccionado == null) { MessageBox.Show("No se pudo obtener el empleado."); return; }

            if (MessageBox.Show(
                    $"¿Está seguro de eliminar a {seleccionado.Nombre} {seleccionado.Apellido}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _empleadoService.Delete(seleccionado.IdEmpleado);
                CargarEmpleados();
            }
        }
    }
}
