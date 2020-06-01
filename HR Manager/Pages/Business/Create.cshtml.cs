using System.Threading.Tasks;
using HR_Manager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HR_Manager.Pages.Business
{
    public class CreateModel : PageModel
    {
        private readonly HR_ManagerContext _context;

        public CreateModel(HR_ManagerContext context)
        {
            _context = context;
        }

        [BindProperty] public Models.Business Business { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.Business.Add(Business);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}