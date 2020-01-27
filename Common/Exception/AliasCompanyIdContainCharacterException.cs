namespace Common.Exception
{
    public class AliasCompanyIdContainCharacterException : AliasTranslationException
    {
        public AliasCompanyIdContainCharacterException(string message, string alias) : base(message, alias)
        {
        }
    }
}