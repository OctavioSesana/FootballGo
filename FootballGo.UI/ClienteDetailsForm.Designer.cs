namespace FootballGo.UI
{
    partial class ClienteDetailsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblName = new Label();
            lblTel = new Label();
            lblMail = new Label();
            lblDNI = new Label();
            lblLastName = new Label();
            txtNombre = new TextBox();
            txtTel = new TextBox();
            txtEmail = new TextBox();
            txtDNI = new TextBox();
            txtApellido = new TextBox();
            lblFecha = new Label();
            dtpFechaAlta = new DateTimePicker();
            btnSave = new Button();
            btnCancel = new Button();
            txtContrasenia = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 26);
            lblName.Name = "lblName";
            lblName.Size = new Size(67, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Nombre:";
            // 
            // lblTel
            // 
            lblTel.AutoSize = true;
            lblTel.Location = new Point(12, 209);
            lblTel.Name = "lblTel";
            lblTel.Size = new Size(34, 20);
            lblTel.TabIndex = 1;
            lblTel.Text = "Tel.:";
            // 
            // lblMail
            // 
            lblMail.AutoSize = true;
            lblMail.Location = new Point(13, 141);
            lblMail.Name = "lblMail";
            lblMail.Size = new Size(49, 20);
            lblMail.TabIndex = 2;
            lblMail.Text = "Email:";
            // 
            // lblDNI
            // 
            lblDNI.AutoSize = true;
            lblDNI.Location = new Point(12, 102);
            lblDNI.Name = "lblDNI";
            lblDNI.Size = new Size(38, 20);
            lblDNI.TabIndex = 3;
            lblDNI.Text = "DNI:";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(12, 63);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(69, 20);
            lblLastName.TabIndex = 4;
            lblLastName.Text = "Apellido:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(85, 19);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(196, 27);
            txtNombre.TabIndex = 5;
            // 
            // txtTel
            // 
            txtTel.Location = new Point(85, 200);
            txtTel.Name = "txtTel";
            txtTel.Size = new Size(196, 27);
            txtTel.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(86, 134);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(196, 27);
            txtEmail.TabIndex = 7;
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(87, 95);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(196, 27);
            txtDNI.TabIndex = 8;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(87, 56);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(196, 27);
            txtApellido.TabIndex = 9;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(12, 243);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(50, 20);
            lblFecha.TabIndex = 10;
            lblFecha.Text = "Fecha:";
            // 
            // dtpFechaAlta
            // 
            dtpFechaAlta.Location = new Point(85, 236);
            dtpFechaAlta.Name = "dtpFechaAlta";
            dtpFechaAlta.Size = new Size(250, 27);
            dtpFechaAlta.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(85, 298);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 12;
            btnSave.Text = "Guardar";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnGuardar_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(189, 298);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancelar_Click;
            // 
            // txtContrasenia
            // 
            txtContrasenia.Location = new Point(110, 170);
            txtContrasenia.Name = "txtContrasenia";
            txtContrasenia.Size = new Size(174, 27);
            txtContrasenia.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 177);
            label1.Name = "label1";
            label1.Size = new Size(86, 20);
            label1.TabIndex = 15;
            label1.Text = "Contraseña:";
            label1.Click += label1_Click;
            // 
            // ClienteDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1188, 450);
            Controls.Add(label1);
            Controls.Add(txtContrasenia);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(dtpFechaAlta);
            Controls.Add(lblFecha);
            Controls.Add(txtApellido);
            Controls.Add(txtDNI);
            Controls.Add(txtEmail);
            Controls.Add(txtTel);
            Controls.Add(txtNombre);
            Controls.Add(lblLastName);
            Controls.Add(lblDNI);
            Controls.Add(lblMail);
            Controls.Add(lblTel);
            Controls.Add(lblName);
            Name = "ClienteDetailsForm";
            Text = "Form2";
            Load += ClienteDetailsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label lblTel;
        private Label lblMail;
        private Label lblDNI;
        private Label lblLastName;
        private TextBox txtNombre;
        private TextBox txtTel;
        private TextBox txtEmail;
        private TextBox txtDNI;
        private TextBox txtApellido;
        private Label lblFecha;
        private DateTimePicker dtpFechaAlta;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtContrasenia;
        private Label label1;
    }
}