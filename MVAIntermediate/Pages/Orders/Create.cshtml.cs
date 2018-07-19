using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVAIntermediate.Data;
using MVAIntermediate.Models;

namespace MVAIntermediate.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly MVAIntermediate.Data.ApplicationDbContext _context;

        public CreateModel(MVAIntermediate.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public OrderMasters OrderMasters { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.OrderMasters.Add(OrderMasters);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}