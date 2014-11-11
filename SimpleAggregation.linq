<Query Kind="Program">
  <NuGetReference>mongocsharpdriver</NuGetReference>
  <Namespace>MongoDB.Driver</Namespace>
  <Namespace>MongoDB.Driver.Builders</Namespace>
  <Namespace>System.Globalization</Namespace>
  <Namespace>MongoDB.Bson</Namespace>
</Query>

void Main()
{
	var grades = new MongoDatabase(new MongoClient().GetServer(), "aggregation", new MongoDatabaseSettings())
		.GetCollection<Grade>("Grades");
	
	// average score of exams
	grades.FindAll()
		.SelectMany(g => g.scores)
		.Where(s => s.type.Equals("exam", StringComparison.Ordinal))
		.Average(s => s.score)
		.Dump();
	
	var selectMany = new BsonDocument("$unwind", "$scores");
	var @where = new BsonDocument
	{
		{"$match", new BsonDocument(
			"scores.type" , new BsonDocument(
				"$eq" , "exam"))
		}
	};
	
	var average = new BsonDocument
	{
		{"$group", new BsonDocument
		{
			{"_id" , "exam"},
			{"avg" , new BsonDocument("$avg", "$scores.score")}
		}}
	};
	
	AggregateArgs arguments = new AggregateArgs()
	{
		Pipeline = new BsonDocument[]
		{
			selectMany,
			@where,
			average
		}
	};
	
	grades.Aggregate(arguments)
		.Single()["avg"].AsDouble
		.Dump(2);
}

// Define other methods and classes here
public class Grade
{
	public ObjectId _id { get; set; }
	public int student_id { get; set; }
	public int class_id { get; set; }
	public Score[] scores { get; set; }
}

public class Score
{
	public string type { get; set; }
	public double score { get; set; }
}