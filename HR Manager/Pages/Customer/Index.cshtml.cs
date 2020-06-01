using System.Collections.Generic;
using System.Threading.Tasks;
using HR_Manager.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HR_Manager.Pages.Customer
{
    public class IndexModel : PageModel
    {
        private readonly HR_ManagerContext _context;

        public IndexModel(HR_ManagerContext context)
        {
            _context = context;
        }

        public IList<Models.Customer> Customer { get; set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customer.ToListAsync();
        }
    }
}