using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LoveFirst.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoveFirst.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IRepository _repository;

        public HomeController(IRepository repository)
        {
            this._repository = repository;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Home()
        {
            int id;

            try
            {
                id = (int)HttpContext.Session.GetInt32("counterId");
            }
            catch
            {
                return Redirect("/Auth/Login");
            }

            ViewBag.totalScore = _repository.GetTotalScore(id);

            var participants = _repository.GetParticipants(id).ToList();

            return View(participants);
        }

        /*[HttpGet("/Home/AddPoint/{participantId:int}/{counterId:int}")]*/
        public IActionResult AddPoint(int participantId, int counterId)
        {
            _repository.AddPoint(participantId, counterId);

            return Redirect("/Home/Home");
        }

        [HttpGet]
        public IActionResult History()
        {
            int id = (int)HttpContext.Session.GetInt32("counterId");

            var operations = _repository.GetOperations(id).ToList();

            return View(operations);
        }

        public IActionResult Settings()
        {
            var participants = _repository.GetParticipants((int)HttpContext.Session.GetInt32("counterId")).ToList();

            return View(participants);
        }

        public IActionResult AddParticipant(string nameParticipant, int numberScore)
        {
            int counterId = (int)HttpContext.Session.GetInt32("counterId");

            _repository.AddParticipant(counterId, nameParticipant, numberScore);

            return Redirect("/Home/Settings");
        }
    }
}
