using DemoAutorization.Data;
using DemoAutorization.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace DemoAutorization.Controllers
{
    public class AutorizationController : Controller
    {
        //aythenticate
        private async Task Authenticate(string userName)
        {

            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, "ROLE"),
                    new Claim("my claim","value")
                };
           
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpPost]
        public async Task<IActionResult> Autorization(string login, string password)
        {
            //User user = DataContext.Users.Where(q => q.Login == login && q.Password == password) as User;
            User user = DataContext.Users[1];
            
            if(user != null)
            {
                await Authenticate(login); // авторизация
                return RedirectToAction("HomePage", "Home");
            }
            else
            {
                return BadRequest();
            }
            
        }

        [Authorize()]
        public async Task<IActionResult> Exit()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("HomePage", "Home");
        }
        public IActionResult Registration()
        {
            return View();
            
        }
        [HttpPost]
        public async Task<IActionResult> Registration(User user)
        {
            //TODO признаки валидации
            if (ModelState.IsValid)
            {

                await Authenticate(user.Login);
                return RedirectToAction("HomePage","Home");
            }
            else
            {
                return View(user);
            }
        }
    }
}
