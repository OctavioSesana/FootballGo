namespace FootballGo.UI
{
    partial class EmpleadoDashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblSesion;
        private Button btnCerrarSesion;
        private Button btnGestionarPerfil;
        private Button btnBajaCuenta;
        private Button btnAlta;
        private Button btnGestion;
        private Button btnArticulosAlta;

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
            btnBajaCuenta = new Button();
            btnAlta = new Button();
            btnGestion = new Button();
            btnArticulosAlta = new Button();
            btnListadoCanchas = new Button();
            SuspendLayout();
            // 
            // lblSesion
            // 
            lblSesion.AutoSize = true;
            lblSesion.Location = new Point(30, 20);
            lblSesion.Name = "lblSesion";
            lblSesion.Size = new Size(235, 20);
            lblSesion.TabIndex = 0;
            lblSesion.Text = "Sesión iniciada como: (empleado)";
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(30, 60);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(150, 30);
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
            // btnBajaCuenta
            // 
            btnBajaCuenta.Location = new Point(30, 160);
            btnBajaCuenta.Name = "btnBajaCuenta";
            btnBajaCuenta.Size = new Size(150, 30);
            btnBajaCuenta.TabIndex = 3;
            btnBajaCuenta.Text = "Baja de cuenta";
            btnBajaCuenta.UseVisualStyleBackColor = true;
            btnBajaCuenta.Click += btnBajaCuenta_Click;
            // 
            // btnAlta
            // 
            btnAlta.Location = new Point(30, 210);
            btnAlta.Name = "btnAlta";
            btnAlta.Size = new Size(150, 30);
            btnAlta.TabIndex = 4;
            btnAlta.Text = "Alta de cancha";
            btnAlta.UseVisualStyleBackColor = true;
            btnAlta.Click += btnAlta_Click_1;
            // 
            // btnGestion
            // 
            btnGestion.Location = new Point(30, 260);
            btnGestion.Name = "btnGestion";
            btnGestion.Size = new Size(150, 30);
            btnGestion.TabIndex = 5;
            btnGestion.Text = "Gestionar reservas";
            btnGestion.UseVisualStyleBackColor = true;
            btnGestion.Click += btnGestion_Click;
            // 
            // btnArticulosAlta
            // 
            btnArticulosAlta.Location = new Point(30, 310);
            btnArticulosAlta.Name = "btnArticulosAlta";
            btnArticulosAlta.Size = new Size(150, 30);
            btnArticulosAlta.TabIndex = 6;
            btnArticulosAlta.Text = "Alta artículos";
            btnArticulosAlta.UseVisualStyleBackColor = true;
            btnArticulosAlta.Click += btnArticulosAlta_Click_1;
            // 
            // btnListadoCanchas
            // 
            btnListadoCanchas.Location = new Point(30, 365);
            btnListadoCanchas.Name = "btnListadoCanchas";
            btnListadoCanchas.Size = new Size(150, 29);
            btnListadoCanchas.TabIndex = 7;
            btnListadoCanchas.Text = "Listado Canchas";
            btnListadoCanchas.UseVisualStyleBackColor = true;
            btnListadoCanchas.Click += btnListadoCanchas_Click;
            // 
            // EmpleadoDashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 423);
            Controls.Add(btnListadoCanchas);
            Controls.Add(btnArticulosAlta);
            Controls.Add(btnGestion);
            Controls.Add(btnAlta);
            Controls.Add(btnBajaCuenta);
            Controls.Add(btnGestionarPerfil);
            Controls.Add(btnCerrarSesion);
            Controls.Add(lblSesion);
            Name = "EmpleadoDashboardForm";
            Text = "Panel de Empleado";
            Load += EmpleadoDashboardForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        private Button btnListadoCanchas;
    }
}
