using System.Drawing;
using System.Windows.Forms;

namespace FootballGo.UI
{
    partial class EmpleadoDashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblSesion;
        private MenuStrip menuStrip;
        private Panel contentPanel;   // 👈 campo requerido

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblSesion = new Label();
            menuStrip = new MenuStrip();
            contentPanel = new Panel();

            // lblSesion
            lblSesion.Dock = DockStyle.Top;
            lblSesion.Height = 44;
            lblSesion.Text = "Sesión iniciada como: (empleado)";
            lblSesion.TextAlign = ContentAlignment.MiddleCenter;
            lblSesion.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSesion.BackColor = Color.Gainsboro;

            // menuStrip (vacío: lo llenamos en el .cs)
            menuStrip.Dock = DockStyle.Top;
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1000, 24);

            // contentPanel
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Name = "contentPanel";
            contentPanel.BackColor = Color.White;

            // Form
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 650);
            Controls.Add(contentPanel);
            Controls.Add(lblSesion);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "EmpleadoDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FootballGo - Unificado";
            Load += EmpleadoDashboardForm_Load;
        }
    }
}
