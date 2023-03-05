namespace Domain.Entities
{
	public class Idea
	{
		public Guid Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public string? Description { get; set; }

		public DateTime CreatedOn { get; set; }

		public Category Category { get; set; } = default!;
	}
}