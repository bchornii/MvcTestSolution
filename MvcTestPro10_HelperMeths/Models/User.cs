using System;
using System.Collections.Generic;

namespace MvcTestPro10_HelperMeths.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Address HomeAddress { get; set; }
        public bool IsApproved { get; set; }
        public Role Role { get; set; }
        public List<Role> AccessibleRoles { get; set; }
    }
}