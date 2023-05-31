using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Personal.Core.Dto.Dtos.Contact;
using Personal.Core.Service.Services;

namespace PersonalUI.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ContactController : Controller
    {
        private readonly IContactService _ContactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService ContactService, IMapper mapper)
        {
            _ContactService = ContactService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<ContactListDto>>(await _ContactService.ToListAsync()));
        }
        public async Task<IActionResult> DetailContact(int id)
        {
            var Contact = await _ContactService.GetByIdAsync(id);

            return View(new ContactListDto()
            {
                Id = Contact.Id,
                Email = Contact.Email,
                FullName = Contact.FullName,
                Message = Contact.Message,
                Phone = Contact.Phone,
            });
        }
        public async Task<IActionResult> DeleteContact(int id)
        {
            var Contact = await _ContactService.GetByIdAsync(id);
            Contact.Status = false;
            Contact.DeletedAt = DateTime.Now;
            await _ContactService.UpdateAsync(Contact);
            return Redirect("~/Admin/Contact/Index");
        }
        public async Task<IActionResult> ChangeStatusContact(int id)
        {
            var Contact = await _ContactService.GetByIdAsync(id);
            await _ContactService.ChangeStatusAsync(Contact, Contact.Status);
            return Redirect("~/Admin/Contact/Index");
        }
        public async Task<IActionResult> DeletePermanentlyContact(int id)
        {
            await _ContactService.DeleteAsync(await _ContactService.GetByIdAsync(id));
            return Redirect("~/Admin/Contact/Index");
        }
        public async Task<IActionResult> DeletePermanentlyAllContact()
        {
            await _ContactService.DeleteAllAsync("Contacts");
            return Redirect("~/Admin/Contact/Index");
        }
        public async Task<IActionResult> PassiveAllContact()
        {
            await _ContactService.ChangeStatusAllAsync(await _ContactService.ToListAsync(), true);
            return Redirect("~/Admin/Contact/Index");
        }
    }
}
