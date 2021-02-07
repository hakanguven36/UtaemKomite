using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UtaemKomite.Models
{
	[Table("Tutanak")]
	public class Tutanak
	{
		public int ID { get; set; }

		public int ToplantıID { get; set; }

		public int kulID { get; set; }

		public int projeID { get; set; }

		public int yazanID { get; set; }

		public DateTime tarih { get; set; }

		[DataType(DataType.MultilineText)]
		public string metin { get; set; }
	}
}
