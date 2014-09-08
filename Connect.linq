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
}

// Define other methods and classes here
private void printCollections(MongoDatabase db)
{
	db.GetCollectionNames().Dump();
}

