using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using stajerYonetim.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace stajerYonetim.Controllers
{

    public class LoginController : Controller
    {
        Context C=new Context();
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(Admin p)
        {
            var dataValue=C.Admins
           .FirstOrDefault(x=>x.UserName==p.UserName && x.Password==p.Password);
            HttpContext.Session.SetString("UserName", p.UserName);
            HttpContext.Session.SetString("Password", p.Password);


            if (dataValue!=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, p.UserName),
                };
                var useridentity=new ClaimsIdentity(claims,"Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
				return RedirectToAction("Index", "Yetkili");

            }
            var dataValue2 = C.Interns
          .FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            HttpContext.Session.SetString("UserName", p.UserName);
            HttpContext.Session.SetString("Password", p.Password);
            if (dataValue2 != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, p.UserName),
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Stajer");
            }
            var dataValue3 = C.Requests
        .FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            HttpContext.Session.SetString("UserName", p.UserName);
            HttpContext.Session.SetString("Password", p.Password);
            if (dataValue3 != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, p.UserName),
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Request");
            }
            ViewData["LoginFlag"] = "Invalid Username or Password!";

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Login");
        }
    }
}
