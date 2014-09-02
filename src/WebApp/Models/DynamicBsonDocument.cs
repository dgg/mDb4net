using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using MongoDB.Bson;

namespace UseDynamicSyntax.Models
{
	public class DynamicBsonDocument : DynamicObject
	{
		private readonly BsonDocument _doc;

		public DynamicBsonDocument(BsonDocument doc)
		{
			_doc = doc;
		}

		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			BsonValue value;
			if (_doc.TryGetValue(binder.Name, out value))
			{
				result = value.IsBsonDocument ?
					(object)new DynamicBsonDocument(value.AsBsonDocument) :
					value;
				return true;
			}
			result = null;
			return true;
		}

		public override IEnumerable<string> GetDynamicMemberNames()
		{
			return _doc.Elements.Select(e => e.Name); ;
		}
	}
}