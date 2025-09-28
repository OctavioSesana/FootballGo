
using Data;                 
using Domain.Model;         
using DTOs;                 
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FootballGoDbContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var clientes = app.MapGroup("/clientes");

// GET /clientes  -> lista
clientes.MapGet("/", async (FootballGoDbContext db) =>
{
    var list = await db.Clientes.AsNoTracking().ToListAsync();
    return Results.Ok(list.Select(ToDto));
});

// GET /clientes/{id}
clientes.MapGet("/{id:int}", async (int id, FootballGoDbContext db) =>
{
    var e = await db.Clientes.FindAsync(id);
    return e is null ? Results.NotFound() : Results.Ok(ToDto(e));
});

// GET /clientes/criteria?texto=...
clientes.MapGet("/criteria", async (string texto, FootballGoDbContext db) =>
{
    texto = (texto ?? string.Empty).ToLower();
    var list = await db.Clientes
        .Where(c =>
            c.Nombre.ToLower().Contains(texto) ||
            c.Apellido.ToLower().Contains(texto) ||
            c.Email.ToLower().Contains(texto))
        .AsNoTracking()
        .ToListAsync();

    return Results.Ok(list.Select(ToDto));
});

// POST /clientes
clientes.MapPost("/", async (DTOs.Cliente dto, FootballGoDbContext db) =>
{

    var e = new Domain.Model.Cliente(
        0,
        dto.Nombre,
        dto.Apellido,
        dto.Email,
        dto.dni,
        dto.telefono,
        dto.FechaAlta,
        dto.Contrasenia
    );

    db.Clientes.Add(e);
    await db.SaveChangesAsync();

    return Results.Created($"/clientes/{e.Id}", ToDto(e));
});

// PUT /clientes
clientes.MapPut("/", async (DTOs.Cliente dto, FootballGoDbContext db) =>
{
    if (dto.Id <= 0) return Results.BadRequest("Id inválido.");

    var e = await db.Clientes.FindAsync(dto.Id);
    if (e is null) return Results.NotFound($"No existe cliente Id {dto.Id}");

    Apply(e, dto);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

// DELETE /clientes/{id}
clientes.MapDelete("/{id:int}", async (int id, FootballGoDbContext db) =>
{
    var e = await db.Clientes.FindAsync(id);
    if (e is null) return Results.NotFound();
    db.Clientes.Remove(e);
    await db.SaveChangesAsync();
    return Results.NoContent();
});


static DTOs.Cliente ToDto(Domain.Model.Cliente c) => new()
{
    Id = c.Id,
    Nombre = c.Nombre,
    Apellido = c.Apellido,
    Email = c.Email,
    dni = c.dni,
    telefono = c.telefono,
    FechaAlta = c.FechaAlta,
    Contrasenia = c.Contrasenia
};

static void Apply(Domain.Model.Cliente e, DTOs.Cliente d)
{
    e.SetNombre(d.Nombre);
    e.SetApellido(d.Apellido);
    e.SetEmail(d.Email);
    e.SetDNI(d.dni);
    e.SetTelefono(d.telefono);
    e.SetFechaAlta(d.FechaAlta);
    e.SetContrasenia(d.Contrasenia);
}

var empleados = app.MapGroup("/empleados");

// GET /empleados -> lista
empleados.MapGet("/", async (FootballGoDbContext db) =>
{
    var list = await db.Empleados.AsNoTracking().ToListAsync();
    return Results.Ok(list.Select(ToDtoEmpleado));
});

// GET /empleados/{id}
empleados.MapGet("/{id:int}", async (int id, FootballGoDbContext db) =>
{
    var e = await db.Empleados.FindAsync(id);
    return e is null ? Results.NotFound() : Results.Ok(ToDtoEmpleado(e));
});

// GET /empleados/criteria?texto=...
empleados.MapGet("/criteria", async (string texto, FootballGoDbContext db) =>
{
    texto = (texto ?? string.Empty).ToLower();
    var list = await db.Empleados
        .Where(e =>
            e.Nombre.ToLower().Contains(texto) ||
            e.Apellido.ToLower().Contains(texto) ||
            e.Dni.ToString().Contains(texto))
        .AsNoTracking()
        .ToListAsync();

    return Results.Ok(list.Select(ToDtoEmpleado));
});

// POST /empleados
empleados.MapPost("/", async (DTOs.Empleado dto, FootballGoDbContext db) =>
{
    var e = new Domain.Model.Empleado(
        0,
        dto.Nombre,
        dto.Apellido,
        dto.Dni,
        dto.SueldoSemanal,
        dto.EstaActivo,
        dto.FechaIngreso,
        dto.Contrasenia
    );

    db.Empleados.Add(e);
    await db.SaveChangesAsync();

    return Results.Created($"/empleados/{e.Id}", ToDtoEmpleado(e));
});

// PUT /empleados
empleados.MapPut("/", async (DTOs.Empleado dto, FootballGoDbContext db) =>
{
    if (dto.IdEmpleado <= 0) return Results.BadRequest("Id inválido.");

    var e = await db.Empleados.FindAsync(dto.IdEmpleado);
    if (e is null) return Results.NotFound($"No existe empleado Id {dto.IdEmpleado}");

    ApplyEmpleado(e, dto);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

// DELETE /empleados/{id}
empleados.MapDelete("/{id:int}", async (int id, FootballGoDbContext db) =>
{
    var e = await db.Empleados.FindAsync(id);
    if (e is null) return Results.NotFound();
    db.Empleados.Remove(e);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

static DTOs.Empleado ToDtoEmpleado(Domain.Model.Empleado e) => new()
{
    IdEmpleado = e.Id,
    Nombre = e.Nombre,
    Apellido = e.Apellido,
    Dni = e.Dni,
    SueldoSemanal = e.SueldoSemanal,
    EstaActivo = e.EstaActivo,
    FechaIngreso = e.FechaIngreso,
    Contrasenia = e.contrasenia,
};

static void ApplyEmpleado(Domain.Model.Empleado e, DTOs.Empleado d)
{
    e.SetNombre(d.Nombre);
    e.SetApellido(d.Apellido);
    e.SetDni(d.Dni);
    e.SetSueldoSemanal(d.SueldoSemanal);
    e.SetEstaActivo(d.EstaActivo);
    e.SetFechaIngreso(d.FechaIngreso);
    e.SetContrasenia(d.Contrasenia);


}


app.Run();
