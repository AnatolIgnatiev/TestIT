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
    public class TestController : Controller
    {
        private ApplicationDbContext db;
        public TestController(ApplicationDbContext context)
        {
            db = context;
        }
            public IActionResult Index()
        {
            return View(db.Tests.ToList());
        }

        [HttpGet]
        public IActionResult AddNewTest()
        {
            var test = new Question();
            test.Answers = db.Answers.ToList();
            return View(test);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewTest(Test test)
        {
            db.Tests.Add(test);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Test test = await db.Tests.FirstOrDefaultAsync(t => t.TestId == id);
                if (test != null)
                {
                    return View(test);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Test test)
        {
            db.Tests.Update(test);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        //[HttpGet]
        //[ActionName("Delete")]
        //public async Task<IActionResult> ConfirmDelete(int? id)
        //{
        //    if (id != null)
        //    {
        //        Test user = await db.Tests.FirstOrDefaultAsync(p => p.Id == id);
        //        if (user != null)
        //            return View(user);
        //    }
        //    return NotFound();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id != null)
        //    {
        //        Test user = await db.Tests.FirstOrDefaultAsync(p => p.Id == id);
        //        if (user != null)
        //        {
        //            db.Tests.Remove(user);
        //            await db.SaveChangesAsync();
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    return NotFound();
        //}

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
