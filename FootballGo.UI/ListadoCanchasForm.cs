using FootballGo.UI;
using Newtonsoft.Json;
using Domain.Model;
using Domain.Services;

namespace MisCanchasApp
{
    public partial class ListadoCanchasForm : Form
    {
        private readonly CanchaService _service = new CanchaService();
        private readonly string _mailUsuario;

        public ListadoCanchasForm(string mailUsuario)
        {
            InitializeComponent();
            Load += ListadoCanchasForm_Load;
            dgvCanchas.CellClick += dgvCanchas_CellClick;
            _mailUsuario = mailUsuario;
        }

        private async void ListadoCanchasForm_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();
            await CargarCanchasAsync();
        }

        private void ConfigurarGrilla()
        {
            dgvCanchas.AutoGenerateColumns = false;
            dgvCanchas.Columns.Clear();

            // N°
            dgvCanchas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Cancha.NroCancha),
                HeaderText = "N°",
                Width = 60
            });

            // Estado
            dgvCanchas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Cancha.EstadoCancha),
                HeaderText = "Estado",
                Width = 120
            });

            // Tipo
            dgvCanchas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Cancha.TipoCancha),
                HeaderText = "Tipo",
                Width = 80
            });

            // Precio/Hora
            dgvCanchas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Cancha.PrecioPorHora),
                HeaderText = "Precio/Hora",
                Width = 120,
                DefaultCellStyle = { Format = "C2" }
            });

            // Botón Reservar
            var btnReservar = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "Reservar",
                Text = "Reservar",
                UseColumnTextForButtonValue = true,
                Width = 100,
                FlatStyle = FlatStyle.Flat
            };
            dgvCanchas.Columns.Add(btnReservar);

            dgvCanchas.CellFormatting += (s, e) =>
            {
                if (dgvCanchas.Columns[e.ColumnIndex].Name == "Reservar" && e.RowIndex >= 0)
                {
                    var cell = dgvCanchas.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewButtonCell;
                    if (cell != null)
                    {
                        cell.Style.BackColor = Color.LightGreen;
                        cell.Style.ForeColor = Color.DarkGreen;
                        cell.Style.Font = new Font(dgvCanchas.Font, FontStyle.Bold);
                    }
                }
            };
        }

        private async Task CargarCanchasAsync()
        {
            var canchas = _service.Listar()
                                  .OrderBy(c => c.NroCancha)
                                  .ToList();
            dgvCanchas.DataSource = canchas;
        }

        private void dgvCanchas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCanchas.Columns[e.ColumnIndex].Name == "Reservar")
            {
                var canchaSeleccionada = (Cancha)dgvCanchas.Rows[e.RowIndex].DataBoundItem;

                var reservaForm = new ReservaForm(canchaSeleccionada, _mailUsuario);
                reservaForm.ShowDialog();
            }
        }
    }
}
