using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Common.Exception;
using Configuration = Common.Configuration;

namespace Domain
{
    public class StringFieldParser
    {
        public string Parse(string configurationFieldName, string lead)
        {
            var fieldName = Configuration.GetConfiguration(configurationFieldName);

            if (string.IsNullOrEmpty(fieldName)) throw new ConfigurationErrorsException($"Configuration file contains no value for {configurationFieldName}.");
            if (!lead.Contains(fieldName)) throw new LeadFieldNameException($"{fieldName} was not present in the lead.", lead);

            // We want to find the name value (sarah) of this string: "name: sarah\r\n"

            // Find index of fieldName
            // E.G. "name". The index will represent index of 'n' in "name". (index=0)
            var indexOfFieldName = lead.IndexOf(fieldName, StringComparison.Ordinal);
                
            // Find index of character after field name
            // E.G. the character after "name" which is ':' (index=4)
            var indexOfCharacterAfterFieldName = indexOfFieldName + fieldName.Length;

            // Skip two characters, because the characters following the field name always are colon and space.
            // E.G. the character selected is 's'. (index=6)
            var indexAfterColonAndSpace = indexOfCharacterAfterFieldName + 2; // Also represent starting index of valueField

            if (indexAfterColonAndSpace > lead.Length) throw new LeadFormatException("Lead format was unexpected.");

            // Find index of '\r', but skip whats before indexAfterColonAndSpace. All value fields are followed by "\r\n".
            // E.G. index=11
            var lastIndex = lead.IndexOf('\r', indexAfterColonAndSpace);

            if (lastIndex < 0) throw new LeadParsingException($"Separator '\\r' was expected after value of {fieldName}, but was not found.", lead);

            // Extract value field
            // E.G. take from indexAfterColonAndSpace(6) and (lastIndex(11) - indexAfterColonAndSpace(6) = 5) five characters forward.
            // Which gives us "sarah"
            var fieldValue = lead.Substring(indexAfterColonAndSpace, lastIndex - indexAfterColonAndSpace);

            return fieldValue;
        }
    }
}
