using System.Data.Common;
using FirstRealProject.Data;
using FirstRealProject.Models;
using FirstRealProject.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace FirstRealProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            List<Category>objectCategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(objectCategoryList);
        }

        public IActionResult Create()//retrieve the form
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj) //submit the form
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder Cannot Exactly Match the Name");
            }
    
            if(ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"]= "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _unitOfWork.Category.Get(u=>u.Id == id);//find function only works on primary key     firstordefault  where
            if(categoryFromDb == null) return NotFound();
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"]= "Category Updated Successfully";

                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _unitOfWork.Category.Get(u=>u.Id == id);//find function only works on primary key     firstordefault  where
            if(categoryFromDb == null) return NotFound();
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _unitOfWork.Category.Get(u=>u.Id == id);;
            if(obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"]= "Category Deleted Successfully";
            return RedirectToAction("Index");
        }

    }
}