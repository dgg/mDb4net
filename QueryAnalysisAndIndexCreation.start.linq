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

