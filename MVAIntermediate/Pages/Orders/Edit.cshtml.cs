using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVAIntermediate.Data;
using MVAIntermediate.Models;

namespace MVAIntermediate.Pages.Orders
{
    public class EditModel : PageModel
    {
        private readonly MVAIntermediate.Data.ApplicationDbContext _context;

        public EditModel(MVAIntermediate.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(OrderMasters).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderMastersExists(OrderMasters.OrderNo))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OrderMastersExists(int id)
        {
            return _context.OrderMasters.Any(e => e.OrderNo == id);
        }
    }
}
