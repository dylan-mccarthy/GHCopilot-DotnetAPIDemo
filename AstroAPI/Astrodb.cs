using AstroAPI;
using Microsoft.EntityFrameworkCore;

public class AstroDb : DbContext
{
    public AstroDb(DbContextOptions<AstroDb> options) : base(options)
    {
    }

    public DbSet<Planet> Planets => Set<Planet>();
    public DbSet<Moon> Moons => Set<Moon>();
    //TODO: Asteroids need to be more fleshed out 
    public DbSet<Asteroid> Asteroids => Set<Asteroid>();

}
