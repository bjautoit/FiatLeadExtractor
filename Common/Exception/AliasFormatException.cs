namespace Common.Exception
{
    public class AliasFormatException : AliasTranslationException
    {
        public AliasFormatException(string message, string alias) : base(message, alias)
        {
        }
    }
}