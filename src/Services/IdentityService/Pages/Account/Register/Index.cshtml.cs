using IdentityService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityService.Pages.Register;
[AllowAnonymous]
[SecurityHeaders]
public class Index : PageModel
{
    private readonly UserManager<ApplicationUser> _userManager;

    public Index(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    
    [BindProperty]public InputModel Input { get; set; }
    
    public async Task<IActionResult> OnGet(string returnUrl)
    {
        Input = new InputModel
        {
            ReturnUrl = returnUrl
        };
        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid) return Page();

        var user = new ApplicationUser
        {
            UserName = Input.Username
        };
        var result = await _userManager.CreateAsync(user, Input.Password);

        if (!result.Succeeded) return Page();


        return RedirectToPage("../Login/Index");
    }
}