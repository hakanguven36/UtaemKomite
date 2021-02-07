using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UtaemKomite.Models
{
	public class MyContext : DbContext
	{
		public MyContext(DbContextOptions<MyContext> options) : base(options)
		{
		}

		public DbSet<Kullar> Kullar { get; set; }
		public DbSet<Proje> Proje { get; set; }
		public DbSet<Prodosya> Prodosya { get; set; }
		public DbSet<Toplantı> Toplantı { get; set; }
		public DbSet<Tutanak> Tutanak { get; set; }
		public DbSet<Tutdosya> Tutdosya{ get; set; }


	}
}
