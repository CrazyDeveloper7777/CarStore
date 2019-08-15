namespace CarShop.Web.Areas.Identity.Pages.Account.Manage
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;
    using CarShop.Common.Attributes;
    using CarShop.Data.Models;
    using CarShop.Services.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

#pragma warning disable SA1649 // File name should match first type name
    public class IndexModel : PageModel
#pragma warning restore SA1649 // File name should match first type name
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IEmailSender emailSender;
        private readonly IUsersService usersService;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            IUsersService usersService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailSender = emailSender;
            this.usersService = usersService;
        }

        public string Username { get; set; }

        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            var userName = await this.userManager.GetUserNameAsync(user);
            var email = await this.userManager.GetEmailAsync(user);
            var phone = await this.userManager.GetPhoneNumberAsync(user);

            this.Username = userName;
            this.Email = email;

            this.Input = new InputModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                City = user.City,
                Country = user.Country,
                PhoneNumber = phone,
                PhoneNumber2 = user.PhoneNumber2,
                PhoneNumber3 = user.PhoneNumber3,
            };

            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            var user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            await this.usersService.PersistChangedPersonalData(user, this.Input.FirstName, this.Input.LastName, this.Input.Country, this.Input.City, this.Input.PhoneNumber, this.Input.PhoneNumber2, this.Input.PhoneNumber3);

            await this.signInManager.RefreshSignInAsync(user);
            this.StatusMessage = "Your profile has been updated";
            return this.RedirectToPage();
        }

        //public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        //{
        //    if (!this.ModelState.IsValid)
        //    {
        //        return this.Page();
        //    }

        //    var user = await this.userManager.GetUserAsync(this.User);
        //    if (user == null)
        //    {
        //        return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
        //    }

        //    var userId = await this.userManager.GetUserIdAsync(user);
        //    var email = await this.userManager.GetEmailAsync(user);
        //    var code = await this.userManager.GenerateEmailConfirmationTokenAsync(user);
        //    var callbackUrl = this.Url.Page(
        //        "/Account/ConfirmEmail",
        //        pageHandler: null,
        //        values: new { userId = userId, code = code },
        //        protocol: this.Request.Scheme);
        //    await this.emailSender.SendEmailAsync(
        //        email,
        //        "Confirm your email",
        //        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

        //    this.StatusMessage = "Verification email sent. Please check your email.";
        //    return this.RedirectToPage();
        //}

        public class InputModel
        {
            [Display(Name = "First name")]
            public string FirstName { get; set; }

            [Display(Name = "Last name")]

            public string LastName { get; set; }

            public string Country { get; set; }

            public string City { get; set; }

            [BGPhoneNumber]
            public string PhoneNumber { get; set; }

            [BGPhoneNumber]
            public string PhoneNumber2 { get; set; }

            [BGPhoneNumber]
            public string PhoneNumber3 { get; set; }
        }
    }
}
