using Microsoft.AspNetCore.Mvc;
using MovieEFLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieEFLab.Controllers
{
    public class MovieLabController : Controller
    {
        private readonly MovieLabContext _context;
        //using Day14._2_EFCore_DatabaseFirst.Models;

        public MovieLabController(MovieLabContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
