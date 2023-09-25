public class Moon
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int DistanceFromPlanet { get; set; }

    public int PlanetId { get; set; }

    public Moon(string name, string description, int distanceFromPlanet, int planetId)
    {
        Name = name;
        Description = description;
        DistanceFromPlanet = distanceFromPlanet;
        PlanetId = planetId;
    }
}