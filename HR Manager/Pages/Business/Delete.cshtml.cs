using System.Threading.Tasks;
using HR_Manager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HR_Manager.Pages.Business
{
    public class DeleteModel : PageModel
    {
        private readonly HR_ManagerContext _context;

        public DeleteModel(HR_ManagerContext context)
        {
            _context = context;
        }

        [BindProperty] public Models.Business Business { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Business = await _context.Business.FirstOrDefaultAsync(m => m.Id == id);

            if (Business == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

            Business = await _context.Business.FindAsync(id);

            if (Business != null)
            {
                _context.Business.Remove(Business);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}