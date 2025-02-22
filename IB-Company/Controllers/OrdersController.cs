
using IBCompany_DataAccess.Data;
using IBCompany_Models;
using IBCompany_Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace IB_Company.Controllers
{
    [Authorize(Roles = WC.AdminRole)]

    public class OrdersController : Controller
	{
		private readonly ApplicationDbContext _db;

		public OrdersController(ApplicationDbContext db)
		{
			_db = db;
		}


		public IActionResult Index()
		{
			IEnumerable<OrderVM> objlist = _db.Orders;
			return View(objlist);
		}

	}
}
