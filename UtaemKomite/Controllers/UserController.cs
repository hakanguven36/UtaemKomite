using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UtaemKomite.Araclar;
using UtaemKomite.Models;

namespace UtaemKomite.Controllers
{
	[Yetki("user")]
    public class UserController : Controller
    {
		MyContext db;
		public UserController(MyContext db)
		{
			this.db = db;
		}

		public IActionResult Index()
        {
            return View();
        }

		public IActionResult ProjelerimListele()
		{
			int kulID = KulID();
			return PartialView(db.Proje.Where(u => u.kulID == kulID).ToList());
		}

		[HttpGet]
		public IActionResult YeniProjeEkle()
		{
			return PartialView();
		}
		[HttpPost]
		public IActionResult YeniProjeEkle(Proje proje)
		{
			try
			{
				proje.kulID = KulID();
				proje.tarih = DateTime.Now;
				db.Proje.Add(proje);
				db.SaveChanges();
				return Tamam();
			}
			catch (Exception e)
			{
				return Hata(e);
			}
		}


		[HttpGet]
		public IActionResult ProjeDüzenle(int id)
		{
			var proje = db.Proje.Find(id);
			if(proje.kulID != KulID())
				return Json("Bu projenin sahibi değilsiniz!");
			
			return PartialView(proje);
		}
		[HttpPost]
		public IActionResult ProjeDüzenle(Proje _proje)
		{
			try
			{
				var proje = db.Proje.Find(_proje.ID);
				if (proje.kulID != KulID())
					return Json("Bu projenin sahibi değilsiniz!");
				proje.isim = _proje.isim;
				proje.durum = _proje.durum;
				db.Entry(proje).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				db.SaveChanges();
				return Tamam();
			}
			catch (Exception e)
			{
				return Hata(e);
			}
		}

		public IActionResult DosyaEkle()
		{
			return PartialView();
		}

		private JsonResult Tamam() => Json("Tamam");
		private JsonResult Hata(Exception e) => Json("Hata: " + e.Message);
		private int KulID() => HttpContext.Session.GetInt32("kulID")??0;
    }
}