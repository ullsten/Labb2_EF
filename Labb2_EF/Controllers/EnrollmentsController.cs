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
    public class EnrollmentsController : Controller
    {
        private readonly SchoolDbContext _context;

        public EnrollmentsController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
        {
            var schoolDbContext = _context.Enrollments
                .Include(e => e.Classes)
                .Include(e => e.Courses)
                .Include(e => e.Students)
                .Include(e => e.Teachers);
            return View(await schoolDbContext.ToListAsync());
        }

        // GET: Enrollments/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Enrollments == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments
                .Include(e => e.Classes)
                .Include(e => e.Courses)
                .Include(e => e.Students)
                .Include(e => e.Teachers)
                .FirstOrDefaultAsync(m => m.EnrollmentId == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // GET: Enrollments/Create
        public IActionResult Create()
        {
            ViewData["FK_ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName");
            ViewData["FK_CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName");
            ViewData["FK_StudentId"] = new SelectList(_context.Students, "StudentId", "StudentFullName");
            ViewData["FK_TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherFullName");
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollmentId,FK_StudentId,FK_TeacherId,FK_CourseId,FK_ClassId")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                enrollment.EnrollmentId = Guid.NewGuid();
                _context.Add(enrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FK_ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName", enrollment.FK_ClassId);
            ViewData["FK_CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", enrollment.FK_CourseId);
            ViewData["FK_StudentId"] = new SelectList(_context.Students, "StudentId", "Email", enrollment.FK_StudentId);
            ViewData["FK_TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherFirstName", enrollment.FK_TeacherId);
            return View(enrollment);
        }

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Enrollments == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            ViewData["FK_ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName", enrollment.FK_ClassId);
            ViewData["FK_CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", enrollment.FK_CourseId);
            ViewData["FK_StudentId"] = new SelectList(_context.Students, "StudentId", "Email", enrollment.FK_StudentId);
            ViewData["FK_TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherFirstName", enrollment.FK_TeacherId);
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("EnrollmentId,FK_StudentId,FK_TeacherId,FK_CourseId,FK_ClassId")] Enrollment enrollment)
        {
            if (id != enrollment.EnrollmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExists(enrollment.EnrollmentId))
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
            ViewData["FK_ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName", enrollment.FK_ClassId);
            ViewData["FK_CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", enrollment.FK_CourseId);
            ViewData["FK_StudentId"] = new SelectList(_context.Students, "StudentId", "Email", enrollment.FK_StudentId);
            ViewData["FK_TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherFirstName", enrollment.FK_TeacherId);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Enrollments == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments
                .Include(e => e.Classes)
                .Include(e => e.Courses)
                .Include(e => e.Students)
                .Include(e => e.Teachers)
                .FirstOrDefaultAsync(m => m.EnrollmentId == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Enrollments == null)
            {
                return Problem("Entity set 'SchoolDbContext.Enrollments'  is null.");
            }
            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(Guid id)
        {
          return (_context.Enrollments?.Any(e => e.EnrollmentId == id)).GetValueOrDefault();
        }
    }
}
