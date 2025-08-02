using System.Text.RegularExpressions;

namespace Domain.Model
{
    public class Cliente
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        

        public string Email { get; private set; }
        public int dni { get; private set; }
        public int telefono { get; private set; }

        public DateTime FechaAlta { get; private set; }

        public Cliente(int id, string nombre, string apellido, string email, int dni, int telefono, DateTime fechaAlta)
        {
            SetId(id);
            SetNombre(nombre);
            SetApellido(apellido);
            SetEmail(email);
            SetDNI(dni);
            SetTelefono(telefono);
            SetFechaAlta(fechaAlta);
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede ser nulo o vacío.", nameof(nombre));
            Nombre = nombre;
        }

        public void SetApellido(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido no puede ser nulo o vacío.", nameof(apellido));
            Apellido = apellido;
        }

        public void SetEmail(string email)
        {
            if (!EsEmailValido(email))
                throw new ArgumentException("El email no tiene un formato válido.", nameof(email));
            Email = email;
        }

        private static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public void SetDNI(int dni)
        {
            if (dni < 0)
                throw new ArgumentException("El DNI no puede ser negativo.", nameof(dni));
            if (dni % 1 != 0)
                throw new ArgumentException("El DNI debe ser un número entero.", nameof(dni));
            if (dni < 1000000 || dni > 99999999)
                throw new ArgumentException("El DNI debe tener entre 7 y 8 dígitos.", nameof(dni));
            this.dni = (int)dni;
        }

        public void SetTelefono(int telefono)
        {
            if (telefono < 0)
                throw new ArgumentException("El teléfono no puede ser negativo.", nameof(telefono));
            this.telefono = (int)telefono;
        }


        public void SetFechaAlta(DateTime fechaAlta)
        {
            if (fechaAlta == default)
                throw new ArgumentException("La fecha de alta no puede ser nula.", nameof(fechaAlta));
            FechaAlta = fechaAlta;
        }


    }
}