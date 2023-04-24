//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Labb2_EF.Data;
//using Labb2_EF.Models.JoinModels;

//namespace Labb2_EF.Controllers
//{
//    public class StudentCoursesController : Controller
//    {
//        private readonly SchoolDbContext _context;

//        public StudentCoursesController(SchoolDbContext context)
//        {
//            _context = context;
//        }

//        // GET: StudentCourses
//        public async Task<IActionResult> Index()
//        {
//            var schoolDbContext = _context.StudentCourse.Include(s => s.Courses).Include(s => s.Students);
//            return View(await schoolDbContext.ToListAsync());
//        }

//        // GET: StudentCourses/Details/5
//        public async Task<IActionResult> Details(Guid? id)
//        {
//            if (id == null || _context.StudentCourse == null)
//            {
//                return NotFound();
//            }

//            var studentCourse = await _context.StudentCourse
//                .Include(s => s.Courses)
//                .Include(s => s.Students)
//                .FirstOrDefaultAsync(m => m.StudentCourseId == id);
//            if (studentCourse == null)
//            {
//                return NotFound();
//            }

//            return View(studentCourse);
//        }

//        // GET: StudentCourses/Create
//        public IActionResult Create()
//        {
//            ViewData["FK_CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName");
//            ViewData["FK_StudentId"] = new SelectList(_context.Students, "StudentId", "StudentFullName");
//            return View();
//        }

//        // POST: StudentCourses/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("StudentCourseId,FK_StudentId,FK_CourseId,Grade")] StudentsTeachersCourse studentCourse)
//        {
//            if (ModelState.IsValid)
//            {
//                studentCourse.StudentCourseId = Guid.NewGuid();
//                _context.Add(studentCourse);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["FK_CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", studentCourse.FK_CourseId);
//            ViewData["FK_StudentId"] = new SelectList(_context.Students, "StudentId", "Email", studentCourse.FK_StudentId);
//            return View(studentCourse);
//        }

//        // GET: StudentCourses/Edit/5
//        public async Task<IActionResult> Edit(Guid? id)
//        {
//            if (id == null || _context.StudentCourse == null)
//            {
//                return NotFound();
//            }

//            var studentCourse = await _context.StudentCourse.FindAsync(id);
//            if (studentCourse == null)
//            {
//                return NotFound();
//            }
//            ViewData["FK_CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", studentCourse.FK_CourseId);
//            ViewData["FK_StudentId"] = new SelectList(_context.Students, "StudentId", "Email", studentCourse.FK_StudentId);
//            return View(studentCourse);
//        }

//        // POST: StudentCourses/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(Guid id, [Bind("StudentCourseId,FK_StudentId,FK_CourseId,Grade")] StudentsTeachersCourse studentCourse)
//        {
//            if (id != studentCourse.StudentCourseId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(studentCourse);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!StudentCourseExists(studentCourse.StudentCourseId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["FK_CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", studentCourse.FK_CourseId);
//            ViewData["FK_StudentId"] = new SelectList(_context.Students, "StudentId", "Email", studentCourse.FK_StudentId);
//            return View(studentCourse);
//        }

//        // GET: StudentCourses/Delete/5
//        public async Task<IActionResult> Delete(Guid? id)
//        {
//            if (id == null || _context.StudentCourse == null)
//            {
//                return NotFound();
//            }

//            var studentCourse = await _context.StudentCourse
//                .Include(s => s.Courses)
//                .Include(s => s.Students)
//                .FirstOrDefaultAsync(m => m.StudentCourseId == id);
//            if (studentCourse == null)
//            {
//                return NotFound();
//            }

//            return View(studentCourse);
//        }

//        // POST: StudentCourses/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(Guid id)
//        {
//            if (_context.StudentCourse == null)
//            {
//                return Problem("Entity set 'SchoolDbContext.StudentCourse'  is null.");
//            }
//            var studentCourse = await _context.StudentCourse.FindAsync(id);
//            if (studentCourse != null)
//            {
//                _context.StudentCourse.Remove(studentCourse);
//            }
            
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool StudentCourseExists(Guid id)
//        {
//          return (_context.StudentCourse?.Any(e => e.StudentCourseId == id)).GetValueOrDefault();
//        }
//    }
//}
