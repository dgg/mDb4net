<Query Kind="Program">
  <NuGetReference>mongocsharpdriver</NuGetReference>
  <Namespace>MongoDB.Bson</Namespace>
  <Namespace>MongoDB.Driver</Namespace>
  <Namespace>MongoDB.Driver.Builders</Namespace>
  <Namespace>MongoDB.Driver.Linq</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{
	MongoClient client = new MongoClient();
	MongoDatabase db = client.GetServer().GetDatabase("linq");
	MongoCollection<Person> people = db.GetCollection<Person>("People");
	
	/*Person[] somePeople = new[]
	{
		new Person
		{
			Name = "Jesús",
			Age =37,
			Nicknames = new[]{"Chuchi", "Kiko", "Muslitos Sánchez"}
		},
		new Person
		{
			Name ="Jorge",
			Age = 38,
			Nicknames = new []{"Can", "Chiqs", "Bracicos"}
		},
		new Person
		{
			Name="Daniel",
			Age= 37,
			Nicknames = new[]{"flips", "Spanish Dan", "Great Dane"},
			ExtraIds = new Identification
			{
				Dni = "50974906Y",
				Cpr = "110377xxxx"
			}
		}
	};
	people.InsertBatch(somePeople);*/
	
	/*people.FindOneAs<BsonDocument>().Dump(2);
	people.FindAllAs<BsonDocument>().Dump(2);
	people.FindOneByIdAs<BsonDocument>(new ObjectId("545a8427096dd89ab561e98c")).Dump(2);
	people.FindAs<BsonDocument>(Query.EQ("name", "Daniel")).Dump(2);*/
	
	/*people.FindOne().Dump(2);
	people.FindAll().Dump(2);
	people.FindOneById(new ObjectId("546084c5f09efb17bca47bac")).Dump(2);
	people.Find(Query.EQ("Name", "Daniel")).Dump(2);
	people.Find(Query<Person>.EQ(p => p.Name, "Daniel")).Dump(2);
	
	people.AsQueryable().First().Dump(2);
	people.AsQueryable().Dump(2);
	people.AsQueryable().Where(p => p.Name == "Daniel").Dump(2);*/
	
	/*people.AsQueryable()
		.Where(p => p.Age == 37)
		.Where(p => p.Nicknames.Contains("Kiko"))
	.Dump(2);
	
	people.AsQueryable()
		.Where(p => p.Nicknames.ContainsAny(new []{"flips", "Kiko"}))
	.Dump(2);
	*/
	
	/*people.AsQueryable()
	.Where(p => p.Nicknames.Contains("flips") || p.Age > 37)
		.Dump(2);*/
		
	/*people.AsQueryable()
		.SingleOrDefault(p => p.ExtraIds.Dni == "50974906Y")
		.Dump(2);*/
		
	/*people.AsQueryable()
		.Count(p => p.ExtraIds != null)
		.Dump();*/
		
	/*var lazy = people.AsQueryable()
		.Skip(1)
		.Take(2)
		.Select(p => new {p.Name});
		
	foreach (var clientProjection in lazy)
	{
		clientProjection.Name.Dump();
	}*/
	
	
}

// Define other methods and classes here
public class Person
{
	public ObjectId Id { get; set; }
	public string Name { get; set; }
	public byte Age { get; set; }
	public string[] Nicknames { get; set; }
	public Identification ExtraIds { get; set; }
}

public class Identification
{
	public string Dni { get; set; }
	public string Cpr { get; set; }
}