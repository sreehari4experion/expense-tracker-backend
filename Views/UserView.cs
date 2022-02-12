﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTrackerNew.Views
{
    public class UserView
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
