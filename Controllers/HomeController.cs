using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ass_2.Models;
using ass_2.Data;
using ass_2.Helpers;

namespace ass_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHelper _h;
		private readonly ass_2Context _context;
		
        public HomeController(ILogger<HomeController> logger,IHelper helper,ass_2Context context)
        {
            _logger = logger;
			_h = helper;
			_context = context;
        }

         public async Task<IActionResult> Index()
        {
            return View(await _context.Product.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }
		
		 // GET: Products/AddToBag/5
        public async Task<IActionResult> AddToBag(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
