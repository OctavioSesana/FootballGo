using Domain.Model;
using FootballGo.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace Data
{
    public class ClienteRepository
    {
        private FootballGoDbContext CreateContext()
        {
            // Acá usás tu propio DbContext en lugar de TPIContext
            return new FootballGoDbContext();
        }

        public void Add(Cliente cliente)
        {
            using var context = CreateContext();
            context.Clientes.Add(cliente);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var cliente = context.Clientes.Find(id);
            if (cliente != null)
            {
                context.Clientes.Remove(cliente);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Cliente? Get(int id)
        {
            using var context = CreateContext();
            return context.Clientes.Find(id);
        }

        public IEnumerable<Cliente> GetAll()
        {
            using var context = CreateContext();
            return context.Clientes.AsNoTracking().ToList();
        }

        public bool Update(Cliente cliente)
        {
            using var context = CreateContext();
            var existingCliente = context.Clientes.Find(cliente.Id);
            if (existingCliente != null)
            {
                existingCliente.SetNombre(cliente.Nombre);
                existingCliente.SetApellido(cliente.Apellido);
                existingCliente.SetEmail(cliente.Email);
                existingCliente.SetDNI(cliente.dni);
                existingCliente.SetTelefono(cliente.telefono);
                existingCliente.SetFechaAlta(cliente.FechaAlta);
                existingCliente.SetContrasenia(cliente.Contrasenia);

                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool EmailExists(string email, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Clientes.Where(c => c.Email.ToLower() == email.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(c => c.Id != excludeId.Value);
            }
            return query.Any();
        }

        public Cliente? GetByEmail(string email)
        {
            using var context = CreateContext();
            return context.Clientes.FirstOrDefault(c => c.Email.ToLower() == email.ToLower());
        }


        public IEnumerable<Cliente> GetByCriteria(FootballGo.DTOs.ClienteCriteria criteria) // Fully qualify the type to resolve ambiguity
        {
            const string sql = @"
                    SELECT Id, Nombre, Apellido, Email, dni, telefono, FechaAlta, Contrasenia
                    FROM Clientes 
                    WHERE Nombre LIKE @SearchTerm 
                       OR Apellido LIKE @SearchTerm 
                       OR Email LIKE @SearchTerm
                    ORDER BY Nombre, Apellido";

            var clientes = new List<Cliente>();
            string connectionString = new FootballGoDbContext().Database.GetConnectionString();
            string searchPattern = $"%{criteria.Texto}%";

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SearchTerm", searchPattern);

            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var cliente = new Cliente(
                    reader.GetInt32(0),    // Id
                    reader.GetString(1),   // Nombre
                    reader.GetString(2),   // Apellido
                    reader.GetString(3),   // Email
                    reader.GetInt32(4),    // dni
                    reader.GetInt32(5),    // telefono
                    reader.GetDateTime(6),  // FechaAlta
                    reader.GetString(10)   // Contrasenia
                );

                clientes.Add(cliente);
            }

            return clientes;
        }
    }
}
