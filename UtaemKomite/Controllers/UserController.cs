using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
		private readonly IWebHostEnvironment hostEnvironment;
		private string uploadsRoot;

		public UserController(MyContext db, IWebHostEnvironment hostEnvironment)
		{
			this.db = db;
			this.hostEnvironment = hostEnvironment;
			uploadsRoot = hostEnvironment.WebRootPath + "/Dosyalar/ProDosyalar";
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

		public IActionResult DosyalarımListele(int projeID)
		{
			try
			{
				int kulID = KulID();
				var dosyalar = db.Prodosya.Where(u => u.kulID == kulID).Where(u => u.projeID == projeID).OrderByDescending(u => u.ID).ToList();
				return PartialView(dosyalar);
			}
			catch (Exception e)
			{
				return Hata(e);
			}
		}

		[HttpGet]
		public IActionResult DosyaEkle(int projeID)
		{
			var proje = db.Proje.Find(projeID);
			if (proje.kulID != KulID())
				return Json("Bu proje sizin değil!!!");
			ViewBag.prodosyaEklenecekProjeID = projeID;
			return PartialView();
		}

		[HttpPost]
		public IActionResult DosyaEkle(IFormFile dosya, int projeID)
		{
			try
			{
				
				int versiyon = db.Prodosya.Where(u => u.projeID == projeID).Max(u => u.versiyon) + 1;
					Prodosya prodosya = new Prodosya();
					prodosya.orjisim = Path.GetFileNameWithoutExtension(dosya.FileName);
					prodosya.orjuzantı = Path.GetExtension(dosya.FileName);
					prodosya.bytenumber = Convert.ToInt32(dosya.Length);
					prodosya.kulID = KulID();
					prodosya.tarih = DateTime.Now;
					prodosya.sysname = Arac.RandomString(8);
					prodosya.versiyon = versiyon;

					string path = Path.Combine(uploadsRoot, prodosya.sysname);
					using (var filestream = new FileStream(path, FileMode.Create))
					{
						dosya.CopyTo(filestream);
					}

					// database kaydet
					db.Add(prodosya);
					db.SaveChanges();
					return Tamam();
					
				return Json("Hata: ModelState valid değildi!");
			}
			catch (Exception e)
			{
				return Hata(e);
			}
			
		}

		private JsonResult Tamam() => Json("Tamam");
		private JsonResult Hata(Exception e) => Json("Hata: " + e.Message);
		private int KulID() => HttpContext.Session.GetInt32("kulID")??0;
    }
}