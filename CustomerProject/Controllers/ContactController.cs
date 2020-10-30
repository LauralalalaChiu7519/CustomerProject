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
    public class ContactController : Controller
    {
        private CustomerDataEntities db = new CustomerDataEntities();
        客戶聯絡人Repository repoContact;
        客戶資料Repository repo;
        public ContactController()
        {
            repoContact = RepositoryHelper.Get客戶聯絡人Repository();
            repo = RepositoryHelper.Get客戶資料Repository(repoContact.UnitOfWork);
            
        }
        // GET: Contact
        public ActionResult Index()
        {
            return View(repoContact.All().ToList());
        }

        // GET: Contact/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            客戶聯絡人 客戶聯絡人 = repoContact.GetOne客戶聯絡人(id.Value);
            return View(客戶聯絡人);
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(repo.All(), "Id", "客戶名稱");
            return View();
        }

        // POST: Contact/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                repoContact.Add(客戶聯絡人);
                repoContact.UnitOfWork.Commit();
                //db.客戶聯絡人.Add(客戶聯絡人);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(repo.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            客戶聯絡人 客戶聯絡人 = repoContact.GetOne客戶聯絡人(id.Value);
           
            ViewBag.客戶Id = new SelectList(repo.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // POST: Contact/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                var item = repoContact.GetOne客戶聯絡人(id);

                item.InjectFrom(客戶聯絡人);

                repoContact.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(repo.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            客戶聯絡人 客戶聯絡人 = repoContact.GetOne客戶聯絡人(id.Value);

            ViewBag.客戶Id = new SelectList(repo.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶聯絡人 客戶聯絡人 = repoContact.GetOne客戶聯絡人(id);

            repoContact.Delete(客戶聯絡人);

            repoContact.UnitOfWork.Commit();
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
