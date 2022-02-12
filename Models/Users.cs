using System;
using System.Collections.Generic;

namespace ExpenseTrackerNew.Models
{
    public partial class Users
    {
        public Users()
        {
            Expenses = new HashSet<Expenses>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Expenses> Expenses { get; set; }
    }
}
