<Query Kind="Statements">
  <NuGetReference>mongocsharpdriver</NuGetReference>
  <Namespace>MongoDB.Bson</Namespace>
  <Namespace>MongoDB.Driver</Namespace>
  <Namespace>MongoDB.Driver.Linq</Namespace>
  <Namespace>System.Globalization</Namespace>
  <Namespace>MongoDB.Driver.Builders</Namespace>
  <Namespace>MongoDB.Driver.GeoJsonObjectModel</Namespace>
</Query>

MongoClient client = new MongoClient(new MongoUrl("mongodb://localhost:27017"));
MongoDatabase indexing = client.GetServer().GetDatabase("geoQueries");
MongoCollection<BsonDocument> postalCodes = indexing.GetCollection("PostalCodes");
postalCodes.DropAllIndexes();

string country = "DK";
double longitude = 9.897514, latitude = 57.053722;
const double EARTH_RADIUS_KM = 6378.137;
Func<double, double> distanceInKm = d => d * EARTH_RADIUS_KM;