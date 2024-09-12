using ObjectClassLibrary;
using FluentAssertions;

namespace ObjectClassLibraryTest
{
    public class BodyMassIndexTest
    {
        [Fact]
        public void Bmi_ValidValues_ShouldReturnBmiValue()
        {
            // Given - Arrange
            var name = "Jack Black";
            var weight = 180;
            var height = 65;
            // When - Act
            var actual = new BodyMassIndex(name, weight, height);
            // Then - Assert
            actual.Name.Should().Be(name);
            actual.Weight.Should().Be(weight);
            actual.Height.Should().Be(height);
            actual.Bmi().Should().Be(30);
        }
    }
}