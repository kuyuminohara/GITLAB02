
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using LghNetCoreLesson12_EF.Models;
using LghNetCoreLesson12_EF.LghAppDb;

public class LghProductsController : Controller
{
    private readonly LghAppDbContext _context;
    private readonly IWebHostEnvironment _environment;

    public LghProductsController(LghAppDbContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    // GET: LGHPRODUCTS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.LghProducts.ToListAsync());
    }

    // GET: LGHPRODUCTS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var lghproduct = await _context.LghProducts
            .FirstOrDefaultAsync(m => m.Id == id);
        if (lghproduct == null)
        {
            return NotFound();
        }

        return View(lghproduct);
    }

    // GET: LGHPRODUCTS/Create
    public async Task<IActionResult> Create()
    {
        await LoadLghCategoriesAsync();
        return View();
    }

    // POST: LGHPRODUCTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,LghName,LghPrice,LghSalePrice,LghStatus,LghDescription,LghCategoryId")] LghProduct lghproduct, IFormFile? lghImageFile)
    {
        ModelState.Remove(nameof(LghProduct.LghImage));
        ModelState.Remove(nameof(LghProduct.LghCategory));

        if (lghImageFile == null || lghImageFile.Length == 0)
        {
            ModelState.AddModelError("lghImageFile", "Vui lòng chọn ảnh sản phẩm.");
        }

        if (ModelState.IsValid)
        {
            lghproduct.LghImage = await SaveLghImageAsync(lghImageFile);
            if (!ModelState.IsValid)
            {
                await LoadLghCategoriesAsync(lghproduct.LghCategoryId);
                return View(lghproduct);
            }

            lghproduct.LghCreatedDate = DateTime.Now;
            _context.Add(lghproduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        await LoadLghCategoriesAsync(lghproduct.LghCategoryId);
        return View(lghproduct);
    }

    // GET: LGHPRODUCTS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var lghproduct = await _context.LghProducts.FindAsync(id);
        if (lghproduct == null)
        {
            return NotFound();
        }
        await LoadLghCategoriesAsync(lghproduct.LghCategoryId);
        return View(lghproduct);
    }

    // POST: LGHPRODUCTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,LghName,LghPrice,LghSalePrice,LghStatus,LghDescription,LghCategoryId")] LghProduct lghproduct, IFormFile? lghImageFile)
    {
        ModelState.Remove(nameof(LghProduct.LghImage));
        ModelState.Remove(nameof(LghProduct.LghCategory));

        if (id != lghproduct.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                var existingProduct = await _context.LghProducts.FindAsync(lghproduct.Id);
                if (existingProduct == null)
                {
                    return NotFound();
                }

                existingProduct.LghName = lghproduct.LghName;
                existingProduct.LghPrice = lghproduct.LghPrice;
                existingProduct.LghSalePrice = lghproduct.LghSalePrice;
                existingProduct.LghStatus = lghproduct.LghStatus;
                existingProduct.LghDescription = lghproduct.LghDescription;
                existingProduct.LghCategoryId = lghproduct.LghCategoryId;

                if (lghImageFile != null && lghImageFile.Length > 0)
                {
                    existingProduct.LghImage = await SaveLghImageAsync(lghImageFile);
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LghProductExists(lghproduct.Id))
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
        await LoadLghCategoriesAsync(lghproduct.LghCategoryId);
        return View(lghproduct);
    }

    private async Task LoadLghCategoriesAsync(int? selectedCategoryId = null)
    {
        var categories = await _context.LghCategories
            .AsNoTracking()
            .OrderBy(category => category.LghName)
            .ToListAsync();

        ViewData["LghCategoryId"] = new SelectList(categories, "Id", "LghName", selectedCategoryId);
    }

    private async Task<byte[]?> SaveLghImageAsync(IFormFile? lghImageFile)
    {
        if (lghImageFile == null || lghImageFile.Length == 0)
        {
            return null;
        }

        var extension = Path.GetExtension(lghImageFile.FileName).ToLowerInvariant();
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
        if (!allowedExtensions.Contains(extension))
        {
            ModelState.AddModelError("lghImageFile", "Chỉ chấp nhận file ảnh JPG, JPEG, PNG, GIF hoặc WEBP.");
            return null;
        }

        await using var stream = new MemoryStream();
        await lghImageFile.CopyToAsync(stream);
        return stream.ToArray();
    }

    public async Task<IActionResult> LghImage(int id)
    {
        var lghImage = await _context.LghProducts
            .Where(product => product.Id == id)
            .Select(product => product.LghImage)
            .FirstOrDefaultAsync();

        if (lghImage == null || lghImage.Length == 0)
        {
            return NotFound();
        }

        return File(lghImage, "application/octet-stream");
    }

    // GET: LGHPRODUCTS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var lghproduct = await _context.LghProducts
            .FirstOrDefaultAsync(m => m.Id == id);
        if (lghproduct == null)
        {
            return NotFound();
        }

        return View(lghproduct);
    }

    // POST: LGHPRODUCTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var lghproduct = await _context.LghProducts.FindAsync(id);
        if (lghproduct != null)
        {
            _context.LghProducts.Remove(lghproduct);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool LghProductExists(int? id)
    {
        return _context.LghProducts.Any(e => e.Id == id);
    }
}
