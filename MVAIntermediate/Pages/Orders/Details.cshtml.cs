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
    public class DetailsModel : PageModel
    {
        private readonly MVAIntermediate.Data.ApplicationDbContext _context;

        public DetailsModel(MVAIntermediate.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public OrderMasters OrderMasters { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderMasters = await _context.OrderMasters.SingleOrDefaultAsync(m => m.OrderNo == id);

            if (OrderMasters == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
