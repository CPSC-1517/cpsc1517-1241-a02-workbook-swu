using FluentAssertions;// for Should() extension method
using NhlHockeySystem;  // for Player class

namespace NhlHockeySystemTest
{
    public class Player_Should
    {
        [Theory]
        [InlineData("Connor McDavid", 97, Position.C)]
        [InlineData("Stuart Skinner", 74, Position.G)]
        [InlineData("Evan Bouchard", 2, Position.D)]
        [InlineData("Zach Hyman", 18, Position.LW)]
        [InlineData("Vasily Poldkolzin", 18, Position.RW)]
        public void Player_WhenPassedValidValues_ShouldCreatePlayer(
           string playerName,
           int playerNumber,
           Position playerPosition)
        {
            // Arrange: set up the test objects and expected data
            // Act: execute the method that is being tested
            // Arrange and Act
            Player actualPlayer = new Player(playerName,playerNumber,playerPosition);

            // Assert: verify the result is as expected
            actualPlayer.Name.Should().Be(playerName);
            actualPlayer.JerseyNumber.Should().Be(playerNumber);
            actualPlayer.Position.Should().Be(playerPosition);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(99)]
        public void JerseyNumber_WhenAssignedInvalidValue_ShouldThrowsArgumentExceptionWithExpectedMessage(
            int invalidPlayerNumber)
        {
            // Testing for exceptions
            // Arrange: set up the test scenario
            string playerName = "Jack Smith";
            Position playerPostion = Position.C;
            int validPlayerNumber = 0;
            Player currentPlayer = new Player(playerName, validPlayerNumber, playerPostion);

            // Act: perform the action and capture the exception
            //Action act = () => new Player(playerName, playerNumber,playerPostion);
            Action act = () => currentPlayer.JerseyNumber = invalidPlayerNumber;

            // Assert: verify that the expected exception is thrown
            act.Should()
                .Throw<ArgumentException>()
                .WithMessage("*between 0 and 98*");
        }
    }
}
