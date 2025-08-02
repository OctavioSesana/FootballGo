using System;
using Domain.Services;
using Domain.Model;

class Program
{
    static void Main(string[] args)
    {
        var clienteService = new ClienteService();
        var clientes = clienteService.GetAll().ToList(); // Convertimos a List para evitar CS0021

        foreach (var cliente in clientes)
        {
            Console.WriteLine($"ID: {cliente.Id}, Nombre: {cliente.Nombre}, Apellido: {cliente.Apellido}, Email: {cliente.Email}, FechaAlta: {cliente.FechaAlta:yyyy-MM-dd}");
        }

        // Ejemplo de agregar un nuevo cliente
        while (true)
        {
            Console.WriteLine("Ingrese los datos del cliente (o escriba 'salir' en Nombre para terminar):");

            Console.Write("Nombre: ");
            var nombre = Console.ReadLine();
            if (nombre?.Trim().ToLower() == "salir") break;

            Console.Write("Apellido: ");
            var apellido = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine();

            Console.Write("Fecha de alta (yyyy-MM-dd): ");
            DateTime fechaAlta;
            while (!DateTime.TryParse(Console.ReadLine(), out fechaAlta))
            {
                Console.Write("Fecha inválida. Intente nuevamente (yyyy-MM-dd): ");
            }

            // Se genera un nuevo ID para el cliente
            var nuevoId = clientes.Any() ? clientes.Last().Id + 1 : 1; // Usamos .Last() en lugar de índices para evitar CS0021

            // Se utiliza el constructor que requiere todos los parámetros
            var cliente = new Cliente(nuevoId, nombre, apellido, email, fechaAlta);

            clienteService.Add(cliente);

            Console.WriteLine("Cliente agregado!\n");
        }

        Console.WriteLine("\nClientes cargados:");
        clientes = clienteService.GetAll().ToList(); // Convertimos a List nuevamente
        foreach (var cliente in clientes)
        {
            Console.WriteLine($"ID: {cliente.Id}, Nombre: {cliente.Nombre}, Apellido: {cliente.Apellido}, Email: {cliente.Email}, FechaAlta: {cliente.FechaAlta:yyyy-MM-dd}");
        }
    }
}