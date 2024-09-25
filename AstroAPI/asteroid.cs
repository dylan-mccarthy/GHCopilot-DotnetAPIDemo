// An asteroid class for the API to use. Use similar parameters to the planet class.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroAPI 
{
    public class Asteroid
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DistanceFromSun { get; set; }

        public Asteroid(string name, string description, int distanceFromSun)
        {
            Name = name;
            Description = description;
            DistanceFromSun = distanceFromSun;
        }
    }
}