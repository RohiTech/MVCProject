using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            using (CollegeEntities dbModel = new CollegeEntities())
            {
                return View(dbModel.Students.ToList());
            }
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            using (CollegeEntities dbModels = new CollegeEntities())
            {
                return View(dbModels.Students.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                using (CollegeEntities dbModel = new CollegeEntities())
                {
                    dbModel.Students.Add(student);
                    dbModel.SaveChanges();
                }

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            using (CollegeEntities dbModel = new CollegeEntities())
            {
                return View(dbModel.Students.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                using (CollegeEntities dbModel = new CollegeEntities())
                {
                    dbModel.Entry(student).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }

                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            using (CollegeEntities dbModel = new CollegeEntities())
            {
                return View(dbModel.Students.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (CollegeEntities dbModel = new CollegeEntities())
                {
                    Student student = dbModel.Students.Where(x => x.Id == id).FirstOrDefault();
                    dbModel.Students.Remove(student);
                    dbModel.SaveChanges();
                }

                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
