namespace FootballGo.UI
{
    public partial class EmpleadoDetailsForm:Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblNombre = new Label();
            this.lblApellido = new Label();
            this.lblDNI = new Label();
            this.lblSueldo = new Label();
            this.lblEstado = new Label();
            this.lblFecha = new Label();

            this.txtNombre = new TextBox();
            this.txtApellido = new TextBox();
            this.txtDNI = new TextBox();
            this.txtSueldo = new TextBox();
            this.txtEstado = new TextBox();           // si luego querés CheckBox, lo cambiamos

            this.dtpFechaIngreso = new DateTimePicker();

            this.btnSave = new Button();
            this.btnCancel = new Button();

            this.SuspendLayout();

            // lblNombre
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new Point(12, 20);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new Size(60, 15);
            this.lblNombre.Text = "Nombre:";

            // txtNombre
            this.txtNombre.Location = new Point(120, 17);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new Size(200, 23);

            // lblApellido
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new Point(12, 55);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new Size(54, 15);
            this.lblApellido.Text = "Apellido:";

            // txtApellido
            this.txtApellido.Location = new Point(120, 52);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new Size(200, 23);

            // lblDNI
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new Point(12, 90);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new Size(30, 15);
            this.lblDNI.Text = "DNI:";

            // txtDNI
            this.txtDNI.Location = new Point(120, 87);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new Size(200, 23);

            // lblSueldo
            this.lblSueldo.AutoSize = true;
            this.lblSueldo.Location = new Point(12, 125);
            this.lblSueldo.Name = "lblSueldo";
            this.lblSueldo.Size = new Size(92, 15);
            this.lblSueldo.Text = "Sueldo semanal:";

            // txtSueldo
            this.txtSueldo.Location = new Point(120, 122);
            this.txtSueldo.Name = "txtSueldo";
            this.txtSueldo.Size = new Size(200, 23);

            // lblEstado
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new Point(12, 160);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new Size(45, 15);
            this.lblEstado.Text = "Estado:";

            // txtEstado  (true/false por ahora)
            this.txtEstado.Location = new Point(120, 157);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new Size(200, 23);

            // lblFecha
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new Point(12, 195);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new Size(41, 15);
            this.lblFecha.Text = "Fecha:";

            // dtpFechaIngreso
            this.dtpFechaIngreso.Location = new Point(120, 192);
            this.dtpFechaIngreso.Name = "dtpFechaIngreso";
            this.dtpFechaIngreso.Size = new Size(200, 23);

            // btnSave
            this.btnSave.Location = new Point(120, 230);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(90, 30);
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnGuardar_Click);

            // btnCancel
            this.btnCancel.Location = new Point(230, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(90, 30);
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancelar_Click);

            // EmpleadoDetailsForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(350, 280);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpFechaIngreso);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.txtSueldo);
            this.Controls.Add(this.lblSueldo);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.lblDNI);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Name = "EmpleadoDetailsForm";
            this.Text = "Nuevo empleado";
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private Label lblNombre, lblApellido, lblDNI, lblSueldo, lblEstado, lblFecha;
        private TextBox txtNombre, txtApellido, txtDNI, txtSueldo, txtEstado;
        private DateTimePicker dtpFechaIngreso;
        private Button btnSave, btnCancel;
    }
}
