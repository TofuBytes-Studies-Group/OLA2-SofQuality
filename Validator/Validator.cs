namespace OLA2_SofQuality.Validator;

public class Validator
{
    public bool ValidateDescription(string description)
    {
        if (description.Length < 5 || description.Length > 255)
        {
            return false;
        }
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
        if(deadline < DateTime.Now)
        {
            return false;
        }
        return true;
    }
}