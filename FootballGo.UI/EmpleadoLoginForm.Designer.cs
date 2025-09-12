namespace FootballGo.UI
{
    partial class EmpleadoLoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblDni;
        private Label lblContrasenia;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtDni;
        private TextBox txtContrasenia;
        private Button btnIngresar;
        private Button btnRegistro;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblNombre = new Label();
            lblApellido = new Label();
            lblDni = new Label();
            lblContrasenia = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtDni = new TextBox();
            txtContrasenia = new TextBox();
            btnIngresar = new Button();
            btnRegistro = new Button();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(30, 25);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(67, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(30, 65);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(69, 20);
            lblApellido.TabIndex = 1;
            lblApellido.Text = "Apellido:";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(30, 105);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(38, 20);
            lblDni.TabIndex = 2;
            lblDni.Text = "DNI:";
            // 
            // lblContrasenia
            // 
            lblContrasenia.AutoSize = true;
            lblContrasenia.Location = new Point(30, 145);
            lblContrasenia.Name = "lblContrasenia";
            lblContrasenia.Size = new Size(86, 20);
            lblContrasenia.TabIndex = 3;
            lblContrasenia.Text = "Contraseña:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(130, 22);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 27);
            txtNombre.TabIndex = 4;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(130, 62);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(200, 27);
            txtApellido.TabIndex = 5;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(130, 102);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(200, 27);
            txtDni.TabIndex = 6;
            // 
            // txtContrasenia
            // 
            txtContrasenia.Location = new Point(130, 142);
            txtContrasenia.Name = "txtContrasenia";
            txtContrasenia.PasswordChar = '*';
            txtContrasenia.Size = new Size(200, 27);
            txtContrasenia.TabIndex = 7;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(130, 190);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(90, 30);
            btnIngresar.TabIndex = 8;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnRegistro
            // 
            btnRegistro.Location = new Point(240, 190);
            btnRegistro.Name = "btnRegistro";
            btnRegistro.Size = new Size(90, 30);
            btnRegistro.TabIndex = 9;
            btnRegistro.Text = "Registrarse";
            btnRegistro.UseVisualStyleBackColor = true;
            btnRegistro.Click += btnRegistro_Click;
            // 
            // EmpleadoLoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 250);
            Controls.Add(btnRegistro);
            Controls.Add(btnIngresar);
            Controls.Add(txtContrasenia);
            Controls.Add(txtDni);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblContrasenia);
            Controls.Add(lblDni);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Name = "EmpleadoLoginForm";
            Text = "Inicio de sesión - Empleado";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
