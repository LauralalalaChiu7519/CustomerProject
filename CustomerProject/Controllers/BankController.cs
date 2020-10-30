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
    public class BankController : Controller
    {
        private CustomerDataEntities db = new CustomerDataEntities();
        客戶銀行資訊Repository repoBank;
        客戶資料Repository repo;
        public BankController()
        {
            repoBank = RepositoryHelper.Get客戶銀行資訊Repository();
            repo = RepositoryHelper.Get客戶資料Repository(repoBank.UnitOfWork);

        }
        // GET: Bank
        public ActionResult Index()
        {
            return View(repoBank.All().ToList());
        }

        // GET: Bank/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            客戶銀行資訊 客戶銀行資訊 = repoBank.GetOne客戶銀行資訊(id.Value);
            return View(客戶銀行資訊);
        }

        // GET: Bank/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(repo.All(), "Id", "客戶名稱");
            return View();
        }

        // POST: Bank/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(客戶銀行資訊 客戶銀行資訊)
        {
            if (ModelState.IsValid)
            {
                repoBank.Add(客戶銀行資訊);
                repoBank.UnitOfWork.Commit();
                //db.客戶銀行資訊.Add(客戶銀行資訊);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(repo.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: Bank/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            客戶銀行資訊 客戶銀行資訊 = repoBank.GetOne客戶銀行資訊(id.Value);

            ViewBag.客戶Id = new SelectList(repo.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // POST: Bank/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, 客戶銀行資訊 客戶銀行資訊)
        {
            if (ModelState.IsValid)
            {
                var item = repoBank.GetOne客戶銀行資訊(id);

                item.InjectFrom(客戶銀行資訊);

                repoBank.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(repo.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: Bank/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            客戶銀行資訊 客戶銀行資訊 = repoBank.GetOne客戶銀行資訊(id.Value);

            ViewBag.客戶Id = new SelectList(repo.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // POST: Bank/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //客戶銀行資訊 客戶銀行資訊 = db.客戶銀行資訊.Find(id);
            //db.客戶銀行資訊.Remove(客戶銀行資訊);
            //db.SaveChanges();

            客戶銀行資訊 客戶銀行資訊 = repoBank.GetOne客戶銀行資訊(id);

            repoBank.Delete(客戶銀行資訊);

            repoBank.UnitOfWork.Commit();
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
