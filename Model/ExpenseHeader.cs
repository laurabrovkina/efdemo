using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class ExpenseHeader
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(100, ErrorMessage = "{0} cannot be more than 100 characters")]
        [MinLength(10)]
        public string Description { get; set; }

        public DateTime? ExpenseDate { get; set; }

        [ForeignKey("Requester")]
        public int RequesterId { get; set; }

        [InverseProperty("RequesterExpenseHeaders")]
        public User Requester { get; set; }

        [ForeignKey("Approver")]
        public int ApproverId { get; set; }

        [InverseProperty("ApproverExpenseHeaders")]
        public User Approver { get; set; }

        public List<ExpenseLine> ExpenseLines { get; set; }
    }
}
