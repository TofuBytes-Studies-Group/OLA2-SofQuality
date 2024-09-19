namespace OLA2_SofQuality.Validator;

public class Validator
{
    public bool ValidateDescription(string description)
    {
        // Add validation logic here
        return true;
    }

    // virtual method to be able to mock it
    public bool ValidateCategory(string category)
    {
        if(category.Length is < 2 or > 50)
        {
            return false;
        }
        return true;
    }

    public bool ValidateDeadline(DateTime deadline)
    {
        // Add validation logic here
        return true;
    }
}