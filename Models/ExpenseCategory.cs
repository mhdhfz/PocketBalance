using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PocketBalance.Models
{
    public class ExpenseCategory
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Expense Category Name")]
        public string ExpenseCategoryName { get; set; }

        public Expense Expense { get; set; }


    }
}
