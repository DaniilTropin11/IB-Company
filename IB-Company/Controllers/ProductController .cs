using IB_Company.Data;
using IB_Company.Models;
using IB_Company.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IB_Company.Controllers
{
	public class ProductController : Controller
	{
		private readonly ApplicationDbContext _db;
		private readonly IWebHostEnvironment _webHostEnvironment;	

		public ProductController(ApplicationDbContext db,IWebHostEnvironment webHostEnvironment)
		{
			_db = db;
			_webHostEnvironment = webHostEnvironment;
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
			//IEnumerable<SelectListItem> CategoryDropDown = _db.Category.Select(i => new SelectListItem
			//{
			//	Text = i.Name,
			//	Value = i.Id.ToString()
			//}); // получаем все категориии из БД , конвертируя их в специальный список дял выбора который является перечисляемым IEnumerable

			////ViewBag.CategoryDropDown = CategoryDropDown;
			//ViewData["CategoryDropDown"] = CategoryDropDown;


			//Product product = new Product();


			ProductVM productVM = new ProductVM()
			{
					Product = new Product(),
					CategorySelectList = _db.Category.Select(i => new SelectListItem
					{
						Text = i.Name,
						Value = i.Id.ToString()
					})
				};
			

            if (id == null)
			{
				// если значение нулевое , это означает что поступил запрос на создание новой сущности
				return View(productVM);
			}
			else 
			{
                // когда id имеет какое значение , нужно получить продукт из БД и передать этот объект в View
                productVM.Product = _db.Product.Find(id);
				if (productVM.Product == null) 
				{
					return NotFound();
				}
				return View(productVM);
			}
		}
		// метод post Для операции Upsert 
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Upsert(ProductVM productVM) 
		{
			if (ModelState.IsValid) //валидация на стороне добавления 
			{
				var files = HttpContext.Request.Form.Files;
				string webRootPath = _webHostEnvironment.WebRootPath;

				if (productVM.Product.Id == 0)
				{
					// создание
					string upload = webRootPath + WC.ImagePath;
					string fileName = Guid.NewGuid().ToString();
					string extension = Path.GetExtension(files[0].FileName);

					using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
					{
						files[0].CopyTo(fileStream);
					}

					productVM.Product.Image = fileName + extension;

					_db.Product.Add(productVM.Product);

				}
				else
				{
					//обновление 
				}
				_db.SaveChanges();	
				return RedirectToAction("Index");
			}

			return View();
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
