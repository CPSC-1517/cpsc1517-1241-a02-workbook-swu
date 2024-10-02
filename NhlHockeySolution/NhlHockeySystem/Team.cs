using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NhlHockeySystem
{
    public class Team
    {
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set
            {
                // Name is required and must be in the format word_word
                // such "Edmonton Oilers" or "Toronto Maple Leafs"
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be blank.");
                }
                Regex pattern = new Regex("^\\w+\\s\\w+$");
                if (!pattern.IsMatch(value))
                {
                    throw new FormatException("Name must contain at least two words separated by a single space character");
                }
                _Name = value.Trim();
            }
        }
        public List<Player> Rosters { get; set; } = new List<Player>();
        public int PlayerCount => Rosters.Count;

        public Team(string name, List<Player> players)
        {
            Name = name;
            if (players != null)
            {
                Rosters = players;
            }
            //Rosters.Add(new Player("Calvin Pickard", 30, Position.G));
        }

        public void AddPlayer(int jerseyNumber, Player player)
        {
            // Validate player is not already on the team by checking the jerseyNumber
            //bool jerseyNumberExists = false;
            //foreach (Player currentPlayer in Rosters)
            //{
            //    if (currentPlayer.JerseyNumer == jerseyNumber) 
            //    {
            //        jerseyNumberExists = true;
            //        break;
            //    }
            //}
            bool jerseyNumberExists = Rosters.Any(currentPlayer =>
                                          currentPlayer.JerseyNumber == jerseyNumber);
            if (jerseyNumberExists)
            {
                throw new ArgumentException($"JerseyNumber {jerseyNumber} is already taken.");
            }

            Rosters.Add(player);
        }
    }
}
