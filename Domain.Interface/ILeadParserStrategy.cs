using Domain.Interface.Models;

namespace Domain.Interface
{
    public interface ILeadParserStrategy
    {
        LeadInformation Parse(string lead);
    }
}
