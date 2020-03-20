using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using bictly.Data;
using bictly.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bictly.Controllers
{
    public class AccountController : Controller
    {
        private readonly BictlyContext _context;
        public AccountController(BictlyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(string name)
        {
            if (name == null)
                return NotFound();
            var curruser = _context.User.FirstOrDefault(m => m.username == name);
            if (curruser == null)
                return NotFound();
            var articles = _context.Article.Include(m => m.Author).Where(m => m.Author == curruser).OrderByDescending(m => m.id).ToList();
            ViewBag.UserData = curruser;
            return View(articles);
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if(!HttpContext.User.Identity.IsAuthenticated)
            {
                static string ComputeShaHash(string rawData)
                {
                    using (SHA256 sha256Hash = SHA256.Create())
                    {
                        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                        StringBuilder builder = new StringBuilder();
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            builder.Append(bytes[i].ToString("x2"));
                        }
                        return builder.ToString();
                    }
                }
                var hashedpswd = ComputeShaHash(password);
                if (_context.User.Any(m => m.username == username && m.password == hashedpswd))
                {
                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
                    var userIdentety = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentety);
                    await HttpContext.SignInAsync(principal);
                    return Redirect($"/Account/?name={username}");
                }
                else
                {
                    ViewBag.Error = "username or password is incorrect";
                    return View();
                }
            }
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(string username, string password, string passwordC)
        {
            if (!HttpContext.User.Identity.IsAuthenticated) 
            {
                if (!_context.User.Any(m => m.username == username))
                {
                    static string ComputeShaHash(string rawData)
                    {
                        using (SHA256 sha256Hash = SHA256.Create())
                        {
                            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                            StringBuilder builder = new StringBuilder();
                            for (int i = 0; i < bytes.Length; i++)
                            {
                                builder.Append(bytes[i].ToString("x2"));
                            }
                            return builder.ToString();
                        }
                    }
                    if (password == passwordC)
                    {
                        var new_User = new User
                        {
                            username = username,
                            password = ComputeShaHash(password),
                            IsAdmin = false,
                            reg_date = DateTime.Now,
                            token = ComputeShaHash(username + DateTime.UtcNow.ToString())
                        };
                        _context.User.Add(new_User);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Login));
                    }
                    ViewBag.Error = "passwords does not match";
                    return View();
                }
                ViewBag.Error = "this user already exists";
                return View();
            }
            return Redirect("/");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit()
        {
            User UserData = _context.User.First(m => m.username == HttpContext.User.Identity.Name);
            return View(UserData);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(string username)
        {

            return View();
        }
    }
}