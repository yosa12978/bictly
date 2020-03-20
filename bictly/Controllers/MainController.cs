using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using bictly.Models;
using bictly.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace bictly.Controllers
{
    public class MainController : Controller
    {
        private readonly BictlyContext _context;
        private readonly ILogger<MainController> _logger;

        public MainController(ILogger<MainController> logger, BictlyContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Article.Include(m => m.Author).OrderByDescending(m => m.id).ToListAsync());
        }

        [HttpGet]
        public IActionResult Detail(int? id)
        {
            Article article;
            if (id == null)
                return NotFound();
            ViewBag.Comment = _context.Comment.Include(m => m.author).OrderByDescending(m => m.id).Where(m => m.articleId == id).ToList();
            try
            {
                article = _context.Article.Include(m => m.Author).First(m => m.id == id);
            }
            catch
            {
                return NotFound();
            }
            if (article == null)
                return NotFound();
            article.popularity++;
            _context.SaveChanges();
            return View(article);
        }

        [HttpPost]
        public async Task<IActionResult> Detail(int id, string text)
        {
            var newComment = new Comment
            {
                text = text,
                author = _context.User.FirstOrDefault(m => m.username == HttpContext.User.Identity.Name.ToString()),
                articleId = id,
                date = DateTime.Now
            };
            _context.Comment.Add(newComment);
            await _context.SaveChangesAsync();
            return Redirect($"/Main/Detail/{id}/");
        }

        [HttpGet]
        public async Task<IActionResult> Search(string? search, string? type)
        {
            if (search != null && type != null)
            {
                if (type == "Article")
                    ViewBag.articles = await _context.Article.Include(m => m.Author).Where(m => m.title.Contains(search)).OrderByDescending(m => m.id).ToListAsync();
                else if (type == "User")
                    ViewBag.users = await _context.User.Where(m => m.username.Contains(search)).OrderBy(m => m.username).ToListAsync();
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Top()
        {
            return View(await _context.Article.Include(m => m.Author).OrderByDescending(m => m.popularity).ToListAsync());
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(string title, string descriprion, string text)
        {
            var newArticle = new Article
            {
                title = title,
                description = descriprion,
                text = text,
                Author = _context.User.First(m => m.username == HttpContext.User.Identity.Name.ToString()),
                date = DateTime.Now
            };
            _context.Article.Add(newArticle);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var article = await _context.Article.FindAsync(id);
            return View(article);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int? id, string title, string text)
        {
            if (id == null)
                return NotFound();
            Article anyart = _context.Article.Include(m => m.Author).First(m => m.id == id);
            if (anyart.Author.username == HttpContext.User.Identity.Name)
            {
                anyart.title = title;
                anyart.text = text;
                _context.Article.Update(anyart);
                await _context.SaveChangesAsync();
            }
            else
                return NotFound();
            return Redirect($"/Account/?name={HttpContext.User.Identity.Name}");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            Article deldata;
            if (id == null)
                return NotFound();
            try
            {
                deldata = _context.Article.First(m => m.id == id && m.Author.username == HttpContext.User.Identity.Name);
            }
            catch
            {
                return NotFound();
            }
            if (deldata == null)
                return NotFound();
            _context.Article.Remove(deldata);
            await _context.SaveChangesAsync();
            return Redirect($"/Account/?name={HttpContext.User.Identity.Name}");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
