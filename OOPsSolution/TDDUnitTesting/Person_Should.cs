using FluentAssertions; // for Should() extension method
using OOPsReview;
using System.Net.Security;
using Xunit.Sdk; // for Person class

namespace TDDUnitTesting
{
    public class Person_Should
    {
        [Fact]
        public void DefaultContructor_PropertyIntialization_PropertiesInitialized()
        {
            // Arrange
            string expectedFirstName = "unknown";
            string expectedLastName = "Unknown";
            int expectedEmploymentPositionCount = 0;

            // Act
            Person sut = new Person();

            // Assert
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().BeEquivalentTo(expectedLastName);
            sut.EmploymentPositions.Count.Should().Be(expectedEmploymentPositionCount);
        }

        [Fact]
        public void GreedyContructor_NoAddressNoEmploymentPositions_AddressNullEmployeePositionCountZero()
        {
            // Arrange
            string expectedFirstName = "Bruce";
            string expectedLastName = "Less";
            int expectedEmploymentPositionCount = 0;

            // Act
            Person sut = new Person(expectedFirstName, expectedLastName, null, null);

            // Assert
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().BeEquivalentTo(expectedLastName);
            sut.Address.Should().BeNull();
            sut.EmploymentPositions.Count.Should().Be(expectedEmploymentPositionCount);
        }

    }
}
