using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UtaemKomite.Araclar;
using UtaemKomite.Models;

namespace UtaemKomite.Controllers
{
	[Yetki("user")]
	public class HomeController : Controller
	{
		MyContext db;
		public HomeController(MyContext db)
		{
			this.db = db;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult BenimSayfam()
		{
			return View();
		}



		public int GetKulID()
		{
			return HttpContext.Session.GetInt32("kulID")??0;
		}
	}
}
