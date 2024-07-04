using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovaya.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string TypeOf { get; set; }
		public decimal Price { get; set; }
		public string ForWhat { get; set; }
		public string Description { get; set; }
		public string Akcii { get; set; }
		public string Photo { get; set; }
	}
}
