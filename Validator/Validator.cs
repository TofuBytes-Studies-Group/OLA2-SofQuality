namespace OLA2_SofQuality.Validator;

public class Validator
{
    public bool ValidateDescription(string description)
    {
        // Add validation logic here
        return true;
    }

    public bool ValidateCategory(string category)
    {
        // Add validation logic here
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