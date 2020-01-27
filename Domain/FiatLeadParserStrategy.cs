using System;
using Common.Exception;
using Domain.Interface;
using Domain.Interface.Models;

namespace Domain
{
    public class FiatLeadParserStrategy : ILeadParserStrategy
    {
        public LeadInformation Parse(string lead)
        {
            if (string.IsNullOrEmpty(lead)) throw new LeadException("Lead was null or empty.");

            var name = new StringFieldParser().Parse("FirstnameFieldName", lead);
            var lastname = new StringFieldParser().Parse("LastnameFieldName", lead);

            return null;
        }
    }

    public class ParseError
    {
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public string ErrorMessage { get; set; }
        public Exception Exception { get; set; }
    }
}
