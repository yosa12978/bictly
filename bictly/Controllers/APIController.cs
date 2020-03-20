using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bictly.Data;
using bictly.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bictly.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly BictlyContext _context;
        public APIController(BictlyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (!_context.User.Any(m => m.token == HttpContext.Request.Query["token"].ToString()))
                return Unauthorized(new { status = 401, message = "Unauthorized" });

            return Ok(_context.Article.OrderByDescending(m => m.id).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Detail(int? id)
        {
            if (!_context.User.Any(m => m.token == HttpContext.Request.Query["token"].ToString()))
                return Unauthorized(new { status = 401, message = "Unauthorized" });

            if (id == null)
                return NotFound(new { status = 404, message = "Not Found" });
            var result = _context.Article.First(m => m.id == id);
            if (result == null)
                return NotFound(new { status = 404, message = "Not Found" });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Article article)
        {
            if (!_context.User.Any(m => m.token == HttpContext.Request.Query["token"].ToString()))
                return Unauthorized(new { status = 401, message = "Unauthorized" });

            var currentUser = _context.User.First(m => m.token == HttpContext.Request.Query["token"].ToString());
            article.Author = currentUser;
            return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status201Created, new { status = 201, message = "Created"});
        }
    }
}