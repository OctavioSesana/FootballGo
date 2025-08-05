using Domain.Model;

namespace Data
{
    public class EmpleadoInMemory
    {
        //No es ThreadSafe pero sirve para el proposito del ejemplo        
        public static List<Empleado> Empleados;

        static EmpleadoInMemory()
        {
            Empleados = new List<Empleado>
            {
                new Empleado(1, "Octavio", "Sesana", "43644808", 120000, true, DateTime.Now.AddMonths(-5)),
            };
        }
    }
}
