using System;
using System.Windows.Forms;
using Domain.Model;
using Domain.Services;

namespace FootballGo.UI
{
    public partial class FrmCanchas : Form
    {
        private readonly CanchaService _service = new CanchaService();

        public FrmCanchas()
        {
            InitializeComponent();
            this.Load += FrmCanchas_Load;

            // Opcionales si agregás los botones en el diseñador:
            // btnRefrescar.Click += (s,e) => CargarDatos();
            // btnCerrar.Click += (s,e) => Close();
            // btnEditar.Click += btnEditar_Click;
            // dgvCanchas.CellDoubleClick += (s,e) => { if (e.RowIndex >= 0) btnEditar_Click(s,e); };
        }

        private void FrmCanchas_Load(object? sender, EventArgs e)
        {
            ConfigurarGrilla();
            CargarDatos();
        }

        private void ConfigurarGrilla()
        {
            dgvCanchas.AutoGenerateColumns = false;
            dgvCanchas.Columns.Clear();

            dgvCanchas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Cancha.NroCancha),
                HeaderText = "N°",
                Width = 60
            });
            dgvCanchas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Cancha.EstadoCancha),
                HeaderText = "Estado",
                Width = 120
            });
            dgvCanchas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Cancha.TipoCancha),
                HeaderText = "Tipo",
                Width = 60
            });
            dgvCanchas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Cancha.PrecioPorHora),
                HeaderText = "Precio/Hora",
                Width = 100,
                DefaultCellStyle = { Format = "C2" } // moneda
            });
        }

        private void CargarDatos()
        {
            dgvCanchas.DataSource = _service.Listar();
        }

        // --- Opcional: edición desde la grilla ---
        private Cancha? Seleccionada()
        {
            return dgvCanchas.CurrentRow?.DataBoundItem as Cancha;
        }

        private void btnEditar_Click(object? sender, EventArgs e)
        {
            var sel = Seleccionada();
            if (sel == null)
            {
                MessageBox.Show("Seleccioná una cancha.", "Atención");
                return;
            }
            using var frm = new FrmCanchaEdicion(sel);
            if (frm.ShowDialog(this) == DialogResult.OK)
                CargarDatos();
        }
    }
}
