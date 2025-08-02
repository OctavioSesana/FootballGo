using Domain.Model;

namespace Domain.Services;

public class EmpleadoService
{
    private readonly List<Empleado> _empleados = new();
    private int _nextId = 1;

    public Empleado Add(Empleado e)
    {
        e.SetIdEmpleado(_nextId++);
        _empleados.Add(e);
        return e;
    }

    public List<Empleado> GetAll() => _empleados;

    public Empleado? Get(int id) =>
        _empleados.FirstOrDefault(e => e.IdEmpleado == id);

    public bool Update(Empleado actualizado)
    {
        var existente = Get(actualizado.IdEmpleado);
        if (existente is null) return false;

        existente.SetNombre(actualizado.Nombre);
        existente.SetApellido(actualizado.Apellido);
        existente.SetDni(actualizado.Dni);
        existente.SetSueldoSemanal(actualizado.SueldoSemanal);
        existente.SetEstaActivo(actualizado.EstaActivo);
        existente.SetFechaIngreso(actualizado.FechaIngreso);

        return true;
    }

    public bool Delete(int id)
    {
        var empleado = Get(id);
        return empleado is not null && _empleados.Remove(empleado);
    }
}
