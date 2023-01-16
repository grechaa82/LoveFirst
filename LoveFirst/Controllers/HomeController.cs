﻿using System.Diagnostics;
using System.Linq;
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

        /*[HttpPost]
        public IActionResult Home()
        {
            return View();
        }*/

        [HttpGet]
        public IActionResult History()
        {
            int id = (int)HttpContext.Session.GetInt32("counterId");

            var operations = _repository.GetOperations(id);

            return View(operations);
        }

        public IActionResult Settings()
        {
            return View();
        }
    }
}