using Doctolib.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctolibASP.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Patients = Patient.GetAll();
            return View();
        }

        public IActionResult FormPatient()
        {
            return View();
        }

        public IActionResult SubmitFormPatient()
        {
            return RedirectToAction("Index");
        }

        public IActionResult DetailPatient(int id)
        {
            return View();
        }
    }
}
