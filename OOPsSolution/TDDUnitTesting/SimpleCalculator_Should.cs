using FluentAssertions;// for Should() extension method
using OOPsReview;
using System.Configuration; // for OOPsReview class library classes

namespace TDDUnitTesting
{
    public class SimpleCalculator_Should
    {
        [Theory]
        [InlineData(5,8)]
        [InlineData(8,5)]
        [InlineData(250,-50)]
        public void Constructor_PropertyInitialized_PropertiesSet(
            int expectedOp1,
            int expectedOp2
            )
        {
            // Use the Arrange, Act, Assert pattern

            // Arrange and Act
            // sut = subject under test
            SimpleCalculator sut = new SimpleCalculator(expectedOp1, expectedOp2);
        
            // Assert - check if actual results matches expected results
            sut.Operand1.Should().Be(expectedOp1);
            sut.Operand2.Should().Be(expectedOp2);
        }

        [Theory]
        [InlineData(5,15)]
        [InlineData(100,3000)]
        [InlineData(5000,25000)]
        public void AddMethod_AddNumbers_ReturnsSum(int op1, int op2)
        {
            // Arrange
            SimpleCalculator calc = new SimpleCalculator(op1, op2);

            // Act
            int sut = calc.Add();

            // Assert
            int expectedSum = op1 + op2;
            sut.Should().Be(expectedSum);
        }

        [Fact]
        public void DivideMethod_DivisionByZero_ThrowsDivisionByZeroException()
        {
            // Arrange
            int op1 = 9;
            int op2 = 0;
            SimpleCalculator calc = new SimpleCalculator(op1, op2);

            // Act
            Action act = () => calc.Divide();

            // Assert
            act.Should().Throw<DivideByZeroException>();

        }

        [Theory]
        [InlineData(5,15)]
        [InlineData(15,3)]
        [InlineData(6000,36000)]
        public void DivideMethod_DividesNumber_ReturnsQuotient(int op1, int op2)
        {
            // Arrange
            SimpleCalculator calc = new SimpleCalculator(op1, op2);

            // Act
            double sut = calc.Divide();

            // Assert
            sut.Should().Be((double) op1 / op2);
        }
    }
}