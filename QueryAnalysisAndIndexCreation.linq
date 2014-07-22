<Query Kind="Statements">
  <NuGetReference>mongocsharpdriver</NuGetReference>
  <Namespace>MongoDB.Driver</Namespace>
  <Namespace>MongoDB.Driver.Linq</Namespace>
  <Namespace>System.Globalization</Namespace>
  <Namespace>MongoDB.Bson</Namespace>
  <Namespace>MongoDB.Driver.Builders</Namespace>
</Query>

MongoClient client = new MongoClient(new MongoUrl("mongodb://localhost:27017"));
MongoDatabase indexing = client.GetServer().GetDatabase("indexing");
MongoCollection<BsonDocument> postalCodes = indexing.GetCollection("PostalCodes");
postalCodes.DropAllIndexes();
	
var fromAalborgC = new QueryDocument
{
	{"countryCode", "DK"}, {"postalCode", 9000}
};
		
postalCodes
	.Find(fromAalborgC)
	.Explain()
	.Dump("without indexes", 3);
	
postalCodes.CreateIndex(IndexKeys.Ascending("countryCode", "postalCode"), IndexOptions.SetName("byPostalCode"));

postalCodes
	.Find(fromAalborgC)
	.Explain()
	.Dump("with index", 3);

var coordinates = new FieldsDocument
{
	{"latitude", true}, {"longitude", true}, {"_id", false}
};
postalCodes
	.Find(fromAalborgC)
	.SetFields(coordinates)
	.Dump("coordinates", 4);