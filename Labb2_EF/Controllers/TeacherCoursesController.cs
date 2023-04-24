using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labb2_EF.Data;
using Labb2_EF.Models.JoinModels;

namespace Labb2_EF.Controllers
{
    public class TeacherCoursesController : Controller
    {
        private readonly SchoolDbContext _context;

        public TeacherCoursesController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: TeacherCourses
        public async Task<IActionResult> Index()
        {
            var schoolDbContext = _context.TeacherCourses
                .Include(t => t.Courses)
                .Include(t => t.Teachers);
            return View(await schoolDbContext.ToListAsync());
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

        public async Task<IActionResult> GetAllTeacherStudents()
        {
            var schoolDbContext = _context.TeacherCourses
                .Include(t => t.Courses)
                .Include(t => t.Teachers);

            return View(await schoolDbContext.ToListAsync());
        }


        // GET: TeacherCourses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.TeacherCourses == null)
            {
                return NotFound();
            }

            var teacherCourse = await _context.TeacherCourses
                .Include(t => t.Courses)
                .Include(t => t.Teachers)
                .FirstOrDefaultAsync(m => m.TeacherCourseId == id);
            if (teacherCourse == null)
            {
                return NotFound();
            }

            return View(teacherCourse);
        }

        // GET: TeacherCourses/Create
        public IActionResult Create()
        {
            ViewData["FK_CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName");
            ViewData["FK_TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherFullName");
            return View();
        }

        // POST: TeacherCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherCourseId,FK_TeacherId,FK_CourseId")] TeacherCourse teacherCourse)
        {
            if (ModelState.IsValid)
            {
                teacherCourse.TeacherCourseId = Guid.NewGuid();
                _context.Add(teacherCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FK_CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", teacherCourse.FK_CourseId);
            ViewData["FK_TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherFirstName", teacherCourse.FK_TeacherId);
            return View(teacherCourse);
        }

        // GET: TeacherCourses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.TeacherCourses == null)
            {
                return NotFound();
            }

            var teacherCourse = await _context.TeacherCourses.FindAsync(id);
            if (teacherCourse == null)
            {
                return NotFound();
            }
            ViewData["FK_CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", teacherCourse.FK_CourseId);
            ViewData["FK_TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherFullName", teacherCourse.FK_TeacherId);
            return View(teacherCourse);
        }
        public async Task<IActionResult> GetAllStudentsTeachers(Guid? id)
        {
            if (id == null || _context.TeacherCourses == null)
            {
                return NotFound();
            }

            var teacherCourse = await _context.TeacherCourses.FindAsync(id);
            if (teacherCourse == null)
            {
                return NotFound();
            }
            ViewData["FK_CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", teacherCourse.FK_CourseId);
            ViewData["FK_TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherFullName", teacherCourse.FK_TeacherId);
            return View(teacherCourse);
        }

        // POST: TeacherCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TeacherCourseId,FK_TeacherId,FK_CourseId")] TeacherCourse teacherCourse)
        {
            if (id != teacherCourse.TeacherCourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherCourseExists(teacherCourse.TeacherCourseId))
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
            ViewData["FK_CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", teacherCourse.FK_CourseId);
            ViewData["FK_TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherFirstName", teacherCourse.FK_TeacherId);
            return View(teacherCourse);
        }

        // GET: TeacherCourses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.TeacherCourses == null)
            {
                return NotFound();
            }

            var teacherCourse = await _context.TeacherCourses
                .Include(t => t.Courses)
                .Include(t => t.Teachers)
                .FirstOrDefaultAsync(m => m.TeacherCourseId == id);
            if (teacherCourse == null)
            {
                return NotFound();
            }

            return View(teacherCourse);
        }

        // POST: TeacherCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.TeacherCourses == null)
            {
                return Problem("Entity set 'SchoolDbContext.TeacherCourse'  is null.");
            }
            var teacherCourse = await _context.TeacherCourses.FindAsync(id);
            if (teacherCourse != null)
            {
                _context.TeacherCourses.Remove(teacherCourse);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherCourseExists(Guid id)
        {
          return (_context.TeacherCourses?.Any(e => e.TeacherCourseId == id)).GetValueOrDefault();
        }
    }
}
