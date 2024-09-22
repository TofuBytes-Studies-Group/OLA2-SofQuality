using Xunit;

namespace OLA2_SofQuality.Tests.Validator_test;

public class ValidatorTest
{
    [Theory]
    [InlineData("hejsa")]
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")] // 256 characters


    public void ValidateDescription_ShouldReturnTrue_WhenDescriptionIsValid(string validDescription)
    {
        // Act
        var result = Validator.Validator.ValidateDescription(validDescription);

        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData("test")]
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")] // 256 characters
    public void ValidateDescription_ShouldReturnFalse_WhenDescriptionIsInvalid(string invalidDescription)
    {
        // Act
        var result = Validator.Validator.ValidateDescription(invalidDescription);

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
        var result = Validator.Validator.ValidateCategory(category);

        // Assert
        Assert.True(result);
    }
    
    [Theory]
    [InlineData("A")]
    [InlineData("ThisStringIsWaaaaaaaaaayOver50CharactersAndShouldReturnFalse")]
    public void ValidateCategory_ShouldReturnFalse_WhenCategoryIsInvalid(string category)
    {
        // Act
        var result = Validator.Validator.ValidateCategory(category);

        // Assert
        Assert.False(result);
  
    }

    [Fact]
    public void ValidateDeadline_ShouldReturnTrue_WhenDeadlineIsValid()
    {
        // Arrange
        var validDeadline = DateTime.Now.AddMinutes(1);

        // Act
        var result = Validator.Validator.ValidateDeadline(validDeadline);

        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void ValidateDeadline_ShouldReturnFalse_WhenDeadlineIsNotValid()
    {
        // Arrange
        var validDeadline = DateTime.Now.AddMinutes(-1);

        // Act
        var result = Validator.Validator.ValidateDeadline(validDeadline);

        // Assert
        Assert.False(result);
    }
}