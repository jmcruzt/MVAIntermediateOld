using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MVAIntermediate.Data;
using MVAIntermediate.Models;

namespace MVAIntermediate.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly MVAIntermediate.Data.ApplicationDbContext _context;

        public IndexModel(MVAIntermediate.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<OrderMasters> OrderMasters { get;set; }

        public async Task OnGetAsync()
        {
            OrderMasters = await _context.OrderMasters.ToListAsync();
        }
    }
}
