using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PocketBalance.Data;
using PocketBalance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketBalance.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PocketBalanceContext _context;

        public IndexModel(ILogger<IndexModel> logger, PocketBalanceContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public Expense Expense { get; set; }
        public float TotalExpenses { get; set; }
        public float TotalExpensesByMonth { get; set; }
        public float TotalExpensesByWeek { get; set; }






        public void OnGet()
        {
           TotalExpenses = _context.Expense.Select(e => e.Amount).Sum();
           TotalExpensesByMonth = _context.Expense.Where(d => d.ExpenseDate > DateTime.Now.AddMonths(-1))
                                                   .Select(e => e.Amount).Sum();
            TotalExpensesByWeek = _context.Expense.Where(d => d.ExpenseDate > DateTime.Now.AddDays(-7))
                                                   .Select(e => e.Amount).Sum();
        }
    }
}
