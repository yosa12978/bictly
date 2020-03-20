using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bictly.Data;
using bictly.Models;
using Microsoft.AspNetCore.Authorization;

namespace bictly.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly BictlyContext _context;

        public AdminController(BictlyContext context)
        {
            _context = context;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            if (_context.User.Any(m => m.username == HttpContext.User.Identity.Name && m.IsAdmin == false))
                return NotFound();

            return View(await _context.Article.ToListAsync());
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (_context.User.Any(m => m.username == HttpContext.User.Identity.Name && m.IsAdmin == false))
                return NotFound();

            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Article
                .FirstOrDefaultAsync(m => m.id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            if (_context.User.Any(m => m.username == HttpContext.User.Identity.Name && m.IsAdmin == false))
                return NotFound();

            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,title,description,text,popularity,date")] Article article)
        {
            if (_context.User.Any(m => m.username == HttpContext.User.Identity.Name && m.IsAdmin == false))
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (_context.User.Any(m => m.username == HttpContext.User.Identity.Name && m.IsAdmin == false))
                return NotFound();

            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Article.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,title,description,text,popularity,date")] Article article)
        {
            if (_context.User.Any(m => m.username == HttpContext.User.Identity.Name && m.IsAdmin == false))
                return NotFound();

            if (id != article.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (_context.User.Any(m => m.username == HttpContext.User.Identity.Name && m.IsAdmin == false))
                return NotFound();

            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Article
                .FirstOrDefaultAsync(m => m.id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.User.Any(m => m.username == HttpContext.User.Identity.Name && m.IsAdmin == false))
                return NotFound();

            var article = await _context.Article.FindAsync(id);
            _context.Article.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _context.Article.Any(e => e.id == id);
        }
    }
}
