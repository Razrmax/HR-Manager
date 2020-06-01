using System.Linq;
using System.Threading.Tasks;
using HR_Manager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HR_Manager.Pages.Employee
{
    public class EditModel : PageModel
    {
        private readonly HR_ManagerContext _context;

        public EditModel(HR_ManagerContext context)
        {
            _context = context;
        }

        [BindProperty] public Models.Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Employee = await _context.Employee.FirstOrDefaultAsync(m => m.Id == id);

            if (Employee == null) return NotFound();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.Attach(Employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(Employee.Id))
                    return NotFound();
                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}