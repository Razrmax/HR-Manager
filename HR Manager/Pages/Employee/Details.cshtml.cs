using System.Threading.Tasks;
using HR_Manager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HR_Manager.Pages.Employee
{
    public class DetailsModel : PageModel
    {
        private readonly HR_ManagerContext _context;

        public DetailsModel(HR_ManagerContext context)
        {
            _context = context;
        }

        public Models.Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Employee = await _context.Employee.FirstOrDefaultAsync(m => m.Id == id);

            if (Employee == null) return NotFound();
            return Page();
        }
    }
}