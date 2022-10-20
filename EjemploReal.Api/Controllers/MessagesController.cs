using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjemploReal.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EjemploReal.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessagesController : Controller
    {
        private readonly MessageDbContext _db;
        public MessagesController(MessageDbContext db) => _db = db;

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _db.Messages.ToListAsync();
            return Ok(list);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _db.Messages.FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound(new { Message = $"Not found message with id {id}" });
            }

            return Ok(item);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Message msg)
        {
            _db.Messages.Add(msg);
            await _db.SaveChangesAsync();
            return Created($"Messages/{msg.Id}", null);
        }


    }
}
