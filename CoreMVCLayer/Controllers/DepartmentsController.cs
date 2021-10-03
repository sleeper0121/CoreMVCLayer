using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.EF;
using Service.EF;
using Omu.ValueInjecter;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreMVCLayer.Controllers
{
    public class DepartmentsController : Controller
    {
        IDepartmentService deptService;

        public DepartmentsController(IDepartmentService _deptService)
        {
            deptService = _deptService;
        }

        // GET: DepartmentsController
        public ActionResult Index()
        {
            var data = deptService.GetAll();
            return View(data);
        }

        // GET: DepartmentsController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var data = deptService.FindById(id.Value);

            if (data == null)
                return NotFound();

            return View(data);
        }

        // GET: DepartmentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                deptService.Create(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: DepartmentsController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return NotFound();
            var data = deptService.FindById(id.Value);
            return View(data);
        }

        // POST: DepartmentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DepartmentEditVM department)
        {
            if (ModelState.IsValid)
            {
                var data = deptService.FindById(id);
                data.InjectFrom(department);
                deptService.Update(data);
                return RedirectToAction(nameof(Index));
            }
            //To do
            //ViewData["InstructorId"] = new SelectList(deptService.get, "Id", "LastName");
            return View(deptService.FindById(id));
        }

        // GET: DepartmentsController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            var data = deptService.FindById(id.Value);
            return View(data);
        }

        // POST: DepartmentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            deptService.Delete(id.Value);
            return RedirectToAction(nameof(Index));
        }
    }
}
