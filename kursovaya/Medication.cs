﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovaya
{
	public class Medication
	{
		public string? Id { get; set; }
		public string? Name { get; set; }
		public string? TypeOf { get; set; }
		public decimal Price { get; set; }
		public string? Foto { get; set; }
		public string? Opisanie { get; set; }
		public string? ForWhat { get; set; }
		public decimal Twoprice { get; set; }
		public bool Akcii { get; set; }


	}
}
