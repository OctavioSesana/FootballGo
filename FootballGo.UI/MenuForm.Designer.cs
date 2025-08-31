namespace FootballGo.UI
{
    partial class MenuForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnClientes;
        private Button btnEmpleados;

        private void InitializeComponent()
        {
            btnClientes = new Button();
            btnEmpleados = new Button();
            SuspendLayout();

            // 
            // btnClientes
            // 
            btnClientes.Location = new Point(50, 40);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(200, 50);
            btnClientes.Text = "Gestión de Clientes";
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;

            // 
            // btnEmpleados
            // 
            btnEmpleados.Location = new Point(50, 120);
            btnEmpleados.Name = "btnEmpleados";
            btnEmpleados.Size = new Size(200, 50);
            btnEmpleados.Text = "Gestión de Empleados";
            btnEmpleados.UseVisualStyleBackColor = true;
            btnEmpleados.Click += btnEmpleados_Click;

            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 220);
            Controls.Add(btnClientes);
            Controls.Add(btnEmpleados);
            Name = "MenuForm";
            Text = "Menú Principal";
            ResumeLayout(false);
        }
    }
}
