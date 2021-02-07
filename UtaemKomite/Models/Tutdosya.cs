using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UtaemKomite.Models
{
	[Table("Tutdosya")]
	public class Tutdosya
	{
		public int ID { get; set; }

		public int toplantıID { get; set; }

		public int tutanakID { get; set; }

		[NotMapped]
		public IFormFile dosya { get; set; }

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
