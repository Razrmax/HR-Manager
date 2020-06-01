using System.Threading.Tasks;
using HR_Manager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HR_Manager.Pages.Business
{
    public class DetailsModel : PageModel
    {
        private readonly HR_ManagerContext _context;

        public DetailsModel(HR_ManagerContext context)
        {
            _context = context;
        }

        public Models.Business Business { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Business = await _context.Business.FirstOrDefaultAsync(m => m.Id == id);

            if (Business == null) return NotFound();
            return Page();
        }
    }
}