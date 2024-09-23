namespace OLA2_SofQuality.Validator;

public class Validator
{
    public static bool ValidateDescription(string description)
    {
        return description.Length is >= 5 and <= 255;
    }

    // virtual method to be able to mock it
    public static bool ValidateCategory(string category)
    {
        return category.Length is >= 2 and <= 50;
    }

    public static bool ValidateDeadline(DateTime deadline)
    {
        return deadline >= DateTime.Now;
    }
}