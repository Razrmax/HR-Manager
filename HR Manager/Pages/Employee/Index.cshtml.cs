using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_Manager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HR_Manager.Pages.Employee
{
    public class IndexModel : PageModel
    {
        private readonly HR_ManagerContext _context;

        public IndexModel(HR_ManagerContext context)
        {
            _context = context;
        }

        public IList<Models.Employee> Employee { get; set; }

        [BindProperty(SupportsGet = true)] public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var employees = _context.Employee.Select(m => m);
            if (!string.IsNullOrEmpty(SearchString))
                employees = employees.Where(s => s.LastName.Contains(SearchString));

            Employee = await employees.ToListAsync();
        }
    }
}