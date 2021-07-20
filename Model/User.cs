using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ExpenseHeader> RequesterExpenseHeaders { get; set; }
        public List<ExpenseHeader> ApproverExpenseHeaders { get; set; }
    }
}
