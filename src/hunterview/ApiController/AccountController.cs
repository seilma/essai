using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using hunterview.Data;
using hunterview.Models.AccountViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using hunterview.Models;
using hunterview.Services;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace hunterview.ApiController
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ISmsSender smsSender,
              ApplicationDbContext context,
            ILoggerFactory loggerFactory)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _smsSender = smsSender;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }
        [HttpGet  ( "{email}/{password}")]
        [AllowAnonymous]
      
        public async Task<IActionResult> Login([FromRoute]string email, [FromRoute]string password)
        {

            if (ModelState.IsValid)
                
            { LoginViewModel model = new LoginViewModel { Email = email, Password = password, RememberMe = false };
             //   model.Password = "Bouda1993@";

            
              
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                      ApplicationUser su = _context.AppUSers.First(m => m.Email == model.Email);
                    _logger.LogInformation(1, "User logged in.");
                    su.Token= Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                    su.LastLogin = DateTime.Now;
                    _context.Entry(su).State = EntityState.Modified;
                   // _context.Update(su);
                    _context.SaveChanges();
                    return Ok(su);

                }
                
                if (result.IsLockedOut)
                {
                    _logger.LogWarning(2, "User account locked out.");
                    return Ok("Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Ok("error");
                }
            }

            // If we got this far, something failed, redisplay form
            return BadRequest();
        }

        [HttpGet("{token}")]
       
        public async Task<IActionResult> LogOff([FromRoute] String token)
        {
            ApplicationUser su = _context.AppUSers.First(m => m.Token == token);
            su.Token = "";
            _context.Update(su);
            _context.SaveChanges();
           
            await _userManager.UpdateSecurityStampAsync(su);
         
            _logger.LogInformation(4, "User logged out.");
            return Ok();
        }
    
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterFull([FromBody] ApplicationUser applicationUser)
        {

            if (ModelState.IsValid)
            {
                RegisterViewModel model = new RegisterViewModel { Email = applicationUser.Email, Password = applicationUser.Password, ConfirmPassword = applicationUser.Password,Birthday=applicationUser.Birthday,Country=applicationUser.Country,FirstName=applicationUser.FirstName,gender=applicationUser.gender,LastName=applicationUser.LastName,Role=applicationUser.Role,Sector=applicationUser.Sector};
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Birthday = applicationUser.Birthday, Country = applicationUser.Country, FirstName = applicationUser.FirstName, gender = applicationUser.gender, LastName = applicationUser.LastName, Role = applicationUser.Role, Sector = applicationUser.Sector,Token="fhdsjf" };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    user.Token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                    // Send an email with this link
                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                    //await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
                    //    $"Please confirm your account by clicking this link: <a href='{callbackUrl}'>link</a>");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    ApplicationUser u = _context.AppUSers.FirstOrDefault(t => t.Email == user.Email);
                    u.Token = user.Token;
                    _context.Entry(u).State = EntityState.Modified;
                    _logger.LogInformation(3, "User created a new account with password.");



                    return Ok(user);
                }
                return BadRequest(result);
            }

            // If we got this far, something failed, redisplay form
            return BadRequest();
        }
        [HttpGet("role/{Token}")]
        public IActionResult GetRole([FromRoute]string token)
        {

            if (ModelState.IsValid)
            {
                ApplicationUser au = _context.AppUSers.FirstOrDefault(t => t.Token == token);
                return Ok(au.Role.ToString());
            }
            return BadRequest();
        }

        [HttpGet("token/{Token}")]
        public IActionResult verifytoken([FromRoute]string token)
        {

            if (ModelState.IsValid)
            {

                ApplicationUser au = _context.AppUSers.FirstOrDefault(t => t.Token == token);
                if (au == null)
                {
                    return Ok();
                }
                else { return Ok(au); }
                
            }
            return BadRequest();
        }


        // If we got this far, something failed, redisplay form



    }
}
    
