namespace FootballGo.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Crea y muestra una instancia del formulario para Empleado
            Form2 empleadoForm = new Form2();
            empleadoForm.Show();

            // Luego, crea y ejecuta el formulario para Cliente como el formulario principal
            Application.Run(new Form1());
        }
    }
}