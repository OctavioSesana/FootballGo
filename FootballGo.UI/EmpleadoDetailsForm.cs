using System;
using System.Globalization;
using System.Windows.Forms;
using Domain.Model;

namespace FootballGo.UI
{
    public partial class EmpleadoDetailsForm : Form
    {
        public Empleado? EmpleadoEditado { get; private set; }

        public EmpleadoDetailsForm(Empleado? original = null)
        {
            InitializeComponent();
            Text = original == null ? "Nuevo empleado" : "Editar empleado";

            if (original != null)
            {
                // clonado superficial: conservar Id
                EmpleadoEditado = new Empleado();
                EmpleadoEditado.SetId(original.Id);

                txtNombre.Text = original.Nombre;
                txtApellido.Text = original.Apellido;
                txtDNI.Text = original.Dni.ToString();
                txtSueldo.Text = original.SueldoSemanal.ToString("0.##");
                // chkActivo.Checked = original.EstaActivo;
                dtpFechaIngreso.Value = original.FechaIngreso;
                txtContrasenia.Text = original.contrasenia;
            }
            else
            {
                EmpleadoEditado = new Empleado();
                dtpFechaIngreso.Value = DateTime.Now;
            }
        }

        // ==== ESTE MÉTODO ES EL QUE FALTA ====
        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            { MessageBox.Show("El nombre es obligatorio."); return; }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            { MessageBox.Show("El apellido es obligatorio."); return; }

            if (!int.TryParse(txtDNI.Text.Trim(), out int dni))
            {
                MessageBox.Show("DNI inválido.");
                return;
            }

            // 1) Intento con cultura actual (es-AR / es-ES etc)
            var sueldoTxt = txtSueldo.Text.Trim();
            decimal sueldo;
            if (!decimal.TryParse(sueldoTxt, NumberStyles.Number, CultureInfo.CurrentCulture, out sueldo))
            {
                // 2) Plan B: normalizo (quito miles y uso punto como decimal)
                var normalized = sueldoTxt.Replace(".", "").Replace(",", ".");
                if (!decimal.TryParse(normalized, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out sueldo))
                {
                    MessageBox.Show("Sueldo inválido.");
                    return;
                }
            }

            EmpleadoEditado!.SetNombre(txtNombre.Text.Trim());
            EmpleadoEditado!.SetApellido(txtApellido.Text.Trim());
            // EmpleadoEditado!.SetDni(txtDNI.Text.Trim());
            EmpleadoEditado!.SetDni(dni);
            EmpleadoEditado!.SetSueldoSemanal(sueldo);                       // ← AHORA SE GUARDA
                                                                             // EmpleadoEditado!.SetEstaActivo(chkActivo.Checked);
            EmpleadoEditado!.SetFechaIngreso(dtpFechaIngreso.Value);
            EmpleadoEditado!.SetContrasenia(txtContrasenia.Text.Trim());

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; // cierra el form sin guardar
        }

        private void lblMail_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
