
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRegistrationWebApp.Models;
using StudentRegistrationWebApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
[Authorize]
public class StudentsController : Controller
{
    private readonly StudentCourseDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    public StudentsController(
    StudentCourseDbContext context,
    UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // GET: STUDENTS
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Students
    .Include(s => s.Course)
    .ToListAsync());
    }

    // GET: STUDENTS/Details/5
    public async Task<IActionResult> Details(int? studentid)
    {
        if (User.IsInRole("Administrator"))
        {
            if (studentid == null)
                return NotFound();

            var adminStudent =
                await _context.Students.FindAsync(studentid);

            if (adminStudent == null)
                return NotFound();

            return View(adminStudent);
        }

        string? userId = _userManager.GetUserId(User);

        var student =
            await _context.Students
                .FirstOrDefaultAsync(x => x.ApplicationUserId == userId);

        if (student == null)
            return NotFound();

        return View(student);
    }

    // GET: STUDENTS/Create
    public IActionResult Create()
    {
        if (User.IsInRole("Student"))
        {
            string? userId = _userManager.GetUserId(User);

            bool alreadyExists =
                _context.Students.Any(x => x.ApplicationUserId == userId);

            if (alreadyExists)
            {
                return RedirectToAction(nameof(Details));
            }
        }
        ViewData["CourseId"] =
    new SelectList(_context.Courses,
                   "CourseId",
                   "CourseName");
        return View();
    }
    // POST: STUDENTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create(Student student)
{
    if (ModelState.IsValid)
    {
            if (User.IsInRole("Student"))
            {
                student.ApplicationUserId = _userManager.GetUserId(User);
            }

            _context.Add(student);
        await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details));
        }
        ViewData["CourseId"] =
        new SelectList(_context.Courses,
                       "CourseId",
                       "CourseName");

        return View(student);
}
    // GET: STUDENTS/Edit/5
    // GET: STUDENTS/Edit/5
    public async Task<IActionResult> Edit(int? studentid)
    {
        if (User.IsInRole("Administrator"))
        {
            if (studentid == null)
                return NotFound();

            var adminStudent = await _context.Students.FindAsync(studentid);

            if (adminStudent == null)
                return NotFound();

            ViewData["CourseId"] = new SelectList(
                _context.Courses,
                "CourseId",
                "CourseName",
                adminStudent.CourseId);

            return View(adminStudent);
        }

        string? userId = _userManager.GetUserId(User);

        var student = await _context.Students
    .FirstOrDefaultAsync(s => s.ApplicationUserId == userId);

        if (student == null)
            return NotFound();

        ViewData["CourseId"] = new SelectList(
            _context.Courses,
            "CourseId",
            "CourseName",
            student.CourseId);

        return View(student);
    }

    // POST: STUDENTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    // POST: STUDENTS/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? studentid,
        [Bind("StudentId,FullName,City,CourseId,ApplicationUserId")]
    Student student)
    {
        if (studentid != student.StudentId)
            return NotFound();

        if (!User.IsInRole("Administrator"))
        {
            string? userId = _userManager.GetUserId(User);

            if (student.ApplicationUserId != userId)
            {
                return Forbid();
            }
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(student);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(student.StudentId))
                    return NotFound();

                throw;
            }

            if (User.IsInRole("Administrator"))
                return RedirectToAction(nameof(Index));

            return RedirectToAction(nameof(Details));
        }

        ViewData["CourseId"] = new SelectList(
    _context.Courses,
    "CourseId",
    "CourseName",
    student.CourseId);

        return View(student);
    }
    // GET: STUDENTS/Delete/5
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Delete(int? studentid)
    {
        if (studentid == null)
        {
            return NotFound();
        }

        var student = await _context.Students
            .FirstOrDefaultAsync(m => m.StudentId == studentid);
        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    // POST: STUDENTS/Delete/5
    [Authorize(Roles = "Administrator")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? studentid)
    {
        var student = await _context.Students.FindAsync(studentid);
        if (student != null)
        {
            _context.Students.Remove(student);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool StudentExists(int? studentid)
    {
        return _context.Students.Any(e => e.StudentId == studentid);
    }
}
