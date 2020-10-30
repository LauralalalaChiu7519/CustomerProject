using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomerProject.Models;
using Omu.ValueInjecter;

namespace CustomerProject.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerDataEntities db = new CustomerDataEntities();
        客戶資料Repository repo;
        public CustomerController()
        {
            repo = RepositoryHelper.Get客戶資料Repository();

        }
        // GET: Customer
        public ActionResult Index()
        {
            return View(repo.All().ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            客戶資料 客戶資料 = repo.GetOne客戶資料(id.Value);
            return View(客戶資料);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                repo.Add(客戶資料);
                repo.UnitOfWork.Commit();
                //db.客戶資料.Add(客戶資料);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(客戶資料);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            客戶資料 客戶資料 = repo.GetOne客戶資料(id.Value);

            return View(客戶資料);

        }

        // POST: Customer/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                var item = repo.GetOne客戶資料(id);

                item.InjectFrom(客戶資料);

                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            客戶資料 客戶資料 = repo.GetOne客戶資料(id.Value);

            return View(客戶資料);

        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶資料 客戶資料 = repo.GetOne客戶資料(id);

            repo.Delete(客戶資料);

            repo.UnitOfWork.Commit();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
