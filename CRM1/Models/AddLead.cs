using CRM1.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRM1.Models
{
    public class AddLead
    {
        public string CompanyName { get; set; }
        public CompanyType CompaType { get; set; }

        public int EmployeeCount { get; set; }
        public string DmName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public CompanyType SelectedCompanyType { get; set; }
        public IEnumerable<SelectListItem> CompanyTypeOptions { get; set; }
    }
}
