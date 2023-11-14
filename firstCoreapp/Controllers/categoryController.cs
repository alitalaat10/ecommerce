using firstCoreapp.Models;
using firstCoreapp.Repository.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace firstCoreapp.Controllers
{
    [Authorize]
    public class categoryController : Controller
    {
        public categoryController(IUnitOfWork _myUnit)
        {
            //_repository = repository;s
            myUnit = _myUnit;
           
        }
        
        //private IRepository<category> _repository;
        private readonly IUnitOfWork myUnit;
     

        public async Task<IActionResult> Index()
        {
            return View(await myUnit.categories.FindAllAsync("items"));
        }


        public IActionResult delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var i = myUnit.categories.Find(id);
            if (i == null)
            {
                return BadRequest();
            }
            
            myUnit.categories.DeleteOne(i);
            
          
            TempData["success"] = "transaction was success";
            return RedirectToAction("Index");

        }

        public IActionResult insertorEdit(int? id)
        { 

            
           
            if (id == 0 || id == null)
            {
                category c = new category();
                return View(c);
            }

            var i = myUnit.categories.selectone(X => X.Id == id);
            if (i == null)
            {
                return BadRequest();
            }
            else
            {
               
                return View(i);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult insertorEdit(category t)
        {
            if (t.Name.Contains("0") || t.Name.Contains("1") || t.Name.Contains("2") || t.Name.Contains("3") || t.Name.Contains("4") || t.Name.Contains("5") || t.Name.Contains("6") || t.Name.Contains("7") || t.Name.Contains("8") || t.Name.Contains("9"))
            {
                ModelState.AddModelError("Name", "Name can't contains number");
            }

            if (ModelState.IsValid)
            {
              
                if (t.clientFile != null)
                {
                    MemoryStream stream= new MemoryStream();
                    t.clientFile.CopyTo(stream);
                    t.dbimage = stream.ToArray();
                }

                    if (t.Id == 0)
                {
                    myUnit.categories.Addone(t);
                }
                else
                {
                    myUnit.categories.UpdateOne(t);
                }

              

                TempData["success"] = "transaction was success";
                return RedirectToAction("Index");

            }
            else
            {
                return View(t);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
           /* myUnit.Dispose();*/       
        }
    }
}
