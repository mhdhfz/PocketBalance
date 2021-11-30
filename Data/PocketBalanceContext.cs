using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PocketBalance.Models;

namespace PocketBalance.Data
{
    public class PocketBalanceContext : DbContext
    {
        public PocketBalanceContext (DbContextOptions<PocketBalanceContext> options)
            : base(options)
        {
        }

        public DbSet<Expense> Expense { get; set; }

        public DbSet<ExpenseCategory> ExpenseCategory { get; set; }
    }
}
