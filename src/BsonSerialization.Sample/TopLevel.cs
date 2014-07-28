using System;
using MongoDB.Bson.Serialization.Attributes;

namespace BsonSerialization.Sample
{
	public class TopLevel
	{
		public Guid Id { get; set; }
		[BsonElement("display_name")]
		public string Name { get; set; }
		public decimal Number { get; set; }
		public SecondLevel[] Children { get; set; }
	}
}