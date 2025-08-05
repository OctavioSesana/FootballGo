using Domain.Model;
using Data; // Asegurate de importar el namespace correcto

namespace Domain.Services;

public class EmpleadoService
{
    public Empleado Add(Empleado e)
    {
        e.SetIdEmpleado(GetNextId());
        EmpleadoInMemory.Empleados.Add(e);
        return e;
    }

    public List<Empleado> GetAll() => EmpleadoInMemory.Empleados.ToList();

    public Empleado? Get(int id) =>
        EmpleadoInMemory.Empleados.FirstOrDefault(e => e.IdEmpleado == id);

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
        return empleado is not null && EmpleadoInMemory.Empleados.Remove(empleado);
    }

    private int GetNextId()
    {
        return EmpleadoInMemory.Empleados.Count > 0
            ? EmpleadoInMemory.Empleados.Max(e => e.IdEmpleado) + 1
            : 1;
    }
}
