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
using Labb2_EF.Models.ViewModels;

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
            //var studentsTeachers = _context.Enrollments
            //    .Include(t => _context.Teachers)
            //    .Include(t => t.Students);

            //return View(await studentsTeachers.ToListAsync());

            var teachers = await _context.Teachers.ToListAsync();
            var students = await _context.Students.ToListAsync();
            var enrollment = await _context.Enrollments.ToListAsync();

            var result = from t in teachers
                         join e in enrollment on t.TeacherId equals e.FK_TeacherId
                         join s in students on e.FK_StudentId equals s.StudentId
                         select new StudentsTeachers
                         {
                             StudentId = s.StudentId,
                             StudentFullName = s.StudentFullName,
                             TeacherId = t.TeacherId,
                             TeacherFullname = t.TeacherFullName,
                         };

            return View(result);
        }
    }
}
