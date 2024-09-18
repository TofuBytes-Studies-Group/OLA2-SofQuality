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