namespace Domain.Model;

public class Empleado
{
    public int IdEmpleado { get; private set; }
    public string Nombre { get; private set; }
    public string Apellido { get; private set; }
    public string Dni { get; private set; }
    public decimal SueldoSemanal { get; private set; }
    public bool EstaActivo { get; private set; }
    public DateTime FechaIngreso { get; private set; }

    public Empleado(int idEmpleado, string nombre, string apellido, string dni, decimal sueldoSemanal, bool estaActivo, DateTime fechaIngreso)
    {
        IdEmpleado = idEmpleado;
        Nombre = nombre;
        Apellido = apellido;
        Dni = dni;
        SueldoSemanal = sueldoSemanal;
        EstaActivo = estaActivo;
        FechaIngreso = fechaIngreso;
    }

    // Métodos para modificar propiedades (usados en Update)
    public void SetIdEmpleado(int id) => IdEmpleado = id;
    public void SetNombre(string nombre) => Nombre = nombre;
    public void SetApellido(string apellido) => Apellido = apellido;
    public void SetDni(string dni) => Dni = dni;
    public void SetSueldoSemanal(decimal sueldo) => SueldoSemanal = sueldo;
    public void SetEstaActivo(bool activo) => EstaActivo = activo;
    public void SetFechaIngreso(DateTime fecha) => FechaIngreso = fecha;
}
