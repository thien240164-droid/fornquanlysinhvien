using Microsoft.AspNetCore.Mvc;
using fornquanlysinhvien.Models;
using System.Collections.Generic;
using System.Linq;

namespace fornquanlysinhvien.Controllers;

public class StudentController : Controller
{
    // In-memory storage (replace with database in production)
    private static List<Student> _students = new();

    public IActionResult Index()
    {
        return View(_students.ToList());
    }

    public IActionResult Details(Guid id)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Student student)
    {
        if (ModelState.IsValid)
        {
            student.Id = Guid.NewGuid();
            student.CreatedAt = DateTime.UtcNow;
            student.UpdatedAt = DateTime.UtcNow;
            _students.Add(student);
            return RedirectToAction(nameof(Index));
        }
        return View(student);
    }

    public IActionResult Edit(Guid id)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Guid id, Student student)
    {
        if (id != student.Id)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            var existingStudent = _students.FirstOrDefault(s => s.Id == id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.Username = student.Username;
            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.Email = student.Email;
            existingStudent.PhoneNumber = student.PhoneNumber;
            existingStudent.StudentId = student.StudentId;
            existingStudent.ClassName = student.ClassName;
            existingStudent.Major = student.Major;
            existingStudent.UpdatedAt = DateTime.UtcNow;

            return RedirectToAction(nameof(Index));
        }
        return View(student);
    }

    public IActionResult Delete(Guid id)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(Guid id)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);
        if (student != null)
        {
            _students.Remove(student);
        }
        return RedirectToAction(nameof(Index));
    }
}
