namespace Common.Exception
{
    public class AliasNullOrEmptyException : AliasTranslationException
    {
        public AliasNullOrEmptyException(string message, string alias) : base(message, alias)
        {
        }
    }
}