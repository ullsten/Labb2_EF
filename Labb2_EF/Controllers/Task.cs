﻿using System;
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

            var teacherCourse = _context.TeacherCourses
                .Include(t => t.Courses)
                .Include(t => t.Teachers)
                .Where(t => t.Courses.CourseName == searchCourse);

            return View(await teacherCourse.ToListAsync());
        }

        //get all students with teachers
        public async Task<IActionResult> GetAllStudentsTeachers()
        {
            var studentsTeachers = _context.Enrollments
                .Include(e => e.Students)
                .Include(e => e.Teachers)
                .Include(e => e.Courses);

            return View(await studentsTeachers.ToListAsync());
        }

        //get all students in selected course with teacher and course
        public async Task<IActionResult> GetStudentTeachersCourse(string selectedCourse)
        {
            var courses = await _context.Courses.ToListAsync();
            ViewBag.FK_CourseId = new SelectList(courses, "CourseName", "CourseName", selectedCourse);

            var studentsTeachers = _context.Enrollments
                .Include(e => e.Students)
                .Include(e => e.Teachers)
                .Include(e => e.Courses)
                .Where(e => e.Courses.CourseName == selectedCourse);

            return View(await studentsTeachers.ToListAsync());
        }




        //edit course name to something else
        //Update students teacher in course
    }
}
