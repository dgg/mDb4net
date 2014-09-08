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

doc = new BsonDocument("key", new BsonInt32(42));
doc.Dump("initilize with one key", 2);