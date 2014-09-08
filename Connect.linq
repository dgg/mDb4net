<Query Kind="Program">
  <NuGetReference>mongocsharpdriver</NuGetReference>
  <Namespace>MongoDB.Bson</Namespace>
  <Namespace>MongoDB.Bson.Serialization</Namespace>
  <Namespace>MongoDB.Driver</Namespace>
  <Namespace>MongoDB.Driver.Builders</Namespace>
  <Namespace>MongoDB.Driver.Linq</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{
	printCollections(
		new MongoClient().GetServer().GetDatabase("basics"));
	
	printCollections(
		new MongoClient("mongodb://localhost:27017").GetServer().GetDatabase("basics"));
		
	var clientSettings = new MongoClientSettings()
	{
		Server = new MongoServerAddress("localhost", 27017)
	};
	printCollections(
		new MongoClient(clientSettings).GetServer().GetDatabase("basics"));
		
	MongoUrl url = MongoUrl.Create("mongodb://localhost:27017");
	printCollections(
		new MongoClient(url).GetServer().GetDatabase("basics"));
		
	var dbSettings = new MongoDatabaseSettings()
	{
		ReadPreference = new ReadPreference(ReadPreferenceMode.Primary)
	};
	printCollections(
		new MongoClient(url).GetServer().GetDatabase("basics", dbSettings));
}

// Define other methods and classes here
private void printCollections(MongoDatabase db)
{
	db.GetCollectionNames().Dump();
}

