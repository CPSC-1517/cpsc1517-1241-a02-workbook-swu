using FluentAssertions;// for Should()
using NhlHockeySystem; // for Position,Player,Team

namespace NhlHockeySystemTest
{
    public class Team_Should
    {
        [Fact]
        public void Team_WhenPassedValidValues_ShouldCreateTeam()
        {
            // Arrange: set up the test objects and expected data
            Player player1 = new Player("Connor McDavid", 97, Position.C);
            Player player2 = new Player("Stuart Skinner", 74, Position.G);
            Player player3 = new Player("Evan Bouchard", 2, Position.D);
            List<Player> playerList = new List<Player>();
            playerList.Add(player1);
            playerList.Add(player2);
            playerList.Add(player3);
            string expectedTeamName = "Edmonton Oilers";

            // Act: execute the method that is being tested
            Team actualTeam = new Team(expectedTeamName, playerList);

            // Assert: verify the result is as expected
            actualTeam.Name.Should().Be(expectedTeamName);
            actualTeam.PlayerCount.Should().Be(playerList.Count);
            actualTeam.Rosters.Should().BeEquivalentTo(playerList);
        }

        [Fact]
        public void AddPlayer_WhenPassedValidPlayer_ShouldbeAdded()
        {
            // Arrange: set up the test objects and expected data
            Player player1 = new Player("Connor McDavid", 97, Position.C);
            Player player2 = new Player("Stuart Skinner", 74, Position.G);
            Player player3 = new Player("Evan Bouchard", 2, Position.D);
            string expectedTeamName = "Edmonton Oilers";
            Team actualTeam = new Team(expectedTeamName, null);

            // Act: execute the method that is being tested
            actualTeam.AddPlayer(97, player1);
            actualTeam.AddPlayer(74, player2);
            actualTeam.AddPlayer(2, player3);

            // Assert: verify the result is as expected
            actualTeam.Name.Should().Be(expectedTeamName);
            actualTeam.PlayerCount.Should().Be(3);
            actualTeam.Rosters.Count.Should().Be(3);
        }
    }
}
