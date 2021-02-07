using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UtaemKomite.Araclar;
using UtaemKomite.Models;

namespace UtaemKomite.Controllers
{
	[Yetki("admin")]
	public class AdminController : Controller
    {
		MyContext db;
		public AdminController(MyContext db)
		{
			this.db = db;
		}


        public IActionResult Index()
        {
            return View();
        }
    }
}