<Query Kind="Statements">
  <NuGetReference>mongocsharpdriver</NuGetReference>
  <Namespace>MongoDB.Bson</Namespace>
  <Namespace>MongoDB.Bson.Serialization</Namespace>
  <Namespace>MongoDB.Driver</Namespace>
  <Namespace>MongoDB.Driver.Builders</Namespace>
  <Namespace>MongoDB.Driver.Linq</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>

MongoClient client = new MongoClient();
MongoDatabase db = client.GetServer().GetDatabase("crud");
MongoCollection people = db.GetCollection("People");


/*var daniel = new BsonDocument("_id", new {dni = "50974906Y", cpr = "110377xxxx"}.ToBsonDocument())
{
	{"name", "Daniel"},
	{"age", 37},
	{"nicknames", new BsonArray{"flips", "Spanish Dan", "Great Dane"} }
};
people.Insert(daniel);*/

/*BsonDocument[] morePeople = new[]
{
	new BsonDocument
	{
		{"name", "Daniel"},
		{"age", 37},
		{"nicknames", new BsonArray{"flips", "Spanish Dan", "Great Dane"} }
	},
	new BsonDocument
	{
		{"name", "Jesús"},
		{"age", 37},
		{"nicknames", new BsonArray{"Chuchi", "Kiko", "Muslitos Sánchez"} }
	},
	new BsonDocument
	{
		{"name", "Jorge"},
		{"age", 38},
		{"nicknames", new BsonArray{"Can", "Chiqs"} }
	},
};
people.InsertBatch(morePeople);*/

/*people.FindOneAs<BsonDocument>().Dump(2);
people.FindAllAs<BsonDocument>().Dump(2);
people.FindOneByIdAs<BsonDocument>(new ObjectId("540ea7c4f09efc12907e4c9d")).Dump(2);
people.FindAs<BsonDocument>(Query.EQ("name", "Daniel")).Dump(2);*/
/*var query = new QueryDocument("age", 37);
query.Add("nicknames", "Kiko");
people.FindAs<BsonDocument>(query).Dump(2);*/

people.Count(
Query.Or(
	Query.EQ("nicknames", "flips"),
	Query.GT("age", 37)))
.Dump();
