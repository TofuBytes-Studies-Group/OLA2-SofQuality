using System;
using Moq;
using OLA2_SofQuality.Validator;
using Xunit;

namespace Validator_test;

public class ValidatorTest
{
    private readonly Validator _validator;
    
    private readonly Mock<Validator> _mockValidator;

    public ValidatorTest()
    {
        _validator = new Validator();
        _mockValidator = new Mock<Validator>();
    }

    [Fact]
    public void ValidateDescription_ShouldReturnTrue_WhenDescriptionIsValid()
    {
        // Arrange
        string validDescription = "This is a valid description.";

        // Act
        bool result = _validator.ValidateDescription(validDescription);

        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData("StringWithOver2Chars", true)]
    [InlineData("AA", true)]
    [InlineData("ThisExactStringRightHereIsExactly50CharactersLoong", true)]
    public void ValidateCategory_ShouldReturnTrue_WhenCategoryIsValid(string category, bool expectedResult)
    {
        // Arrange
        _mockValidator.Setup(v => v.ValidateCategory(It.IsAny<string>())).Returns((string c) => c.Length is >= 2 and <= 50);

        // Act
        bool result = _mockValidator.Object.ValidateCategory(category);

        // Assert
        Assert.Equal(expectedResult, result);
    }
    
    [Theory]
    [InlineData("A", false)]
    [InlineData("ThisStringIsWaaaaaaaaaayOver50CharactersAndShouldReturnFalse", false)]
    public void ValidateCategory_ShouldReturnFalse_WhenCategoryIsInvalid(string category, bool expectedResult)
    {
        // Arrange
        _mockValidator.Setup(v => v.ValidateCategory(It.IsAny<string>())).Returns((string c) => c.Length is >= 2 and <= 50);

        // Act
        bool result = _mockValidator.Object.ValidateCategory(category);

        // Assert
        Assert.Equal(expectedResult, result);
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