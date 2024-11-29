using IB_Company.Data;
using IB_Company.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IB_Company.Controllers
{
	public class ProductController : Controller
	{
		private readonly ApplicationDbContext _db;

		public ProductController(ApplicationDbContext db)
		{
			_db = db;
		}


		public IActionResult Index()
		{
			IEnumerable<Product> objlist = _db.Product;
			foreach (var obj in objlist)
			{
				obj.Category = _db.Category.FirstOrDefault(u => u.Id== obj.CategoryId);
			};
			
			return View(objlist);
		}
		public IActionResult Upsert(int? id) // метод get Для операции Upsert 
		{
			IEnumerable<SelectListItem> CategoryDropDown = _db.Category.Select(i => new SelectListItem
			{
				Text = i.Name,
				Value = i.Id.ToString()
			}); // получаем все категориии из БД , конвертируя их в специальный список дял выбора который является перечисляемым IEnumerable

			ViewBag.CategoryDropDown = CategoryDropDown;

            Product product = new Product();
			if (id == null)
			{
				// если значение нулевое , это означает что поступил запрос на создание новой сущности
				return View(product);
			}
			else 
			{
				// когда id имеет какое значение , нужно получить продукт из БД и передать этот объект в View
				product = _db.Product.Find(id);
				if (product == null) 
				{
					return NotFound();
				}
				return View(product);
			}
		}
		// метод post Для операции Upsert 
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Upsert(Category obj) 
		{
			if (ModelState.IsValid) //валидация на стороне добавления 
			{
				_db.Category.Add(obj);
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
