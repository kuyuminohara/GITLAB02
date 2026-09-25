
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LghLesson10EFCDBFirst.Models;

public class LghMembersController : Controller
{
    private readonly LghLesson10Context _context;

    public LghMembersController(LghLesson10Context context)
    {
        _context = context;
    }

    // GET: LGHMEMBERS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.LghMembers.ToListAsync());
    }

    // GET: LGHMEMBERS/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var lghmember = await _context.LghMembers
            .FirstOrDefaultAsync(m => m.Id == id);
        if (lghmember == null)
        {
            return NotFound();
        }

        return View(lghmember);
    }

    // GET: LGHMEMBERS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: LGHMEMBERS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,LghUserName,LghPassword,LghFullName,LghEmail,LghPhone,LghStatus")] LghMember lghmember)
    {
        if (ModelState.IsValid)
        {
            _context.Add(lghmember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(lghmember);
    }

    // GET: LGHMEMBERS/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var lghmember = await _context.LghMembers.FindAsync(id);
        if (lghmember == null)
        {
            return NotFound();
        }
        return View(lghmember);
    }

    // POST: LGHMEMBERS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long? id, [Bind("Id,LghUserName,LghPassword,LghFullName,LghEmail,LghPhone,LghStatus")] LghMember lghmember)
    {
        if (id != lghmember.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(lghmember);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LghMemberExists(lghmember.Id))
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
        return View(lghmember);
    }

    // GET: LGHMEMBERS/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var lghmember = await _context.LghMembers
            .FirstOrDefaultAsync(m => m.Id == id);
        if (lghmember == null)
        {
            return NotFound();
        }

        return View(lghmember);
    }

    // POST: LGHMEMBERS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long? id)
    {
        var lghmember = await _context.LghMembers.FindAsync(id);
        if (lghmember != null)
        {
            _context.LghMembers.Remove(lghmember);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool LghMemberExists(long? id)
    {
        return _context.LghMembers.Any(e => e.Id == id);
    }
}
