using CRM1.Models.Domain;

namespace CRM1.Models
{
    public class UpdateView
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public CompanyType CompaType { get; set; }
        public int EmployeeCount { get; set; }
        public string DmName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
