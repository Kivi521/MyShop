using System;
using Microsoft.AspNetCore.Identity;

namespace OrderManagementSystemNew.Data.Entity
{
    public class StoreUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
