using System.Data.Common;
using System.Security.Principal;
using FirstRealProject.Data;
using FirstRealProject.Models;
using FirstRealProject.Repository.IRepository;
using FirstRealProject.Utility;
using FirstRealProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace FirstRealProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class CompanyController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            List<Company>objectCompanyList = _unitOfWork.Company.GetAll().ToList();
            return View(objectCompanyList);
        }

        public IActionResult Upsert(int? id)//retrieve the form
        {
            if(id == null || id == 0 )
            {
                //create
                return View(new Company());
            }
            else
            {
                //update
                Company companyObj = _unitOfWork.Company.Get(u=>u.Id == id);
                return View(companyObj);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Company CompanyObj) //submit the form
        {
            if(ModelState.IsValid)
            {
                if(CompanyObj.Id == 0)
                {
                    _unitOfWork.Company.Add(CompanyObj);
                }
                else
                {
                    _unitOfWork.Company.Update(CompanyObj);
                }
                _unitOfWork.Save();
                TempData["success"]= "Company Created Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(CompanyObj);
            }
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company>objectCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new{data = objectCompanyList});
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var companyToBeDeleted = _unitOfWork.Company.Get(u=> u.Id == id);
            if(companyToBeDeleted == null)
            {
                return Json(new {success = false, message = "Error While Deleting"});
            }
                _unitOfWork.Company.Remove(companyToBeDeleted);
                _unitOfWork.Save();

                return Json(new{success= true, message="Deleted Successfully"});
        }
        #endregion
    }
}