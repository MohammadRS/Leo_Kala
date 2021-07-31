using System.Collections.Generic;
using _0_Framework.Application;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Presentation.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleApplication _roleApplication;

        public RoleController(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
        }

        [HttpGet]
        public List<RoleViewModel> List()
        {
            return _roleApplication.List();
        }

        [HttpGet("{id}")]
        public EditRole GetDetails(long id)
        {
            return _roleApplication.GetDetails(id);
        }

        [HttpPost]
        public OperationResult Create(CreateRole command)
        {
            return _roleApplication.Create(command);
        }

        [HttpPut]
        public OperationResult Edit(EditRole command)
        {
            return _roleApplication.Edit(command);
        }

    }
}