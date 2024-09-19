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
    
    [Theory]
    [InlineData("Testing", true)]
    public void ValidateDescription_ShouldReturnTrue_WhenDescriptionIsValid(string validDescription, bool expectedResult)
    {
        // Act
        bool result = _validator.ValidateDescription(validDescription);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("test", false)]
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", false)] // 256 characters
    public void ValidateDescription_ShouldReturnFalse_WhenDescriptionIsInvalid(string invalidDescription, bool expectedResult)
    {
        // Act
        bool result = _validator.ValidateDescription(invalidDescription);

        // Assert
        Assert.Equal(expectedResult, result);
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