namespace Domain.Interface.Models
{
    public class AliasInformation
    {
        public AliasInformation(int companyId, int? employeeId)
        {
            CompanyId = companyId;
            EmployeeId = employeeId;
        }

        public int CompanyId { get; }
        public int? EmployeeId { get; }
    }
}