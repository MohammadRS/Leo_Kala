﻿using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.Infrastructure.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class RoleRepository : RepositoryBase<long, Role>, IRoleRepository
    {
        private readonly AccountContext _context;

        public RoleRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public EditRole GetDetails(long id)
        {
            return _context.Roles.Select(x => new EditRole
            {
                Id = x.Id,
                Name = x.Name
            }).AsNoTracking()
            .FirstOrDefault(x => x.Id == id);

            //role.Permissions = role.MappedPermissions.Select(x => x.Code).ToList();
        }

        public List<RoleViewModel> List()
        {
            return _context.Roles.Select(x => new RoleViewModel
            {
                 Id = x.Id,
                 Name = x.Name,
                 CreationDate = x.CreationDate.ToFarsi()
            }).ToList();
        }
    }
}
