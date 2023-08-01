using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Panchayat.Models;

namespace Panchayat.Controllers
{
    public class PanchayatActivitiesController : Controller
    {
        // GET: PanchayatController
        public ActionResult Index()
        {
            List<PanchayatActivity> list = PanchayatActivity.GetAllActivities();
            return View(list);
        }
        public ActionResult AdminPage()
        {
            return View();
        }
        public ActionResult ActivitiesForUser()
        {
            List<PanchayatActivity> list = PanchayatActivity.GetAllActivities();
            return View(list);
        }

        // GET: PanchayatController/Details/5
        public ActionResult Details(int id)
        {
            PanchayatActivity activity = PanchayatActivity.GetActivityById(id); 
            return View(activity);
        }
        public ActionResult ActivityDetailsForUser(int id)
        {
            PanchayatActivity activity = PanchayatActivity.GetActivityById(id); 
            return View(activity);
        }

        // GET: PanchayatController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PanchayatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PanchayatActivity activity)
        {
            try
            {
                PanchayatActivity.AddActivities(activity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PanchayatController/Edit/5
        public ActionResult Edit(int id)
        {
            PanchayatActivity activity = PanchayatActivity.GetActivityById(id);
            return View(activity);
        }

        // POST: PanchayatController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PanchayatActivity activity)
        {
            try
            {
                PanchayatActivity.UpdateActivity(id, activity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PanchayatController/Delete/5
        public ActionResult Delete(int id)
        {
            PanchayatActivity activity = PanchayatActivity.GetActivityById(id);
            return View(activity);
        }

        // POST: PanchayatController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PanchayatActivity activity)
        {
            try
            {
                PanchayatActivity.DeleteActivity(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
