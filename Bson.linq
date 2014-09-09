<Query Kind="Statements">
  <NuGetReference>mongocsharpdriver</NuGetReference>
  <Namespace>MongoDB.Bson</Namespace>
  <Namespace>MongoDB.Bson.Serialization</Namespace>
  <Namespace>MongoDB.Bson.Serialization.Attributes</Namespace>
  <Namespace>MongoDB.Bson.Serialization.Conventions</Namespace>
  <Namespace>MongoDB.Bson.Serialization.IdGenerators</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>

BsonDocument doc = new BsonDocument();
doc.Dump("empty");

doc = new BsonDocument("key", 42L);
doc.Dump("initialize with one key", 3);
doc.Add("anoter_key", false);
doc.Dump("add property", 3);

doc.Add("chain_1", 1).Add("chain_2", 2).Set("another_key", true);
doc.Dump("chain property operations", 3);
doc["another_key"] = "FALSE";
doc["new_key"] = 'a';
doc.Dump("indexers", 3);

doc.Add("a_list", new BsonArray{1, 2, 3, 4});
doc.Dump("arrays", 2);

doc.Add("subdocument", new BsonDocument("key", "value"));
doc.Dump("subdocument", 2);

var jsonLike = new BsonDocument("_id", "user1")
{
	{"interests", new BsonArray{"basketball", "drumming"}},
	{"address", new BsonDocument
		{
			{"street", "20 Main"},
			{"town", "Westfield"},
			{"zip", "5678"}
		}
	}
};

jsonLike.Dump("json-like", 2);

var o = new
{
	_id = "user1",
	interests = new[]{"basketball", "drumming"},
	address = new
	{
		street = "20 Main",
		town = "Westfield",
		zip ="5678"
	}
};
o.Dump("object");

var b = o.ToBsonDocument();
b.Dump("bson document", 2);