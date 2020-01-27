namespace Common.Exception
{
    public class AliasNoCompanyIdException : AliasTranslationException
    {
        public AliasNoCompanyIdException(string message, string alias) : base(message, alias)
        {
        }
    }
}