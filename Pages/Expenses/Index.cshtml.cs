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
    public class IndexModel : PageModel
    {
        private readonly PocketBalanceContext _context;

        public IndexModel(PocketBalanceContext context)
        {
            _context = context;
        }

        public IList<Expense> Expense { get;set; }

        public async Task OnGetAsync()
        {
            Expense = await _context.Expense
                .Include(e => e.ExpenseCategory).ToListAsync();
        }
    }
}
