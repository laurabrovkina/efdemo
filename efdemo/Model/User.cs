using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Model
{
    public class ExpanseUser
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string FullName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModified { get; set; }
        public List<ExpenseHeader> RequesterExpenseHeaders { get; set; }
        public List<ExpenseHeader> ApproverExpenseHeaders { get; set; }
    }
}

public class User : IdentityUser
{ }
