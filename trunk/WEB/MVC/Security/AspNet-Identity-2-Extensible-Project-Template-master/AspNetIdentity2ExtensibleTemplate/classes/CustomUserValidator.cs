using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace IdentitySample.classes
{
    /// <summary>
    /// <example>
    /// //Rest of code is removed for brevity
    ///Configure validation logic for usernames
    ///appUserManager.UserValidator = new MyCustomUserValidator(appUserManager)
    ///{
    ///    AllowOnlyAlphanumericUserNames = true,
    ///    RequireUniqueEmail = true
    ///};
    /// </example>
    /// </summary>
    public class CustomUserValidator : UserValidator<ApplicationUser>
    {

        //List<string> _allowedEmailDomains = new List<string> { "outlook.com", "hotmail.com", "gmail.com", "yahoo.com" };
        private readonly ApplicationUserManager _userManager;
        public CustomUserValidator(ApplicationUserManager appUserManager)            : base(appUserManager)
        {
            _userManager = appUserManager;
        }
       
        public override async Task<IdentityResult> ValidateAsync(ApplicationUser user)
        {
            var errors = new List<string>();
            //IdentityResult result = await base.ValidateAsync(user);

            if (_userManager != null)
            {
                //check username availability. and add a custom error message to the returned errors list.
                var existingAccount = await _userManager.FindByNameAsync(user.UserName);
                if (existingAccount != null && existingAccount.Id != user.Id)
                    errors.Add("El usuario ya existe");
            }

            //var emailDomain = user.Email.Split('@')[1];

            //if (!_allowedEmailDomains.Contains(emailDomain.ToLower()))
            //{
            //    var errors = result.Errors.ToList();

            //    errors.Add(String.Format("Email domain '{0}' is not allowed", emailDomain));

            //    result = new IdentityResult(errors);
            //}
            return errors.Any()
               ? IdentityResult.Failed(errors.ToArray())
               : IdentityResult.Success;
           
        }
    }


    /// <summary>
    /// Para agregarlo :
    /// <code><example>
    ///Rest of code is removed for brevity
    /// Configure validation logic for passwords
    ///appUserManager.PasswordValidator = new CustomPasswordValidator
    ///{
    ///    RequiredLength = 6,
    ///    RequireNonLetterOrDigit = true,
    ///    RequireDigit = false,
    ///    RequireLowercase = true,
    ///    RequireUppercase = true,
    ///};</example></code>
    /// </summary>
    public class CustomPasswordValidator : PasswordValidator
    {
        public override async Task<IdentityResult> ValidateAsync(string password)
        {
            IdentityResult result = await base.ValidateAsync(password);

            if (password.Contains("abcdef") || password.Contains("123456"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Password can not contain sequence of chars");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
    //public class CustomUserValidator<TUser> : IIdentityValidator<TUser>     where TUser : class, Microsoft.AspNet.Identity.IUser
    //{
    //    private readonly UserManager<TUser> _userManager;


    //    public CustomUserValidator(UserManager<TUser> manager)
    //    {
    //        _userManager = manager;
            
             
    //    }

    //    public async Task<IdentityResult> ValidateAsync(TUser user)
    //    {
    //        var errors = new List<string>();

    //        if (_userManager != null)
    //        {
    //            //check username availability. and add a custom error message to the returned errors list.
    //            var existingAccount = await _userManager.FindByNameAsync(user.UserName);
    //            if (existingAccount != null && existingAccount.Id != user.Id)
    //                errors.Add("El usuario ya existe");
    //        }

    //        //set the returned result (pass/fail) which can be read via the Identity Result returned from the CreateUserAsync
    //        return errors.Any()
    //            ? IdentityResult.Failed(errors.ToArray())
    //            : IdentityResult.Success;
    //    }
    //}
}