using IB_Company.Data;
using IB_Company.Models;
using IBCompany_Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace IB_Company.Controllers
{
    [Authorize(Roles = WC.AdminRole)]

    public class ApplicationTypeController : Controller
	{
		private readonly ApplicationDbContext _db;

		public ApplicationTypeController(ApplicationDbContext db)
		{
			_db = db;
		}


		public IActionResult Index()
		{
			IEnumerable<ApplicationType> objlist = _db.ApplicationType;
			return View(objlist);
		}
		public IActionResult Create() // метод get Для операции create 
		{

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(ApplicationType obj) // метод get Для операции create 
		{
			if (ModelState.IsValid) //валидация на стороне добавления 
			{
				_db.ApplicationType.Add(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(obj);
		}

		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var obj = _db.ApplicationType.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			return View(obj);
		}

		// метод get Для операции edit

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(ApplicationType obj)
		{
			if (ModelState.IsValid)
			{
				_db.ApplicationType.Update(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(obj);
		}
		///------------------------------------------------
		public IActionResult Delete(int? id) // метод get Для операции delete
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var obj = _db.ApplicationType.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			return View(obj);
		}

		// метод get Для операции delete

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePost(int? id)
		{
			var obj = _db.ApplicationType.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			_db.ApplicationType.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");

		}

	}
}
