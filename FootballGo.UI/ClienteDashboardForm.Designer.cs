namespace FootballGo.UI
{
    partial class ClienteDashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblSesion;
        private Button btnCerrarSesion;
        private Button btnGestionarPerfil;
        private Button btnReservarCancha;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblSesion = new Label();
            btnCerrarSesion = new Button();
            btnGestionarPerfil = new Button();
            btnReservarCancha = new Button();
            SuspendLayout();
            // 
            // lblSesion
            // 
            lblSesion.AutoSize = true;
            lblSesion.Location = new Point(30, 20);
            lblSesion.Name = "lblSesion";
            lblSesion.Size = new Size(200, 20);
            lblSesion.TabIndex = 0;
            lblSesion.Text = "Sesión iniciada como: (user)";
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(30, 60);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(120, 30);
            btnCerrarSesion.TabIndex = 1;
            btnCerrarSesion.Text = "Cerrar sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // btnGestionarPerfil
            // 
            btnGestionarPerfil.Location = new Point(30, 110);
            btnGestionarPerfil.Name = "btnGestionarPerfil";
            btnGestionarPerfil.Size = new Size(150, 30);
            btnGestionarPerfil.TabIndex = 2;
            btnGestionarPerfil.Text = "Gestionar perfil";
            btnGestionarPerfil.UseVisualStyleBackColor = true;
            btnGestionarPerfil.Click += btnGestionarPerfil_Click;
            // 
            // btnReservarCancha
            // 
            btnReservarCancha.Location = new Point(30, 160);
            btnReservarCancha.Name = "btnReservarCancha";
            btnReservarCancha.Size = new Size(150, 30);
            btnReservarCancha.TabIndex = 3;
            btnReservarCancha.Text = "Reservar cancha";
            btnReservarCancha.UseVisualStyleBackColor = true;
            btnReservarCancha.Click += btnReservarCancha_Click;
            // 
            // ClienteDashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 220);
            Controls.Add(btnReservarCancha);
            Controls.Add(btnGestionarPerfil);
            Controls.Add(btnCerrarSesion);
            Controls.Add(lblSesion);
            Name = "ClienteDashboardForm";
            Text = "Panel de Usuario";
            Load += ClienteDashboardForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
