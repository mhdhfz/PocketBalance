using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PocketBalance.Data;
using PocketBalance.Models;

namespace PocketBalance.Pages.Expenses
{
    public class DetailsModel : PageModel
    {
        private readonly PocketBalanceContext _context;

        public DetailsModel(PocketBalanceContext context)
        {
            _context = context;
        }

        public Expense Expense { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Expense = await _context.Expense
                .Include(e => e.ExpenseCategory).FirstOrDefaultAsync(m => m.ID == id);

            if (Expense == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
