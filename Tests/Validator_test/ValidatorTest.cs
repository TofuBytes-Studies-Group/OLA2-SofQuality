using System;
using OLA2_SofQuality.Validator;
using Xunit;

namespace Validator_test;

public class ValidatorTest
{
    private readonly Validator _validator;
    public ValidatorTest()
    {
        _validator = new Validator(); }

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
        DateTime validDeadline = DateTime.Now.AddDays(1);

        // Act
        bool result = _validator.ValidateDeadline(validDeadline);

        // Assert
        Assert.True(result);
    }
}