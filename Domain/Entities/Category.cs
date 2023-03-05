﻿using Microsoft.VisualBasic;

namespace Domain.Entities
{
	public class Category
	{
		public Guid Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public ICollection<Idea> Ideas { get; set; } = new List<Idea>();
    }
}