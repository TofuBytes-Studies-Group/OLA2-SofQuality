using System;
using OLA2_SofQuality.Validator;
using Xunit;

namespace Validator_test;

public class ValidatorTest
{
    private readonly Validator _validator;

    public ValidatorTest()
    {
        _validator = new Validator();
    }
    
    // Var lidt usikker på om det her er fint, kunne ikke få det til at virke med inline data
    public static IEnumerable<object[]> GetDescriptionTestData()
    {
        yield return new object[] { "Test", false }; // 4 characters
        yield return new object[] { "Tests", true }; // 5 characters
        yield return new object[] { new string('a', 255), true }; // 255 characters
        yield return new object[] { new string('a', 256), false }; // 256 characters
    }

    [Theory]
    [MemberData(nameof(GetDescriptionTestData))]
    public void ValidateDescription_ShouldReturnExpectedResult(string description, bool expectedResult)
    {
        // Act
        bool result = _validator.ValidateDescription(description);

        // Assert
        Assert.Equal(expectedResult, result);
    }
    [Fact]
    public void ValidateDescription_ShouldReturnTrue_WhenDescriptionIsValid()
    {
        // Arrange
        string validDescription = "Testing";

        // Act
        bool result = _validator.ValidateDescription(validDescription);

        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void ValidateDescription_ShouldReturnFalse_WhenDescriptionIsInvalid()
    {
        // Arrange
        string invalidDescription = "hi";

        // Act
        bool result = _validator.ValidateDescription(invalidDescription);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ValidateCategory_ShouldReturnTrue_WhenCategoryIsValid()
    {
        // Arrange
        string validCategory = "Work";

        // Act
        bool result = _validator.ValidateCategory(validCategory);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ValidateDeadline_ShouldReturnTrue_WhenDeadlineIsValid()
    {
        // Arrange
        DateTime validDeadline = DateTime.Now.AddDays(1);

        // Act
        bool result = _validator.ValidateDeadline(validDeadline);

        // Assert
        Assert.True(result);
    }
}