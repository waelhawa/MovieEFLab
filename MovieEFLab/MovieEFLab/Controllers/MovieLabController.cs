using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var movie = _context.Movies.ToList();
            return View(movie);
        }

        public IActionResult DeleteMovie(int id)
        {
            var foundMovie = _context.Movies.Find(id);

            if (foundMovie != null)
            {
                _context.Movies.Remove(foundMovie);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");

        }

        public IActionResult MovieForm(int id)
        {
            if (id == 0)
            {
                return View(new Movie());
            }
            else
            {
                //TODO - add functionality for editing a student
                Movie foundMovie = _context.Movies.Find(id);
                return View(foundMovie);
            }
        }

        public IActionResult SaveStudent(Movie newMovie)
        {
            if (ModelState.IsValid)
            {
                if (newMovie.Id == 0)
                {
                    _context.Movies.Add(newMovie);
                    _context.SaveChanges();
                }
                else
                {
                    Movie dbMovie = _context.Movies.Find(newMovie.Id);
                    dbMovie.Title = newMovie.Title;
                    //dbStudent.LastName = newStudent.LastName;
                    //dbStudent.Dob = newStudent.Dob;
                    //dbStudent.Gpa = newStudent.Gpa;

                    _context.Entry(dbMovie).State = EntityState.Modified;
                    _context.Update(dbMovie);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
