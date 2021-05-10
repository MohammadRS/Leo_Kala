﻿using System.Collections.Generic;

namespace _0_Framework.Application
{
    public class AuthViewModel
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public List<int> Permissions { get; set; }

        public AuthViewModel()
        {
        }

        public AuthViewModel(long id, long roleId, string email, List<int> permissions
            )
        {
            Id = id;
            RoleId = roleId;
            Email = email;
            Permissions = permissions;
        }
    }
}