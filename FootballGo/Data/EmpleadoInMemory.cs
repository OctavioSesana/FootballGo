using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGo.Data
{
    internal class EmpleadoInMemory
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
