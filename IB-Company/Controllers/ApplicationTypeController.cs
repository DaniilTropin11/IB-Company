using IB_Company.Data;
using IB_Company.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace IB_Company.Controllers
{
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
			_db.ApplicationType.Add(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");
        }
    }
}
