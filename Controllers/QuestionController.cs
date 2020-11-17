using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestIT.Models;

namespace TestIT.Controllers
{
    public class QuestionController : Controller
    {
        private ApplicationDbContext db;
        public QuestionController(ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
                return View(db.Questions.ToList());
        }
        [HttpGet]
        public IActionResult AddNewQuestion()
        {
            var test = new Question();
            test.Answers = db.Answers.ToList();
            return View(test);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewQuestion(Test test)
        {
            db.Tests.Add(test);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
