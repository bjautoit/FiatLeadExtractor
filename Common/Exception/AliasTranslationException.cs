namespace Common.Exception
{
    public class AliasTranslationException : FiatLeadImportException
    {
        public AliasTranslationException(string message, string alias) : base(message)
        {
        }
    }
}