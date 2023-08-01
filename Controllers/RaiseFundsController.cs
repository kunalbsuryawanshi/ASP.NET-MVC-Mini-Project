using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Panchayat.Models;

namespace Panchayat.Controllers
{
    public class RaiseFundsController : Controller
    {
        // GET: RaiseFundsController
        public ActionResult Index()
        {
            List<RaiseFund> list = RaiseFund.GetAllDonations();
            return View(list);
        }

        // GET: RaiseFundsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult ThanksPage()
        {
            return View();
        }

        // GET: RaiseFundsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RaiseFundsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RaiseFund fund)
        {
            try
            {
                RaiseFund.AddFund(fund);
                return RedirectToAction(nameof(ThanksPage));
            }
            catch
            {
                return View();
            }
        }

        // GET: RaiseFundsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RaiseFundsController/Edit/5
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

        // GET: RaiseFundsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RaiseFundsController/Delete/5
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
