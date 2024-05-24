using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MvcMovie.Data;
using MvcMovie.Models;
using X.PagedList;

using Microsoft.AspNetCore.Routing.Constraints;
using NetMVC.Models.Process;
using OfficeOpenXml;





namespace MvcMovie.Controllers
{
    public class PersonController : Controller
{
    private readonly ApplicationDbContext _context;
    private ExcelProcess _excelProcess = new ExcelProcess();
    public PersonController(ApplicationDbContext context)
    {
        _context = context;

    }
        public async Task<IActionResult> Index()
    {
        var model = await _context.Person.ToListAsync();
        return View(model);

    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(string SearchString)
    {
        var model = await _context.Person.Where(e => e.FullName.Contains(SearchString)).ToListAsync();
        return View(model);

    }
    
    public IActionResult Create()
    {
        return View();

    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("PersonId,FullName,Address")] Person person)
    {
        if (ModelState.IsValid)
        {
            _context.Add(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        return View(person);

    }
    public async Task<IActionResult>Edit(string id)
    {
        if (id == null || _context.Person == null)
        {
            return NotFound();
        }
        var person = await _context.Person.FindAsync(id);
        if (person == null)
        {
            return NotFound();

        }
        return View(person);

    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    
    public async Task<IActionResult> Edit(string id, [Bind("PersonId,FullName,Address")] Person person)
    {
        if (id !=person.PersonId)
        {
            return NotFound();

        }
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(person);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(person.PersonId))
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
        return View(person);

    }

    public async Task<IActionResult> Upload()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
     
     public async Task<IActionResult> Upload(IFormFile file)
     {
        if (file!=null)
        {
            string fileExtension = Path.GetExtension(file.FileName);
            if (fileExtension !=".xls" && fileExtension != ".xlsx")
            {
                ModelState.AddModelError("", "Please choose excel file to upload!");

            }
            else
            {
                
                var fileName = file.FileName;
                var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName);
                var fileLocation = new FileInfo(filePath).ToString();
                using(var stream = new FileStream(filePath, FileMode.Create))
                {
                   
                    await file.CopyToAsync(stream);
                    
                    var dt = _excelProcess.ExcelToDataTable(fileLocation);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var ps = new Person();
                        ps.PersonId = dt.Rows[i] [0].ToString();
                        ps.FullName = dt.Rows[i] [1].ToString();
                        ps.Address = dt.Rows[i] [2].ToString();
                        _context.Add(ps);
                        
                    }
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
        }
        return View();

     }
      public async Task<IActionResult> Delete(string id)
 { 
    if (id == null || _context.Person == null)
    {
        return NotFound();

    }
    var person = await _context.Person
    .FirstOrDefaultAsync(m => m.PersonId == id);
    if (person == null)
    {
        return NotFound();

    }
    return View(person);

 }

 [HttpPost, ActionName("Delete")]
 [ValidateAntiForgeryToken]
 
  public async Task<IActionResult> DeleteConfirmed(string id)
  {
    if (_context.Person == null)
    {
        return Problem("Entity set 'ApplicationDbContext.Person' is null.");

    }
    var person = await _context.Person.FindAsync(id);
    if (person != null)
    {
        _context.Person.Remove(person);

    }
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));

  }
  private bool PersonExists(string id)
  {
    return (_context.Person?.Any(e => e.PersonId == id)).GetValueOrDefault();

  }

    

    



public IActionResult Download()
     {
        var fileName = "YourFileName" + ".xlsx";
        using(ExcelPackage excelPackage = new ExcelPackage())
        {
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");
            worksheet.Cells["A1"].Value = "PersonID";
            worksheet.Cells["B1"].Value = "FullName";
            worksheet.Cells["C1"].Value = "Address";

            var personList = _context.Person.ToList();
            worksheet.Cells["A2"].LoadFromCollection(personList);
            var stream = new MemoryStream(excelPackage.GetAsByteArray());
            return File(stream,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",fileName);

        }
        }
        public async Task<IActionResult> Index(int? Page)
        {
            var model = _context.Person.ToList().ToPagedList(Page ?? 1, 5);
            return View(model);
        }
        }
        }
     
