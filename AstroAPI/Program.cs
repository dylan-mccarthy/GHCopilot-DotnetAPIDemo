using AstroAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AstroDb>(opt => opt.UseInMemoryDatabase("AstroDb"));
var app = builder.Build();

app.MapGet("/planets", async (AstroDb db) =>
{
    var planets = await db.Planets.ToListAsync();
    return Results.Ok(planets);
});

app.MapPost("/planets", async (AstroDb db, Planet planet) =>
{
    await db.Planets.AddAsync(planet);
    await db.SaveChangesAsync();
    return Results.Created($"/planets/{planet.Id}", planet);
}).Produces<Planet>(StatusCodes.Status201Created);

app.MapGet("/planets/{id}", async (AstroDb db, int id) =>
{
    var planet = await db.Planets.FindAsync(id);
    if (planet is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(planet);
});

app.MapPut("/planets/{id}", async (AstroDb db, int id, Planet planet) =>
{
    if (id != planet.Id)
    {
        return Results.BadRequest();
    }
    db.Planets.Update(planet);
    await db.SaveChangesAsync();
    return Results.Ok(planet);
});

app.MapDelete("/planets/{id}", async (AstroDb db, int id) =>
{
    var planet = await db.Planets.FindAsync(id);
    if (planet is null)
    {
        return Results.NotFound();
    }
    db.Planets.Remove(planet);
    await db.SaveChangesAsync();
    return Results.Ok();
});

app.MapGet("/moons", async (AstroDb db) =>
{
    var moons = await db.Moons.ToListAsync();
    return Results.Ok(moons);
});

app.MapPost("/moons", async (AstroDb db, Moon moon) =>
{
    var planet = await db.Planets.FindAsync(moon.PlanetId);
    if (planet is null)
    {
        return Results.NotFound();
    }
    await db.Moons.AddAsync(moon);
    await db.SaveChangesAsync();
    return Results.Created($"/moons/{moon.Id}", moon);
}).Produces<Moon>(StatusCodes.Status201Created);

app.MapGet("/moons/{id}", async (AstroDb db, int id) =>
{
    var moon = await db.Moons.FindAsync(id);
    if (moon is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(moon);
});

app.MapPut("/moons/{id}", async (AstroDb db, int id, Moon moon) =>
{
    if (id != moon.Id)
    {
        return Results.BadRequest();
    }
    db.Moons.Update(moon);
    await db.SaveChangesAsync();
    return Results.Ok(moon);
});

app.MapDelete("/moons/{id}", async (AstroDb db, int id) =>
{
    var moon = await db.Moons.FindAsync(id);
    if (moon is null)
    {
        return Results.NotFound();
    }
    var planet = await db.Planets.FindAsync(moon.PlanetId);
    if (planet is null)
    {
        return Results.NotFound();
    }
    db.Moons.Remove(moon);
    await db.SaveChangesAsync();
    return Results.Ok();
});

app.MapGet("/asteroids", async (AstroDb db) =>
{
    return await db.Asteroids.ToListAsync();
});

app.MapGet("/asteroids/{id}", async (AstroDb db, int id) =>
{
    var asteroid = await db.Asteroids.FindAsync(id);
    if (asteroid is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(asteroid);
});

app.MapPost("/asteroids", async (AstroDb db, Asteroid asteroid) =>
{
    db.Asteroids.Add(asteroid);
    await db.SaveChangesAsync();
    return Results.Created($"/asteroids/{asteroid.Id}", asteroid);
});

app.MapPut("/asteroids/{id}", async (AstroDb db, int id, Asteroid asteroid) =>
{
    if (id != asteroid.Id)
    {
        return Results.BadRequest();
    }
    db.Asteroids.Update(asteroid);
    await db.SaveChangesAsync();
    return Results.Ok(asteroid);
});

app.MapDelete("/asteroids/{id}", async (AstroDb db, int id) =>
{
    var asteroid = await db.Asteroids.FindAsync(id);
    if (asteroid is null)
    {
        return Results.NotFound();
    }
    db.Asteroids.Remove(asteroid);
    await db.SaveChangesAsync();
    return Results.Ok(asteroid);
});

app.Run();
