using LoveFirst.Helper;
using LoveFirst.Models;
using LoveFirst.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LoveFirst.Controllers
{
    public class AuthController : Controller
    {
        private IRepository _repository;

        public AuthController(IRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _repository.FindByLogin(model.Login).ToList();

            if (user.Count() == 1)
            {
                if (Sha256Hash.ComputeSha256Hash(model.Password) == user[0].PasswordHash)
                {
                    var claims = new List<Claim>
                    {
                        new Claim("Demo", "Value")
                    };
                    var claimIdentity = new ClaimsIdentity(claims, "Cookie");
                    var claimPrincipal = new ClaimsPrincipal(claimIdentity);
                    await HttpContext.SignInAsync("Cookie", claimPrincipal);

                    CreateSessionData(user);

                    return Redirect("/Home/Home");
                }
                ViewBag.result = "Неверный пароль";
                return View();
            }
            ViewBag.result = "Такого пользователя не существует";
            return View();
        }

        public IActionResult LogOff()
        {
            HttpContext.SignOutAsync("Cookie");
            return Redirect("/Auth/Login");
        }

        private void CreateSessionData(List<Profiles> user)
        {
            HttpContext.Session.SetInt32("profileId", user[0].ProfileId);
            HttpContext.Session.SetString("login", user[0].Login);
            HttpContext.Session.SetInt32("counterId", _repository.GetCounterId(user[0].ProfileId));
        }
    }
}
