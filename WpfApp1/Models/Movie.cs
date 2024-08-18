using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.Models
{
	public class Movie
	{
		// idCount maintains a counter assigned as Id to each new Person-object and 
		// then incremented so that each Person-object has a unique Id number
		private static int idCount = 0;

		public int Id { get; }
		public string Titel { get; set; }
		public string MovieGenre { get; set; }
		public int Duration { get; set; }

		public Movie()
		{

			Id = idCount++;
		}

		public override string ToString()
		{
			return $"{Id}";
		}
	}
}