﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.AboutDto
{
	public class UpdateAboutDto
	{
		public int AboutID { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public string Title { get; set; }
	}
}
