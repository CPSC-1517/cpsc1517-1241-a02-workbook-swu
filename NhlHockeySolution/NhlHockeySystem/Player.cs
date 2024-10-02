using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlHockeySystem
{
    public class Player
    {
        // Define data fields
        private string _Name = string.Empty;
        private int _JerseyNumber;

        // Define fully-implemented properties
        public string Name
        {
            get => _Name; 
            set
            {
                // Name cannot be blank
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name is required");
                }
                _Name = value.Trim();
            }
        }
        public int JerseyNumber
        {
            get => _JerseyNumber;
            set
            {
                // JerseyNumber must be between 0 and 98.
                if (value < 0 || value > 98)
                {
                    throw new ArgumentException("Jersey Number must be between 0 and 98.");
                }
                _JerseyNumber = value;
            }
        }

        // Define auto-implemented properties
        public Position Position { get; set; }
        public int Goals { get; private set; }  // A method will be used to change the value of private set
        public int Assists { get; private set; }

        // Define read-only properties
        public int Points => Goals + Assists;

        // Define methods (including constructors)
        public Player(string name, int jerseyNumber, Position position)
        {
            Name = name;
            JerseyNumber = jerseyNumber;
            Position = position;
        }
        public void AddGoal()
        {
            Goals++;
        }
        public void AddAssist() => Assists++;

        public override string ToString()
        {
            // Return a list of values as required by the greedy constructor 
            // where each value is separated by a comma
            return $"{Name},{JerseyNumber},{Position}";
        }

        /// <summary>
        /// Returns a Player instance using the comma separated value text
        /// 
        /// Player player1 = Player.Parse("Connor McDavid,97,C");
        /// </summary>
        /// <param name="csvLine">Player data where each value is separated by comma</param>
        /// <returns></returns>
        public static Player Parse(string csvLine)
        {
            // Connor McDavid, 97, C
            // Break the line into an array of values separated by the comma delimiter
            string[] tokens = csvLine.Split(",");
            // Verify the number of elements is 3
            if (tokens.Length != 3)
            {
                throw new ArgumentException($"Line text is not in expected format. Player: {csvLine}");
            }
            // return a Player instance using the values from the array
            // Name is located in element index 0
            // JerseyNumber is located in element index 1
            // Position is located in element index 2
            string playerName = tokens[0];
            int playerJerseyNumber = int.Parse(tokens[1]);
            Position playerPosition = Enum.Parse<Position>(tokens[2]);
            return new Player(playerName, playerJerseyNumber, playerPosition);
        }
    }
}
