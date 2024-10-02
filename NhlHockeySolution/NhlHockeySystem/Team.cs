using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlHockeySystem
{
    public class Team
    {
        public List<Player> Rosters { get; set; } = new List<Player>();

        public Team()
        {
            //Player conner = new Player("Connor McDavid", 97, Position.C);
            //Rosters.Add(conner);
            //Goalie skinner = new Goalie("Stuart Skinner", 0, Position.G);
            //Rosters.Add(skinner);
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
