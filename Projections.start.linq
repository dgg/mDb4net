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
		.Where(p => p.PostalCode == 9000)
		.Dump("aalborgC", 2);
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

[BsonIgnoreExtraElements]
public class Snapshot
{
	public string CountryCode { get; set; }
	public string PlaceName { get; set; }
	public int PostalCode { get; set; }
}

public static class All<T>
{
	private static readonly Lazy<IMongoFields> _fields;
	static All()
	{
		
		Func<IMongoFields> init = ()=>
		{
			Type type = typeof(T);
						
			BsonClassMap map = BsonClassMap<T>.LookupClassMap(type);
			if (map == null)
			{
				throw new ArgumentException(string.Format(
				"Cannot find class map for type '{0}'",
				type.FullName),
				"<T>");
			}
			string[] memberNames = map.AllMemberMaps
				.Select(m => m.ElementName)
				.ToArray();
			IMongoFields fields = MongoDB.Driver.Builders.Fields.Include(memberNames);
			return fields;
		};
		_fields = new Lazy<IMongoFields>(init);
	}

	public static IMongoFields Fields { get { return _fields.Value;} }
}