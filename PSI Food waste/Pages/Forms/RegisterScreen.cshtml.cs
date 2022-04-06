using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PSI_Food_waste.Models;
using PSI_Food_waste.Services;

namespace PSI_Food_waste.Pages.Forms
{
    public class RegisterScreenModel : PageModel
    {
        public  IRegistrationEventNotifier _eventNotifier;
        public RegisteredUser<RegisterForm> RegisteredUsers { get; set; }/* = new RegisteredUser<RegisterForm>();*/

        public RegisterForm RegisteredUser { get; set; }

        [BindProperty]
        [Required]
        public string Email { get; set; }

        [BindProperty]
        [Required]
        public string Username { get; set; }
        [BindProperty]
        [Required]
        public string Pass { get; set; }
        [BindProperty]
        [Required]
        public int Num { get; set; }
        [BindProperty]
        public string Msg { get; set; }
        public string ErrorMsg { get; set; }

        public IRegisterRepository _registerRepository;

        public RegisterScreenModel(IRegistrationEventNotifier eventNotifier, IRegisterRepository registerRepository)
        {
            _eventNotifier = eventNotifier;
			_registerRepository = registerRepository;
        }
		
        public void OnGet()
        {
            ViewData["User"] = HttpContext.Session.GetString(key: "username");
            //RegisteredUsers = _registerRepository.GetAll();
            //if(RegisteredUsers == null)
            //{
            //RegisteredUsers = new RegisteredUser<RegisterForm>();
            //}
        }
        public IActionResult OnPost()
        {
            //email validation
            Regex regex3 = new Regex(@"^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$");
            // Username validation
            Regex regex = new Regex(@"^\w{3,20}$");

            // password validation
            Regex regex2 = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[\@$!%*#?&])[A-Za-z\d\@$!%*#?&]{8,}$");

            RegisteredUsers = _registerRepository.GetAll();
            if (Email == null || !regex3.IsMatch(Email))
            {
                ErrorMsg = "Incorrect Email";
                return Page();
            }
            for (int i = 0; i < RegisteredUsers.Length(); i++)
            {
                if (Email.Equals(RegisteredUsers[i].Email))
                {
                    ErrorMsg = "This email already exists";
                    return Page();
                }
            }
            if (Username == null || !regex.IsMatch(Username))
            { 
                ErrorMsg = "Username must contain from 3 to 20 characters with no special characters";
                return Page();
            }
            if (Pass == null || !regex2.IsMatch(Pass))
            {
                ErrorMsg = "Password must contain atleast 8 characters, one letter and a special character";
                return Page();
            }
            else
            {
                RegisteredUser = new RegisterForm(new List<Restaurant>(), new List<Restaurant>(), Email, Username, pass: Pass, favNum: Num);
                try
                {
                    _registerRepository.AddToList(RegisteredUser);
                }
                catch (IndexOutOfRangeException ex)
                {
                    ErrorMsg = ex.Message;
                    return Page();
                }
                
                _eventNotifier.RaiseEvent(this, new EmailNotificationArgs(Email, "You have successfuly registerd on Food Waste app!"));
                return RedirectToPage("/Forms/LoginScreen");
            }
        }
    }
}

