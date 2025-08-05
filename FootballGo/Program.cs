using Domain.Services;
using Domain.Model;
class Program
{
    static void Main(string[] args)
    {
        var clienteService = new ClienteService();
        var empleadoService = new EmpleadoService();
        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ DE GESTIÓN ===");
            Console.WriteLine("1. Agregar cliente");
            Console.WriteLine("2. Mostrar todos los clientes");
            Console.WriteLine("3. Modificar cliente");
            Console.WriteLine("4. Eliminar cliente");
            Console.WriteLine("5. Agregar empleado");
            Console.WriteLine("6. Mostrar empleados");
            Console.WriteLine("7. Modificar empleado");
            Console.WriteLine("8. Eliminar empleado");
            Console.WriteLine("9. Salir");
            Console.Write("Seleccione una opción: ");

            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1": AgregarCliente(clienteService); break;
                case "2": MostrarClientes(clienteService); break;
                case "3": ModificarCliente(clienteService); break;
                case "4": EliminarCliente(clienteService); break;
                case "5": AgregarEmpleado(empleadoService); break;
                case "6": MostrarEmpleados(empleadoService); break;
                case "7": ModificarEmpleado(empleadoService); break;
                case "8": EliminarEmpleado(empleadoService); break;
                case "9": salir = true; break;
                default:
                    Console.WriteLine("Opción inválida. Presione una tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    // -------------------------- CLIENTES --------------------------
    static void AgregarCliente(ClienteService service)
    {
        try
        {
            Console.Clear();
            Console.WriteLine("=== ALTA DE CLIENTE ===");
            Console.Write("Nombre: ");
            var nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            var apellido = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();

            Console.Write("DNI: ");
            if (!int.TryParse(Console.ReadLine(), out int dni)) throw new ArgumentException("DNI inválido.");

            Console.Write("Teléfono: ");
            if (!int.TryParse(Console.ReadLine(), out int telefono)) throw new ArgumentException("Teléfono inválido.");

            Console.Write("Fecha de alta (yyyy-MM-dd) [Enter = hoy]: ");
            var input = Console.ReadLine();
            var fechaAlta = string.IsNullOrWhiteSpace(input) ? DateTime.Today : DateTime.Parse(input);

            var cliente = new Cliente(0, nombre, apellido, email, dni, telefono, fechaAlta);
            service.Add(cliente);
            Console.WriteLine("✅ Cliente agregado.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }
        Console.ReadKey();
    }

    static void MostrarClientes(ClienteService service)
    {
        Console.Clear();
        Console.WriteLine("=== LISTADO DE CLIENTES ===");
        foreach (var c in service.GetAll())
        {
            Console.WriteLine($"ID: {c.Id} | {c.Nombre} {c.Apellido} | DNI: {c.dni} | Email: {c.Email} | Tel: {c.telefono} | Alta: {c.FechaAlta:yyyy-MM-dd}");
        }
        Console.ReadKey();
    }

    static void ModificarCliente(ClienteService service)
    {
        Console.Clear();
        Console.WriteLine("=== MODIFICAR CLIENTE ===");
        Console.Write("ID del cliente: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) return;

        var cliente = service.Get(id);
        if (cliente == null)
        {
            Console.WriteLine("❌ Cliente no encontrado.");
            Console.ReadKey();
            return;
        }

        try
        {
            Console.Write($"Nuevo nombre ({cliente.Nombre}): ");
            var nombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nombre)) cliente.SetNombre(nombre);

            Console.Write($"Nuevo apellido ({cliente.Apellido}): ");
            var apellido = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(apellido)) cliente.SetApellido(apellido);

            Console.Write($"Nuevo email ({cliente.Email}): ");
            var email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email)) cliente.SetEmail(email);

            Console.Write($"Nueva fecha alta ({cliente.FechaAlta:yyyy-MM-dd}): ");
            var fechaStr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(fechaStr) && DateTime.TryParse(fechaStr, out var fecha))
                cliente.SetFechaAlta(fecha);

            if (service.Update(cliente))
                Console.WriteLine("✅ Cliente modificado.");
            else
                Console.WriteLine("❌ No se pudo modificar.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }

        Console.ReadKey();
    }

    static void EliminarCliente(ClienteService service)
    {
        Console.Clear();
        Console.WriteLine("=== ELIMINAR CLIENTE ===");
        Console.Write("ID del cliente: ");
        if (int.TryParse(Console.ReadLine(), out int id) && service.Delete(id))
            Console.WriteLine("✅ Cliente eliminado.");
        else
            Console.WriteLine("❌ Cliente no encontrado.");
        Console.ReadKey();
    }

    // -------------------------- EMPLEADOS --------------------------
     static void AgregarEmpleado(EmpleadoService service)
     {
         try
         {
             Console.Clear();
             Console.WriteLine("=== ALTA DE EMPLEADO ===");
             Console.Write("Nombre: ");
             var nombre = Console.ReadLine();

             Console.Write("Apellido: ");
             var apellido = Console.ReadLine();

             Console.Write("DNI: ");
             var dni = Console.ReadLine();

             Console.Write("Sueldo semanal: ");
             if (!decimal.TryParse(Console.ReadLine(), out decimal sueldo)) throw new ArgumentException("Sueldo inválido.");

             Console.Write("¿Está activo? (s/n): ");
             bool activo = Console.ReadLine()?.ToLower() == "s";

             Console.Write("Fecha de ingreso (yyyy-MM-dd) [Enter = hoy]: ");
             var fechaStr = Console.ReadLine();
             var fechaIngreso = string.IsNullOrWhiteSpace(fechaStr) ? DateTime.Today : DateTime.Parse(fechaStr);

             var empleado = new Empleado(0, nombre, apellido, dni, sueldo, activo, fechaIngreso);
             service.Add(empleado);

             Console.WriteLine("✅ Empleado agregado.");
         }
         catch (Exception ex)
         {
             Console.WriteLine($"❌ Error: {ex.Message}");
         }

         Console.ReadKey();
     }

     static void MostrarEmpleados(EmpleadoService service)
     {
         Console.Clear();
         Console.WriteLine("=== LISTADO DE EMPLEADOS ===");
         foreach (var e in service.GetAll())
         {
             Console.WriteLine($"ID: {e.IdEmpleado} | {e.Nombre} {e.Apellido} | DNI: {e.Dni} | Sueldo: ${e.SueldoSemanal} | Estado: {(e.EstaActivo ? "Activo" : "Inactivo")} | Ingreso: {e.FechaIngreso:yyyy-MM-dd}");
         }
         Console.ReadKey();
     }

     static void ModificarEmpleado(EmpleadoService service)
     {
         Console.Clear();
         Console.WriteLine("=== MODIFICAR EMPLEADO ===");
         Console.Write("ID del empleado: ");
         if (!int.TryParse(Console.ReadLine(), out int id)) return;

         var empleado = service.Get(id);
         if (empleado == null)
         {
             Console.WriteLine("❌ Empleado no encontrado.");
             Console.ReadKey();
             return;
         }

         try
         {
             Console.Write($"Nuevo nombre ({empleado.Nombre}): ");
             var nombre = Console.ReadLine();
             if (!string.IsNullOrWhiteSpace(nombre)) empleado.SetNombre(nombre);

             Console.Write($"Nuevo apellido ({empleado.Apellido}): ");
             var apellido = Console.ReadLine();
             if (!string.IsNullOrWhiteSpace(apellido)) empleado.SetApellido(apellido);

             Console.Write($"Nuevo DNI ({empleado.Dni}): ");
             var dni = Console.ReadLine();
             if (!string.IsNullOrWhiteSpace(dni)) empleado.SetDni(dni);

             Console.Write($"Nuevo sueldo semanal ({empleado.SueldoSemanal}): ");
             if (decimal.TryParse(Console.ReadLine(), out decimal sueldo)) empleado.SetSueldoSemanal(sueldo);

             Console.Write("¿Está activo? (s/n): ");
             var estado = Console.ReadLine();
             empleado.SetEstaActivo(estado?.ToLower() == "s");

             Console.Write($"Nueva fecha de ingreso ({empleado.FechaIngreso:yyyy-MM-dd}): ");
             var fechaStr = Console.ReadLine();
             if (!string.IsNullOrWhiteSpace(fechaStr) && DateTime.TryParse(fechaStr, out var fecha))
                 empleado.SetFechaIngreso(fecha);

             if (service.Update(empleado))
                 Console.WriteLine("✅ Empleado modificado.");
             else
                 Console.WriteLine("❌ No se pudo modificar.");
         }
         catch (Exception ex)
         {
             Console.WriteLine($"❌ Error: {ex.Message}");
         }

         Console.ReadKey();
     }

     static void EliminarEmpleado(EmpleadoService service)
     {
         Console.Clear();
         Console.WriteLine("=== ELIMINAR EMPLEADO ===");
         Console.Write("ID del empleado: ");
         if (int.TryParse(Console.ReadLine(), out int id) && service.Delete(id))
             Console.WriteLine("✅ Empleado eliminado.");
         else
             Console.WriteLine("❌ Empleado no encontrado.");
         Console.ReadKey();
     } 
     
}
