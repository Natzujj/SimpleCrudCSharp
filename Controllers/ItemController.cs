using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MeuCrudCSharp.Data;
using MeuCrudCSharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MeuCrudCSharp.Controllers
{
    // [Route("[controller]")]
    public class ItemController : Controller
    {
        // private readonly ILogger<ItemController> _logger;
        // public ItemController(ILogger<ItemController> logger)
        // {
        //     _logger = logger;
        // }

        // public IActionResult Index()
        // {
        //     return View();
        // }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            var _Item = await _context.Items.ToListAsync();
            if (_Item.Count < 1)
                await CreateTestData();

            return _context.Items != null ?
                        View(await _context.Items.ToListAsync()) :
                        Problem("Entidade é NULL");
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Preco")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Preco")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(item.Id))
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
            return View(item);
        }



        [HttpDelete]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                var _Categories = await _context.Items.FindAsync(id);

                if (_Categories != null)
                {
                    _context.Items.Remove(_Categories);
                }
                await _context.SaveChangesAsync();
                return new JsonResult(_Categories);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool CategoryExists(int id)
        {
            return (_context.Items?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private async Task CreateTestData()
        {
            foreach (var item in GetCategoryList())
            {
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
            }
        }

        private IEnumerable<Item> GetCategoryList()
        {
            return new List<Item>
            {
                new Item { Nome = "Item 01", Preco = 12 },
                new Item { Nome = "Item 02", Preco = 12 },
                new Item { Nome = "Item 03", Preco = 12 },
                new Item { Nome = "Item 04", Preco = 12 },
                new Item { Nome = "Item 05", Preco = 12 },

                new Item { Nome = "Item 06", Preco = 12 },
                new Item { Nome = "Item 07", Preco = 12 },
                new Item { Nome = "Item 08", Preco = 12 },
                new Item { Nome = "Item 09", Preco = 12 },
                new Item { Nome = "Item 10", Preco = 12 },
            };
        }

    }
}