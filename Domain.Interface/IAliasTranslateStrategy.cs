using Domain.Interface.Models;

namespace Domain.Interface
{
    public interface IAliasTranslateStrategy
    {
        AliasInformation Translate(string alias);
    }
}