using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PocketBalance.Data;
using PocketBalance.Models;

namespace PocketBalance.Pages.ExpenseCategories
{
    public class CreateModel : PageModel
    {
        private readonly PocketBalanceContext _context;

        public CreateModel(PocketBalanceContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ExpenseCategory ExpenseCategory { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ExpenseCategory.Add(ExpenseCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
