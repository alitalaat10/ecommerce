using firstCoreapp.Data;
using firstCoreapp.Migrations;
using firstCoreapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace firstCoreapp.Controllers
{
    [Authorize]
    public class ItemsController : Controller
    {
        public ItemsController(ApplicationDbContext db,IHostingEnvironment host)
        {
            _db = db;
            _host = host;
        }
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _host;
       
        
        public IActionResult Index()
        {
           var lst = _db.items.Include(c=>c.cat).ToList();
           
            return View(lst);
        }
       
        public IActionResult delete(int id)
        {  
            if(id == 0)
            {
                return NotFound();
            }
          
            var i = _db.items.Where(x => x.Id == id).FirstOrDefault();
            //var i = _db.items.FirstOrDefault(x => x.Id == id);

            if (i == null)
            {
                return BadRequest();
            }

            _db.items.Remove(i);
            _db.SaveChanges();
            TempData["success"] = "transaction was success";
            return  RedirectToAction("Index");
        }

        public IActionResult insertorEdit(int? id) 
        {   if(id == 0|| id==null)
            {
                selectitems();
                return View();
            }

            var i = _db.items.Find(id);
            if(i == null)
            {
                return BadRequest();
            }
            else
            {

                selectitems(i.categoryID);
                return View(i);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult insertorEdit(item t)
        { 
            if (t.Name.Contains("0") || t.Name.Contains("1") || t.Name.Contains("2") || t.Name.Contains("3") || t.Name.Contains("4") || t.Name.Contains("5") || t.Name.Contains("6") || t.Name.Contains("7") || t.Name.Contains("8") || t.Name.Contains("9"))
            {
                ModelState.AddModelError("Name", "Name can't contains number");
            }

            if (ModelState.IsValid)
            {
                string fileName = string.Empty;
                if (t.clientFile != null)
                {
                    string myUpload = Path.Combine(_host.WebRootPath, "images");
                    fileName = t.clientFile.FileName;
                    string fullpath = Path.Combine(myUpload, fileName);
                    t.clientFile.CopyTo(new FileStream(fullpath, FileMode.Create));
                    t.imagepath = fileName;
                }

                if (t.Id  == 0) {
                    

                    _db.items.Add(t);
                }
                else
                {
                    _db.items.Update(t);
                }
               
                _db.SaveChanges();

                TempData["success"] = "transaction was success";
                return RedirectToAction("Index");

            }
            else
            {
                if (t.Id == 0)
                {
                    selectitems();
                }
                else
                {
                    selectitems(t.categoryID);
                }
                
                return View(t);
            }
        }

        public void selectitems(int? selectId=1)
        {
            var lst = _db.categories.ToList();

            SelectList slst = new SelectList(lst, "Id", "Name", selectId);

            ViewBag.selectlist = slst;
        }
    }

}
