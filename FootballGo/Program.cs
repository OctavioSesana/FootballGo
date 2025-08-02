using System;
using Domain.Services;
using Domain.Model;

class Program
{
    static void Main(string[] args)
    {
        var clienteService = new ClienteService();
        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ DE GESTIÓN DE CLIENTES ===");
            Console.WriteLine("1. Agregar cliente");
            Console.WriteLine("2. Mostrar todos los clientes");
            Console.WriteLine("3. Modificar cliente");
            Console.WriteLine("4. Eliminar cliente");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarCliente(clienteService);
                    break;
                case "2":
                    MostrarClientes(clienteService);
                    break;
                case "3":
                    ModificarCliente(clienteService);
                    break;
                case "4":
                    EliminarCliente(clienteService);
                    break;
                case "5":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción inválida. Presione una tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }
    }

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
            var dniInput = Console.ReadLine();
            if (!int.TryParse(dniInput, out int dni))
            {
                Console.WriteLine("DNI inválido. Presione una tecla para continuar...");
                Console.ReadKey();
                return;
            }


            Console.Write("Telefono: ");
            var telefonoInput = Console.ReadLine();
            if (!int.TryParse(telefonoInput, out int telefono))
            {
                Console.WriteLine("Teléfono inválido. Presione una tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.Write("Fecha de alta (yyyy-MM-dd) [Enter para usar la fecha actual]: ");
            string fechaInput = Console.ReadLine();
            DateTime fechaAlta;
            if (string.IsNullOrWhiteSpace(fechaInput))
            {
                fechaAlta = DateTime.Today;
            }
            else
            {
                while (!DateTime.TryParse(fechaInput, out fechaAlta))
                {
                    Console.Write("Fecha inválida. Intente nuevamente (Enter para usar la fecha actual): ");
                    fechaInput = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(fechaInput))
                    {
                        fechaAlta = DateTime.Today;
                        break;
                    }
                }
            }

            var cliente = new Cliente(0, nombre, apellido, email, dni, telefono, fechaAlta);
            service.Add(cliente);

            Console.WriteLine("✅ Cliente agregado exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }

        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
    }

    static void MostrarClientes(ClienteService service)
    {
        Console.Clear();
        Console.WriteLine("=== LISTADO DE CLIENTES ===");

        var clientes = service.GetAll();
        foreach (var c in clientes)
        {
            // Usar ToString() para evitar problemas si hay varias definiciones de Cliente
            Console.WriteLine(
                $"ID: {c.Id} | Nombre: {c.Nombre} {c.Apellido} | Email: {c.Email} | DNI: {c.dni} | Telefono: {c.telefono} | Alta: {c.FechaAlta:yyyy-MM-dd}"
            );
        }

        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey();
    }

    static void ModificarCliente(ClienteService service)
    {
        Console.Clear();
        Console.WriteLine("=== MODIFICAR CLIENTE ===");
        Console.Write("Ingrese el ID del cliente a modificar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido. Presione una tecla para continuar...");
            Console.ReadKey();
            return;
        }

        var clienteExistente = service.Get(id);
        if (clienteExistente == null)
        {
            Console.WriteLine("Cliente no encontrado.");
            Console.ReadKey();
            return;
        }

        try
        {
            Console.Write($"Nuevo nombre ({clienteExistente.Nombre}): ");
            var nombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nombre)) clienteExistente.SetNombre(nombre);

            Console.Write($"Nuevo apellido ({clienteExistente.Apellido}): ");
            var apellido = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(apellido)) clienteExistente.SetApellido(apellido);

            Console.Write($"Nuevo email ({clienteExistente.Email}): ");
            var email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email)) clienteExistente.SetEmail(email);

            Console.Write($"Nueva fecha de alta ({clienteExistente.FechaAlta:yyyy-MM-dd}): ");
            var fechaStr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(fechaStr) && DateTime.TryParse(fechaStr, out var fecha))
                clienteExistente.SetFechaAlta(fecha);

            if (service.Update(clienteExistente))
                Console.WriteLine("✅ Cliente modificado correctamente.");
            else
                Console.WriteLine("❌ No se pudo modificar el cliente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }

        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
    }

    static void EliminarCliente(ClienteService service)
    {
        Console.Clear();
        Console.WriteLine("=== ELIMINAR CLIENTE ===");
        Console.Write("Ingrese el ID del cliente a eliminar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido.");
        }
        else
        {
            bool eliminado = service.Delete(id);
            if (eliminado)
                Console.WriteLine("✅ Cliente eliminado correctamente.");
            else
                Console.WriteLine("❌ No se encontró un cliente con ese ID.");
        }

        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
    }
}
