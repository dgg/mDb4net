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

var daniel = new BsonDocument
{
	{"name", "Daniel"},
	{"age", 37},
	{"nicknames", new BsonArray{"flips", "Spanish Dan", "Great Dane"} }
};
people.Insert(daniel);

BsonDocument[] morePeople = new[]
{
	new BsonDocument("_id", 1)
	{
		{"name", "Jesús"},
		{"age", 37},
		{"nicknames", new BsonArray{"Chuchi", "Kiko", "Muslitos Sánchez"} }
	},
	new BsonDocument("_id", Guid.NewGuid())
	{
		{"name", "Jorge"},
		{"age", 38},
		{"nicknames", new BsonArray{"Can", "Chiqs", "Bracicos"} }
	},
	new BsonDocument("_id", new {dni = "50974906Y", cpr = "110377xxxx"}.ToBsonDocument())
	{
		{"name", "Daniel"},
		{"age", 37},
		{"nicknames", new BsonArray{"Flips", "Spanish Dan", "Great Dane"} }
	},
};
people.InsertBatch(morePeople);

people.FindOneAs<BsonDocument>().Dump(2);
people.FindAllAs<BsonDocument>().Dump(2);
people.FindOneByIdAs<BsonDocument>(new ObjectId("545a8427096dd89ab561e98c")).Dump(2);
people.FindAs<BsonDocument>(Query.EQ("name", "Daniel")).Dump(2);

var query = new QueryDocument("age", 37)
{
	{"nicknames", "Kiko"}
};
people.FindAs<BsonDocument>(query).Dump(2);

people.Count(
	Query.Or(
		Query.EQ("nicknames", "flips"),
		Query.GT("age", 37)))
.Dump();

people.FindAs<BsonDocument>(Query.EQ("_id.dni", "50974906Y")).Dump(2);

people.Count(Query.Exists("_id")).Dump();

var lazy = people.FindAllAs<BsonDocument>();
lazy.Skip = 1;
lazy.Limit = 2;
lazy.Fields = Fields.Include("name");

foreach (var person in lazy)
{
	person.Contains("name").Dump("has name");
	person.Contains("age").Dump("has age");
}

people.Update(Query.EQ("name", "Jorge"), Update.Set("created", 2));

people.Update(Query.EQ("name", "Jorge"), Update.Unset("created"));

people.Update(Query.EQ("name", "Jorge"), Update.Inc("age", 2)).Dump();

people.Update(
	Query.EQ("name", "Mario"),
	Update.Set("gender", "M"));
people.Count().Dump("No upsert, still 4 documents");

people.Update(
	Query.EQ("name", "Mario"),
	Update.Set("gender", "M"),
	UpdateFlags.Upsert);
people.Count().Dump("Upserted male Mario");

people.Update(
	Query.Null,
	Update.Set("procedence", "Vallekas"));
people.Count(Query.Exists("procedence")).Dump("only one?");
people.Update(
	Query.Null,
	Update.Set("procedence", "Vallekas"),
	new MongoUpdateOptions { Flags = UpdateFlags.Multi });
people.Count(Query.Exists("procedence")).Dump("everyone from same 'hood");

people.Remove(Query.EQ("procedence", "Vallekas"));
people.Count().Dump("everyone... out");