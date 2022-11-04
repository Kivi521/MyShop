using System;
using Microsoft.AspNetCore.Identity;

namespace MyShop.Data.Entity
{
    public class StoreUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
