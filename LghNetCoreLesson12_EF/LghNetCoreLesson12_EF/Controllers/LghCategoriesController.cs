
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LghNetCoreLesson12_EF.Models;
using LghNetCoreLesson12_EF.LghAppDb;

public class LghCategoriesController : Controller
{
    private readonly LghAppDbContext _context;

    public LghCategoriesController(LghAppDbContext context)
    {
        _context = context;
    }

    // GET: LGHCATEGORYS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.LghCategories.ToListAsync());
    }

    // GET: LGHCATEGORYS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var lghcategory = await _context.LghCategories
            .FirstOrDefaultAsync(m => m.Id == id);
        if (lghcategory == null)
        {
            return NotFound();
        }

        return View(lghcategory);
    }

    // GET: LGHCATEGORYS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: LGHCATEGORYS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,LghName,LghStatus")] LghCategory lghcategory)
    {
        if (ModelState.IsValid)
        {
            lghcategory.LghCreatedDate = DateTime.Now;
            _context.Add(lghcategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(lghcategory);
    }

    // GET: LGHCATEGORYS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var lghcategory = await _context.LghCategories.FindAsync(id);
        if (lghcategory == null)
        {
            return NotFound();
        }
        return View(lghcategory);
    }

    // POST: LGHCATEGORYS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,LghName,LghStatus")] LghCategory lghcategory)
    {
        if (id != lghcategory.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                var existingCategory = await _context.LghCategories.FindAsync(lghcategory.Id);
                if (existingCategory == null)
                {
                    return NotFound();
                }

                existingCategory.LghName = lghcategory.LghName;
                existingCategory.LghStatus = lghcategory.LghStatus;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LghCategoryExists(lghcategory.Id))
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
        return View(lghcategory);
    }

    // GET: LGHCATEGORYS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var lghcategory = await _context.LghCategories
            .FirstOrDefaultAsync(m => m.Id == id);
        if (lghcategory == null)
        {
            return NotFound();
        }

        return View(lghcategory);
    }

    // POST: LGHCATEGORYS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var lghcategory = await _context.LghCategories.FindAsync(id);
        if (lghcategory != null)
        {
            _context.LghCategories.Remove(lghcategory);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool LghCategoryExists(int? id)
    {
        return _context.LghCategories.Any(e => e.Id == id);
    }
}
