namespace OLA2_SofQuality.Validator;

public class Validator
{
    public bool ValidateDescription(string description)
    {
        if (description.Length < 5 || description.Length > 255)
        {
            return false;
        }
        else if (description.Length >= 5 && description.Length <= 255)
        {
            return true;
        }
        return false;
        
    }

    public bool ValidateCategory(string category)
    {
        // Add validation logic here
        return true;
    }

    public bool ValidateDeadline(DateTime deadline)
    {
        // Add validation logic here
        return true;
    }
}