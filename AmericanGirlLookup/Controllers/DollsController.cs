using AmericanGirlLookup.Data;
using AmericanGirlLookup.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using AmericanGirlLookup.Utilities;
using Microsoft.Extensions.Options;

namespace AmericanGirlLookup.Controllers
{
    public class DollsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly S3Utility _s3Utility;
        private readonly S3Settings _s3Settings;

        public DollsController(ApplicationDbContext context, S3Utility s3Utility, IOptions<S3Settings> s3Settings)
        {
            _context = context;
            _s3Utility = s3Utility;
            _s3Settings = s3Settings.Value;
        }

        // GET: Dolls
        public async Task<IActionResult> Index()
        {
            return View(await _context.Doll.ToListAsync());
        }

        // GET: Dolls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doll = await _context.Doll
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doll == null)
            {
                return NotFound();
            }

            return View(doll);
        }

        // GET: Dolls/Create
        [Authorize(Roles = "Administrator,Doll Curator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dolls/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Doll Curator")]
        public async Task<IActionResult> Create([Bind("Id,DollName,ReleaseDate,RetirementDate,CharacterType,Collection,OriginalPrice,CurrentValue,OwningCompany,DollImage")] Doll doll)
        {
            if (ModelState.IsValid)
            {
                if (doll.DollImage != null && doll.DollImage.Length > 0)
                {
                    var imageGuid = Guid.NewGuid();
                    var objectKey = $"doll_images/{imageGuid}-{doll.Id}-{doll.DollName}";

                    try
                    {
                        var imageUrl = await _s3Utility.UploadImageAsync(
                            bucketName: _s3Settings.BucketName,
                            objectKey: objectKey,
                            fileStream: doll.DollImage.OpenReadStream(),
                            contentType: doll.DollImage.ContentType
                        );

                        doll.ImageUrl = "https://" + _s3Settings.CloudFrontUrl + objectKey;
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", $"Image upload failed: {e.Message}");

                        return View(doll);
                    }
                }

                _context.Add(doll);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doll);
        }

        // GET: Dolls/Edit/5
        [Authorize(Roles = "Administrator,Doll Curator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doll = await _context.Doll.FindAsync(id);
            if (doll == null)
            {
                return NotFound();
            }
            return View(doll);
        }

        // POST: Dolls/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Doll Curator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DollName,ReleaseDate,RetirementDate,CharacterType,Collection,OriginalPrice,CurrentValue,OwningCompany,ImagePath")] Doll doll)
        {
            if (id != doll.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doll);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DollExists(doll.Id))
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
            return View(doll);
        }

        // GET: Dolls/Delete/5
        [Authorize(Roles = "Administrator,Doll Curator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doll = await _context.Doll
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doll == null)
            {
                return NotFound();
            }

            return View(doll);
        }

        // POST: Dolls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Doll Curator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doll = await _context.Doll.FindAsync(id);
            if (doll != null)
            {
                _context.Doll.Remove(doll);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DollExists(int id)
        {
            return _context.Doll.Any(e => e.Id == id);
        }
    }
}
