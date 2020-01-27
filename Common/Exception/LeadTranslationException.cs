namespace Common.Exception
{
    public class LeadException : FiatLeadImportException
    {
        public LeadException(string message) : base(message)
        {
        }
    }

    public class LeadFormatException : LeadException
    {
        public LeadFormatException(string message) : base(message)
        {
        }
    }

    public class LeadParsingException : LeadException
    {
        public LeadParsingException(string message, string lead) : base(message)
        {
        }
    }

    public class LeadFieldNameException : LeadParsingException
    {
        public LeadFieldNameException(string message, string lead) : base(message, lead)
        {
        }
    }
}