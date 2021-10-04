using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.EF;
using Omu.ValueInjecter;
using Service.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCLayer.Controllers
{
    public class CourseController : Controller
    {
        ICourseService courseSevc;
        IDepartmentService departmentSevc;
        public CourseController(ICourseService _courseSevc, IDepartmentService _departmentSevc)
        {
            courseSevc = _courseSevc;
            departmentSevc = _departmentSevc;
        }
        public ActionResult CourseBatchEdit(bool IsEditMode = false)
        {
            var data = courseSevc.GetAll().ToList();
            ViewBag.IsEditMode = IsEditMode;
            ViewBag.DepartmentList = departmentSevc.GetAll().Select(p => new { p.DepartmentId, p.Name }).ToList();

            return View(data);
        }

        [HttpPost]
        public ActionResult CourseBatchEdit(IList<CourseUpdateVM> data, bool IsEditMode = false)
        {
            if (ModelState.IsValid)
            {
                if (courseSevc.BatchEdit(data))
                {
                    TempData["CourseBatchEditResult"] = "更新成功";
                    return RedirectToAction(nameof(CourseBatchEdit));
                }
                else
                {
                    return RedirectToAction(nameof(CourseBatchEdit));
                }
            }
            ViewBag.IsEditMode = IsEditMode;
            ViewBag.DepartmentList = departmentSevc.GetAll().Select(p => new { p.DepartmentId, p.Name }).ToList();
            return View(courseSevc.GetAll().ToList());

        }
    }
}
