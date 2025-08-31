using Data;
using Domain.Model;
using FootballGo.DTOs;

namespace Domain.Services
{
    public class EmpleadoService
    {
        private readonly EmpleadoRepository _repo;

        public EmpleadoService()
        {
            _repo = new EmpleadoRepository();
        }

        public void Add(Empleado empleado) => _repo.Add(empleado);

        public IEnumerable<Empleado> GetAll() => _repo.GetAll();

        public Empleado? Get(int id) => _repo.Get(id);

        public bool Update(Empleado actualizado) => _repo.Update(actualizado);

        public bool Delete(int id) => _repo.Delete(id);
    }
}
