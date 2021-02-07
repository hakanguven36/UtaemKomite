using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UtaemKomite.Models
{
	[Table("Toplantı")]
	public class Toplantı
	{
		public int ID { get; set; }

		[DataType(DataType.Date)]
		public DateTime tarih { get; set; }

		[DataType(DataType.MultilineText)]
		public string gündem { get; set; }

	}
}
