using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Panchayat.Models;

namespace Panchayat.Controllers
{
    public class SignupsController : Controller
    {
        // GET: SignupsController
        public ActionResult Index()
        {
            List<Signup> list = Signup.getAllSignups();
            return View(list);
        }

        // GET: SignupsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SignupsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SignupsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Signup signup)
        {
            try
            {
                Signup.AddUserInSignup(signup);
                return RedirectToAction(nameof(Login));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();
        }

        // POST: SignupsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Signup signup)
        {
            try
            {
                bool status = Signup.VerifyUser(signup);
                if (status)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                return RedirectToAction(nameof(Error));
                //return RedirectToAction("AdminPage", "PanchayatActivities");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Error(int id)
        {
            return View();
        }


        // GET: SignupsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        // POST: SignupsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SignupsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SignupsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
