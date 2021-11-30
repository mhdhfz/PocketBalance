using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PocketBalance.Models
{
    public class Expense
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Expense Name")]
        public string ExpenseName { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime ExpenseDate { get; set; }

        [Required]
        public float Amount { get; set; }
        [Display(Name = "Expense Category")]
        public int ExpenseCategoryId { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }

    }
}
