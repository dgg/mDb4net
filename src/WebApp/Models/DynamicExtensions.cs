using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace UseDynamicSyntax.Models
{
	public static class DynamicExtensions
	{
		public static dynamic AsDynamic(this BsonDocument doc)
		{
			return new DynamicBsonDocument(doc);
		}

		public static IEnumerable<dynamic> AsDynamic(this IEnumerable<BsonDocument> docs)
		{
			return docs.Select(d => d.AsDynamic());
		}
	}
}