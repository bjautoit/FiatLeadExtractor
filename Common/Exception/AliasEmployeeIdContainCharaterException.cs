namespace Common.Exception
{
    public class AliasEmployeeIdContainCharaterException : AliasTranslationException
    {
        public AliasEmployeeIdContainCharaterException(string message, string alias) : base(message, alias)
        {
        }
    }
}