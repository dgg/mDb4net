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
				result = wrap(value);
				return true;
			}
			result = null;
			return true;
		}

		public object wrap(BsonValue value)
		{
			object wrapped;
			if (value.IsBsonDocument)
			{
				wrapped = new DynamicBsonDocument(value.AsBsonDocument);
			}
			else if (value.IsBsonArray)
			{
				wrapped = value.AsBsonArray.Select(wrap).ToArray();
			}
			else
			{
				wrapped = value;
			}
			return wrapped;
		}

		public override IEnumerable<string> GetDynamicMemberNames()
		{
			return _doc.Elements.Select(e => e.Name); ;
		}
	}
}