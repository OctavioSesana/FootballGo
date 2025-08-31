using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class FootballGoDbContext : DbContext
    {
        public FootballGoDbContext() { }

        public FootballGoDbContext(DbContextOptions<FootballGoDbContext> opt) : base(opt) { }

        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Empleado> Empleados => Set<Empleado>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // ⚠️ Cambiá según tu servidor
                optionsBuilder.UseSqlServer(@"Server=OCTAV10\SQLEXPRESS;Database=FootballGoDB;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var e = modelBuilder.Entity<Cliente>();
            e.ToTable("Clientes");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).ValueGeneratedOnAdd();
            e.Property(x => x.Nombre).HasMaxLength(80).IsRequired();
            e.Property(x => x.Apellido).HasMaxLength(80).IsRequired();
            e.Property(x => x.Email).HasMaxLength(200).IsRequired();
            e.Property(x => x.dni).IsRequired();
            e.Property(x => x.telefono).IsRequired();
            e.Property(x => x.FechaAlta).HasColumnType("datetime2");

            var e2 = modelBuilder.Entity<Empleado>();
            e2.ToTable("Empleados");
            e2.HasKey(x => x.IdEmpleado);
            e2.Property(x => x.IdEmpleado).ValueGeneratedOnAdd();
            e2.Property(x => x.Nombre).HasMaxLength(80).IsRequired();
            e2.Property(x => x.Apellido).HasMaxLength(80).IsRequired();
            e2.Property(x => x.SueldoSemanal).HasMaxLength(200).IsRequired();
            e2.Property(x => x.EstaActivo).HasMaxLength(100).IsRequired();
            e2.Property(x => x.FechaIngreso).HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");

        }
    }
}
