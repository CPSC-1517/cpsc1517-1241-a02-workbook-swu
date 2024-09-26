using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlHockeySystem
{
    // Define a class named Goalie that inherits all
    // the properties and methods from the Player base class
    public class Goalie : Player
    {
        public double Svp {  get; set; } // SaveValuePercentage
        public double Gaa { get; set; } // GoalsAgainstAverage
        public int Shutouts { get; private set; }
        // Define constructor that passes value for name, jerseyNumber, and position
        // to the base Player constructor
        public Goalie(string name, int jerseyNumber, Position position) 
            : base(name, jerseyNumber, position)
        {

        }
        public void AddShutout() => Shutouts++;
    }
}
