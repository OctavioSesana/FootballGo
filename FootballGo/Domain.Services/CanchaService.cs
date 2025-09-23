using System;
using System.Collections.Generic;
using Data;
using Domain.Model;

namespace Domain.Services
{
    public class CanchaService
    {
        private readonly ICanchaRepository _repo;

        public CanchaService() : this(new CanchaRepository()) { }
        public CanchaService(ICanchaRepository repo) => _repo = repo;

        public int Crear(int nroCancha, EstadoCancha estado, int tipo, decimal precio)
        {
            if (nroCancha <= 0)
                throw new ArgumentException("El número de cancha debe ser > 0.");
            if (tipo != 5 && tipo != 7)
                throw new ArgumentException("El tipo de cancha debe ser 5 o 7.");
            if (precio <= 0)
                throw new ArgumentException("El precio por hora debe ser > 0.");

            if (_repo.GetByNro(nroCancha) != null)
                throw new InvalidOperationException("Ya existe una cancha con ese número.");

            var c = new Cancha
            {
                NroCancha = nroCancha,
                EstadoCancha = estado,
                TipoCancha = tipo,
                PrecioPorHora = precio
            };
            return _repo.Insert(c); // EF guardará todos los campos
        }

        // Si más adelante editás:
        public void Actualizar(int id, int nroCancha, EstadoCancha estado, int tipo, decimal precio)
        {
            if (nroCancha <= 0)
                throw new ArgumentException("El número de cancha debe ser > 0.");
            if (tipo != 5 && tipo != 7)
                throw new ArgumentException("El tipo de cancha debe ser 5 o 7.");
            if (precio <= 0)
                throw new ArgumentException("El precio por hora debe ser > 0.");

            var existente = _repo.GetById(id)
                ?? throw new InvalidOperationException("Cancha no encontrada.");

            var conMismoNro = _repo.GetByNro(nroCancha);
            if (conMismoNro != null && conMismoNro.IdCancha != id)
                throw new InvalidOperationException("Ya existe otra cancha con ese número.");

            existente.NroCancha = nroCancha;
            existente.EstadoCancha = estado;
            existente.TipoCancha = tipo;
            existente.PrecioPorHora = precio;

            _repo.Update(existente);
        }

        public List<Cancha> Listar() => _repo.GetAll();
        public Cancha? Obtener(int id) => _repo.GetById(id);
    }
}
