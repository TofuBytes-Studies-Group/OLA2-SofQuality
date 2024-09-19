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
    [InlineData("hejsa")]
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")] // 256 characters


    public void ValidateDescription_ShouldReturnTrue_WhenDescriptionIsValid(string validDescription)
    {
        // Act
        bool result = _validator.ValidateDescription(validDescription);

        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData("test")]
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")] // 256 characters
    public void ValidateDescription_ShouldReturnFalse_WhenDescriptionIsInvalid(string invalidDescription)
    {
        // Act
        bool result = _validator.ValidateDescription(invalidDescription);

        // Assert
        Assert.False(result);
    }
  
    [Theory]
    [InlineData("StringWithOver2Chars")]
    [InlineData("AA")]
    [InlineData("ThisExactStringRightHereIsExactly50CharactersLoong")]
    public void ValidateCategory_ShouldReturnTrue_WhenCategoryIsValid(string category)
    {
        // Act
        bool result = _validator.ValidateCategory(category);

        // Assert
        Assert.True(result);
    }
    
    [Theory]
    [InlineData("A")]
    [InlineData("ThisStringIsWaaaaaaaaaayOver50CharactersAndShouldReturnFalse")]
    public void ValidateCategory_ShouldReturnFalse_WhenCategoryIsInvalid(string category)
    {
        // Act
        bool result = _validator.ValidateCategory(category);

        // Assert
        Assert.False(result);
  
    }

    [Fact]
    public void ValidateDeadline_ShouldReturnTrue_WhenDeadlineIsValid()
    {
        // Arrange
        DateTime validDeadline = DateTime.Now.AddMinutes(1);

        // Act
        bool result = _validator.ValidateDeadline(validDeadline);

        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void ValidateDeadline_ShouldReturnFalse_WhenDeadlineIsNotValid()
    {
        // Arrange
        DateTime validDeadline = DateTime.Now.AddMinutes(-1);

        // Act
        bool result = _validator.ValidateDeadline(validDeadline);

        // Assert
        Assert.False(result);
    }
}