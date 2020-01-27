using System;
using System.Configuration;
using Common.Exception;
using Configuration = Common.Configuration;

namespace Domain
{
    public class FirstnameParser
    {
        private string _configurationFieldName = "FirstnameFieldName";
        private readonly string _fieldName;
        private readonly StringFieldParser _stringFieldParser;

        public FirstnameParser()
        {
            _stringFieldParser = new StringFieldParser();
            _fieldName = Configuration.GetConfiguration(_configurationFieldName);
        }

        public string Parse(string lead)
        {
            if (string.IsNullOrEmpty(_fieldName)) throw new ConfigurationErrorsException($"Configuration file contains no value for {_configurationFieldName}.");
            if (!lead.Contains(_fieldName)) throw new LeadFieldNameException($"{_fieldName} was not present in the lead.", lead);

            return _stringFieldParser.Parse(lead, _fieldName);
        }
    }

    public class LastNameParser
    {
        private string _configurationFieldName = "LastnameFieldName";
        private readonly string _fieldName;
        private readonly StringFieldParser _stringFieldParser;

        public LastNameParser()
        {
            _stringFieldParser = new StringFieldParser();
            _fieldName = Configuration.GetConfiguration(_configurationFieldName);
        }

        public string Parse(string lead)
        {
            if (string.IsNullOrEmpty(_fieldName)) throw new ConfigurationErrorsException($"Configuration file contains no value for {_configurationFieldName}.");
            if (!lead.Contains(_fieldName)) throw new LeadFieldNameException($"{_fieldName} was not present in the lead.", lead);

            return _stringFieldParser.Parse(lead, _fieldName);
        }
    }
}