<Query Kind="Statements">
  <NuGetReference>mongocsharpdriver</NuGetReference>
  <Namespace>MongoDB.Bson</Namespace>
  <Namespace>MongoDB.Bson.Serialization</Namespace>
  <Namespace>MongoDB.Bson.Serialization.Attributes</Namespace>
  <Namespace>MongoDB.Bson.Serialization.Conventions</Namespace>
  <Namespace>MongoDB.Bson.Serialization.IdGenerators</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>

BsonDocument doc = new BsonDocument();
doc.Dump("empty");

doc = new BsonDocument("key", 42L);
doc.Dump("initialize with one key", 2);
doc.Add("anoter_key", false);
doc.Dump("add property", 2);