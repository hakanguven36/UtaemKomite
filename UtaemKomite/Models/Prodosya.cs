using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UtaemKomite.Models
{
	[Table("Prodosya")]
	public class Prodosya
	{
		public int ID { get; set; }

		public int kulID { get; set; }

		public int projeID { get; set; }

		[NotMapped]
		[Required, FileExtensions(Extensions =".pdf,.doc,.docx", ErrorMessage ="Dosya uygun değil!!")]
		public IFormFile dosya { get; set; }

		public int versiyon { get; set; }

		[StringLength(600)]
		public string orjisim { get; set; }

		[StringLength(6)]
		public string orjuzantı { get; set; }

		[StringLength(60)]
		public string sysname { get; set; }

		public int bytenumber { get; set; }

		public DateTime tarih { get; set; }

		public int downloads { get; set; }

	}
}
