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

/*postalCodes.CreateIndex(IndexKeys.GeoSpatialSpherical("loc"));
GeoNearResult<BsonDocument> results = postalCodes.GeoNear(Query.EQ("countryCode", country), longitude, latitude, 5, GeoNearOptions.SetSpherical(true));
results.Hits.Select(h => new
{
	Distance = distanceInKm(h.Distance),
	Name = h.Document["placeName"].AsString,
	PostalCode = h.Document["postalCode"].AsInt32
}).Dump(1);*/

/*postalCodes.CreateIndex(IndexKeys.GeoSpatialSpherical("location"));
var args = new GeoNearArgs
{
	Limit = 5,
	Spherical = true,
	Query = Query.EQ("countryCode", country),
	UniqueDocs = true,
	Near = new GeoNearPoint.Legacy(new XYPoint(longitude, latitude))
	//Near = new GeoNearPoint.GeoJson<GeoJson2DGeographicCoordinates>(new GeoJsonPoint<GeoJson2DGeographicCoordinates>(new GeoJson2DGeographicCoordinates(longitude, latitude)))
};
postalCodes.GeoNear(args)
.Hits.Select(h => new
{
	Distance = distanceInKm(h.Distance),
	Name = h.Document["placeName"].AsString,
	PostalCode = h.Document["postalCode"].AsInt32
}).Dump(1);*/

postalCodes.CreateIndex(IndexKeys.GeoSpatialSpherical("geoLocation"));
var location = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(new GeoJson2DGeographicCoordinates(longitude, latitude));
postalCodes.Find(Query.Near("geoLocation", location)).SetLimit(5).Dump(3);
