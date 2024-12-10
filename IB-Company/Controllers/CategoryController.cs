using IB_Company.Data;
using IBCompany_Models;
using IBCompany_Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace IB_Company.Controllers
{
    [Authorize(Roles = WC.AdminRole)]
    public class CategoryController : Controller
	{
		private readonly ApplicationDbContext _db;

		public CategoryController(ApplicationDbContext db)
		{
			_db = db;
		}


		public IActionResult Index()
		{
			IEnumerable<Category> objlist = _db.Category;
			return View(objlist);
		}
		public IActionResult Create() // метод get Для операции create 
		{

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Category obj) // метод get Для операции create 
		{
			if (ModelState.IsValid) //валидация на стороне добавления 
			{
				_db.Category.Add(obj);
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
			var obj = _db.Category.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			return View(obj);
		}

		// метод get Для операции edit

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Category obj)
		{
			if (ModelState.IsValid)
			{
				_db.Category.Update(obj);
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
			var obj = _db.Category.Find(id);
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
			var obj = _db.Category.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			_db.Category.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");

		}

	}
}
