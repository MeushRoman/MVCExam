using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class StatementRegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowModal()
        {
            var documents = new List<Document>()
            {
                new Document{Id = 1, Name = "stage1", Data="<div><h1>It's TeSt1</h1></div>"},
                new Document{Id = 2, Name = "stage2", Data="<div><h1>It's TeSt2</h1></div>"},
                new Document{Id = 3, Name = "stage3", Data="<div><h1>It's TeSt3</h1></div>"}
            };
            return View(documents);
        }
        public bool ShowModal1(Document response)
        {
           
            return true;
        }

        [HttpPost]
        public IActionResult Index(Document response)
        {
            
            return View();
        }
    }
}