
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeGiaHung2410900041_exam.Models;

public class LghStudentsController : Controller
{
    private readonly LghStudentContext _context;

    public LghStudentsController(LghStudentContext context)
    {
        _context = context;
    }

    // GET: LGHSTUDENTS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.LghStudents.ToListAsync());
    }

    // GET: LGHSTUDENTS/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var lghstudent = await _context.LghStudents
            .FirstOrDefaultAsync(m => m.Id == id);
        if (lghstudent == null)
        {
            return NotFound();
        }

        return View(lghstudent);
    }

    // GET: LGHSTUDENTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: LGHSTUDENTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,LghName,LghGender,LghBirthDay,LghEmail,LghPhone,LghActive")] LghStudent lghstudent)
    {
        if (ModelState.IsValid)
        {
            _context.Add(lghstudent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(lghstudent);
    }

    // GET: LGHSTUDENTS/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var lghstudent = await _context.LghStudents.FindAsync(id);
        if (lghstudent == null)
        {
            return NotFound();
        }
        return View(lghstudent);
    }

    // POST: LGHSTUDENTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long? id, [Bind("Id,LghName,LghGender,LghBirthDay,LghEmail,LghPhone,LghActive")] LghStudent lghstudent)
    {
        if (id != lghstudent.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(lghstudent);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LghStudentExists(lghstudent.Id))
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
        return View(lghstudent);
    }

    // GET: LGHSTUDENTS/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var lghstudent = await _context.LghStudents
            .FirstOrDefaultAsync(m => m.Id == id);
        if (lghstudent == null)
        {
            return NotFound();
        }

        return View(lghstudent);
    }

    // POST: LGHSTUDENTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long? id)
    {
        var lghstudent = await _context.LghStudents.FindAsync(id);
        if (lghstudent != null)
        {
            _context.LghStudents.Remove(lghstudent);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool LghStudentExists(long? id)
    {
        return _context.LghStudents.Any(e => e.Id == id);
    }
}
