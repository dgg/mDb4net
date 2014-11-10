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
	
	Person[] somePeople = new[]
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
	people.InsertBatch(somePeople);	
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