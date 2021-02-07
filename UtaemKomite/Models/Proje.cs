using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UtaemKomite.Models
{
	[Table("Proje")]
	public class Proje
	{
		public int ID { get; set; }

		public int kulID { get; set; }

		[StringLength(600,MinimumLength = 10, ErrorMessage ="10 - 600 karakter olmalı!")]
		public string isim { get; set; }

		[DataType(DataType.Date)]
		public DateTime tarih { get; set; }

		public PROJEDURUM durum { get; set; }

		public bool görünür { get; set; }

	}

	public enum PROJEDURUM
	{
		teklif,
		gelişme,
		sonuç
	}
}
