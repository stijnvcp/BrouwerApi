using BrouwerWebApp.Models;
using BrouwerWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BrouwerWebApp.Controllers {
    public class HomeController : Controller {
        private readonly IBrouwerRepository repository;

        public HomeController(IBrouwerRepository repository) {
            this.repository = repository;
        }

        public async Task<IActionResult> Index() => View(await repository.FindAllAsync());

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
