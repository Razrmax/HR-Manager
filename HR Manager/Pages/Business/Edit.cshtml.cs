using System.Linq;
using System.Threading.Tasks;
using HR_Manager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HR_Manager.Pages.Business
{
    public class EditModel : PageModel
    {
        private readonly HR_ManagerContext _context;

        public EditModel(HR_ManagerContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.Attach(Business).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessExists(Business.Id))
                    return NotFound();
                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool BusinessExists(int id)
        {
            return _context.Business.Any(e => e.Id == id);
        }
    }
}