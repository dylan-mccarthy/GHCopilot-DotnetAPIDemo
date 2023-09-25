public class Planet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int DistanceFromSun { get; set; }


    public Planet(string name, string description, int distanceFromSun)
    {
        Name = name;
        Description = description;
        DistanceFromSun = distanceFromSun;
    }
}