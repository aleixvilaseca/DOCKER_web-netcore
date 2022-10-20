using EjemploReal.Api.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploReal.Web.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {

        private readonly ApiClientService _api;

        public HomeController(ApiClientService api) => _api = api;

        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var data = await _api.GetMessages();
            return View(data ?? Enumerable.Empty<Message>());
        }

        [HttpGet("add")]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Message message)
        {
            message.DateUtc = DateTime.UtcNow;
            await _api.CreateMessage(message);
            return RedirectToAction(nameof(Index));
        }

    }
}
