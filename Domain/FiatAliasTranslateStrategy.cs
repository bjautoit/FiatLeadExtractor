using System.Linq;
using Common.Exception;
using Domain.Interface;
using Domain.Interface.Models;

namespace Domain
{
    public class FiatAliasTranslateStrategy : IAliasTranslateStrategy
    {
        public AliasInformation Translate(string alias)
        {
            if (string.IsNullOrEmpty(alias)) throw new AliasNullOrEmptyException("Alias was null or empty.", alias);
            if (!IsFormatCorrect(alias)) throw new AliasFormatException("Alias was wrong format.", alias);
            var aliasWithoutKnownBit = alias.Replace("_fcaleads@autoit.dk", "");
            var companyId = ExtractCompanyIdFromAlias(aliasWithoutKnownBit);
            var employeeId = ExtractEmployeeIdFromAlias(aliasWithoutKnownBit);

            return new AliasInformation(companyId, employeeId);
        }

        private bool IsFormatCorrect(string alias)
        {
            return alias.Contains("_fcaleads@autoit.dk");
        }

        private int ExtractCompanyIdFromAlias(string alias)
        {
            var aliasSplit = alias.Split('_');
            if (!aliasSplit.Any()) throw new AliasNoCompanyIdException("No companyId was present in the alias.", alias);
            var companyIdString = aliasSplit[0];
            if (string.IsNullOrEmpty(companyIdString)) throw new AliasNoCompanyIdException("No companyId was present in the alias.", alias);
            if (!int.TryParse(companyIdString, out var companyId)) 
                throw new AliasCompanyIdContainCharacterException("CompanyId could not be parsed, because it contains non-digit characters.", alias);
            // CompanyId Validation?
            return companyId;
        }

        private int? ExtractEmployeeIdFromAlias(string alias)
        {
            var aliasSplit = alias.Split('_');
            if (!aliasSplit.Any()) return null;
            if (aliasSplit.Length < 2) return null;
            var employeeIdString = aliasSplit[1];
            if (string.IsNullOrEmpty(employeeIdString)) return null;
            if (!int.TryParse(employeeIdString, out var employeeId))
                throw new AliasEmployeeIdContainCharaterException("EmployeeId could not be parsed, because it containts non-digit characters.", alias);
            // EmployeeId Validation?
            return employeeId;
        }
    }
}
