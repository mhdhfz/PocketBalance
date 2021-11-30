using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PocketBalance.Data;
using PocketBalance.Models;

namespace PocketBalance.Pages.ExpenseCategories
{
    public class DeleteModel : PageModel
    {
        private readonly PocketBalanceContext _context;

        public DeleteModel(PocketBalanceContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ExpenseCategory ExpenseCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ExpenseCategory = await _context.ExpenseCategory.FirstOrDefaultAsync(m => m.ID == id);

            if (ExpenseCategory == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ExpenseCategory = await _context.ExpenseCategory.FindAsync(id);

            if (ExpenseCategory != null)
            {
                _context.ExpenseCategory.Remove(ExpenseCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
