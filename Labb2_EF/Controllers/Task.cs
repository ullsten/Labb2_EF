using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labb2_EF.Data;
using Labb2_EF.Models;
using Labb2_EF.Models.JoinModels;

namespace Labb2_EF.Controllers
{
    public class Task : Controller
    {
        private readonly SchoolDbContext _context;
        public Task(SchoolDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        //Search for course and get teacher
        public async Task<IActionResult> GetTeacherCourse(string searchCourse)
        {
            ViewBag.FK_CourseId = new SelectList(_context.Courses, "CourseName", "CourseName");

            var schoolDbContext = _context.TeacherCourses
                .Include(t => t.Courses)
                .Include(t => t.Teachers)
                .Where(t => t.Courses.CourseName == searchCourse);

            return View(await schoolDbContext.ToListAsync());
        }

        //get all students with teachers
        public async Task<IActionResult> GetAllStudentsTeachers()
        {
            var studentsTeachers = _context.Enrollments
                .Include(st => st.Students)
                .Include(st => st.Teachers);

            return View(await studentsTeachers.ToListAsync());
        }
    }
}
