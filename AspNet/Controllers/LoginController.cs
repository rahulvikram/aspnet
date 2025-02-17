﻿using AspNet.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspNet.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Index")] // this action method parses the form data and logs the user in
        public async Task<IActionResult> Index(LoginModel req)
        {
            // ensures that the username and password are not empty
            if (!string.IsNullOrEmpty(req.Username) && !string.IsNullOrEmpty(req.Password))
            {
                // Validate username and password
                if (req.Username == "admin" && req.Password == "password") 
                {
                    // create a list of claims for the user 
                    // claim: k-v pair that represents user info (user and pass)
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, req.Username)
                    };

                    // this object represents the user's identity, specified Cookies as the authentication type
                    var identity = new ClaimsIdentity(claims, "Cookies");

                    // represents the authenticated user, this object is what we use to manage user identity thru app lifecycle
                    var principal = new ClaimsPrincipal(identity);

                    //// only necessary if we are using the rememberMe checkbox
                    //var authProperties = new AuthenticationProperties
                    //{
                    //    IsPersistent = rememberMe,  // This determines if the cookie is persistent
                    //    ExpiresUtc = rememberMe ? DateTime.UtcNow.AddDays(30) : DateTime.UtcNow.AddMinutes(30) // Set expiration based on rememberMe
                    //};

                    await HttpContext.SignInAsync("Cookies", principal); // awaits successful sign in with cookies
                    return RedirectToAction("Index", "Home"); // Redirect to a different page after successful login
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            return View(req);
        }
    }
}
