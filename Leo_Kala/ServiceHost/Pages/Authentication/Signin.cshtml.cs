using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Application;
using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages.Authentication
{
    public class SigninModel : PageModel
    {

        protected string SuccessMessage = "SuccessMessage";

        [TempData]
        public string LoginMessage { get; set; }

        

        private readonly IAccountApplication _accountApplication;

        public SigninModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(Login command)
        {
            var result = _accountApplication.Login(command);
            if (result.IsSuccedded)
            {
                TempData[SuccessMessage] = "ورود شما با موفقیت انجام شد";
                return RedirectToPage("/Index");
            }


            //LoginMessage = result.Message;
            return RedirectToPage("/Signin");
        }
        public IActionResult OnGetLogout()
        {
            _accountApplication.Logout();
            return RedirectToPage("/Index");
        }
    }
}
