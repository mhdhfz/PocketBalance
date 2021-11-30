using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PocketBalance.Data;
using PocketBalance.Models;

namespace PocketBalance.Pages.Expenses
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
        ViewData["ExpenseCategoryId"] = new SelectList(_context.Set<ExpenseCategory>(), "ID", "ExpenseCategoryName");
            return Page();
        }

        [BindProperty]
        public Expense Expense { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Expense.Add(Expense);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
