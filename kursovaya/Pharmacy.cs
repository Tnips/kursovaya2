﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovaya
{
	public class Pharmacy
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}
