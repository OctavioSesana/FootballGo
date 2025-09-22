namespace FootballGo.UI
{
    partial class EmpleadoDashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // EmpleadoDashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1163, 445);
            Name = "EmpleadoDashboardForm";
            Text = "Panel de Empleado";
            Load += EmpleadoDashboardForm_Load;
            ResumeLayout(false);
        }
    }
}
