<Query Kind="Program">
  <NuGetReference>mongocsharpdriver</NuGetReference>
  <Namespace>MongoDB.Bson</Namespace>
  <Namespace>MongoDB.Driver</Namespace>
  <Namespace>MongoDB.Driver.Builders</Namespace>
  <Namespace>MongoDB.Driver.Linq</Namespace>
  <Namespace>System.Globalization</Namespace>
  <Namespace>System.Dynamic</Namespace>
  <Namespace>MongoDB.Bson.Serialization.Attributes</Namespace>
  <Namespace>MongoDB.Bson.Serialization</Namespace>
  <Namespace>MongoDB.Bson.Serialization.Conventions</Namespace>
</Query>

void Main()
{
	var pack = new ConventionPack();
	pack.Add(new CamelCaseElementNameConvention());
	ConventionRegistry.Register("camelize", pack, _ => true);

	var db = new MongoClient().GetServer().GetDatabase("pitfalls");
	var aalborgC = db.GetCollection<Detail>("PostalCodes")
		.AsQueryable()
		.First(p => p.PostalCode == 9000);
	
	aalborgC.Dump(2);
	
	var nørresundby = db.GetCollection<Snapshot>("PostalCodes")
		.AsQueryable()
		.First(p => p.PostalCode == 9400);
		
	nørresundby.Dump(2);
}

// Define other methods and classes here
public class Detail
{
	public ObjectId Id { get; set; }
	public string CountryCode { get; set; }
	public string PlaceName { get; set; }
	public int PostalCode { get; set; }
	public double[] Loc { get; set; }
	public Location Location { get; set; }
}

public class Location
{
	public double Longitude { get; set; }
	public double Latitude { get; set; }
}

public class Snapshot
{
	public string CountryCode { get; set; }
	public string PlaceName { get; set; }
	public int PostalCode { get; set; }
}
