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
        public string Contrasenia { get; set; } = string.Empty;

        private Cliente() { } // Para EF

        public Cliente(int id, string nombre, string apellido, string email, int dni, int telefono, DateTime fechaAlta, string contrasenia)
        {
            SetId(id);
            SetNombre(nombre);
            SetApellido(apellido);
            SetEmail(email);
            SetDNI(dni);
            SetTelefono(telefono);
            SetFechaAlta(fechaAlta);
            SetContrasenia(contrasenia);
        }

        public void SetId(int id) => Id = id;
        public void SetNombre(string nombre) => Nombre = nombre;
        public void SetApellido(string apellido) => Apellido = apellido;
        public void SetEmail(string email) => Email = email;
        public void SetDNI(int dni) => this.dni = dni;
        public void SetTelefono(int telefono) => this.telefono = telefono;
        public void SetFechaAlta(DateTime fechaAlta) => FechaAlta = fechaAlta;
        //public void SetContrasenia(string contrasenia) => Contrasenia = contrasenia;
        public void SetContrasenia(string contrasenia)
        {
            if (string.IsNullOrWhiteSpace(contrasenia))
                throw new ArgumentException("La contraseña no puede estar vacía.", nameof(contrasenia));

            if (contrasenia.Length < 6)
                throw new ArgumentException("La contraseña debe tener al menos 6 caracteres.", nameof(contrasenia));

            Contrasenia = contrasenia;
        }
    }

    public class ClienteCriteria
    {
        public string Texto { get; set; } = string.Empty;
    }
}
