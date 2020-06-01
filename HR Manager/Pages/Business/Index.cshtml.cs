using System.Collections.Generic;
using System.Threading.Tasks;
using HR_Manager.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HR_Manager.Pages.Business
{
    public class IndexModel : PageModel
    {
        private readonly HR_ManagerContext _context;

        public IndexModel(HR_ManagerContext context)
        {
            _context = context;
        }

        public IList<Models.Business> Business { get; set; }

        public async Task OnGetAsync()
        {
            Business = await _context.Business.ToListAsync();
        }
    }
}