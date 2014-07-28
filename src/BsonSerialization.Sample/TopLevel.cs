using System;

namespace BsonSerialization.Sample
{
	public class TopLevel
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public decimal Number { get; set; }
		public SecondLevel[] Children { get; set; }
	}
}