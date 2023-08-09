using CRM1.Data;
using CRM1.Models;
using CRM1.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM1.Controllers
{
    public class CRMController : Controller
    {
        private readonly CrmDb crmDb;

        public CRMController(CrmDb crmDb)
        {
            this.crmDb = crmDb;
        }
        public IActionResult OpenGoogleMaps(string address)
        {
            string googleMapsUrl = $"https://www.google.com/maps/place/{Uri.EscapeDataString(address)}";

            return Redirect(googleMapsUrl);
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var lead = await crmDb.CRMs.ToListAsync();
            return View(lead);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]


        public async Task<IActionResult> Add(AddLead addLead)
        {
            var lead = new CRM()
            {
                Id = Guid.NewGuid(),
                CompanyName = addLead.CompanyName,
                CompaType = addLead.SelectedCompanyType,
                EmployeeCount = addLead.EmployeeCount,
                DmName = addLead.DmName,
                Email = addLead.Email,
                PhoneNumber = addLead.PhoneNumber,
                Address = addLead.Address,
            };
            await crmDb.CRMs.AddAsync(lead);
            await crmDb.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var lead = await crmDb.CRMs.FirstOrDefaultAsync(x => x.Id == id);
            if (lead != null)
            {
                var viewModel = new UpdateView()
                {
                    Id = lead.Id,
                    CompanyName = lead.CompanyName,
                    CompaType = lead.CompaType,
                    EmployeeCount = lead.EmployeeCount,
                    DmName = lead.DmName,
                    Email = lead.Email,
                    PhoneNumber = lead.PhoneNumber,
                    Address = lead.Address,
                };
                return await Task.Run(() => View("View",viewModel));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
         public async Task<IActionResult> View(UpdateView model)
        {
            var lead = await crmDb.CRMs.FindAsync(model.Id);

            if(lead != null)
            {
                lead.Id = model.Id;
                lead.CompanyName = model.CompanyName;
                lead.CompaType = model.CompaType;
                lead.EmployeeCount = model.EmployeeCount;
                lead.DmName = model.DmName;
                lead.Email = model.Email;
                lead.PhoneNumber = model.PhoneNumber;
                lead.Address = model.Address;

                await crmDb.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateView model)
        {
            var lead = await crmDb.CRMs.FindAsync(model.Id);
            if(lead != null)
            {
                crmDb.CRMs.Remove(lead);
                await crmDb.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        
    }
}
