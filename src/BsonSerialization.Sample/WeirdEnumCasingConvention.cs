using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;

namespace BsonSerialization.Sample
{
	internal class WeirdEnumCasingConvention : IMemberMapConvention
	{
		public string Name { get { return "Weird Casing"; } }

		public void Apply(BsonMemberMap memberMap)
		{
			if (memberMap.MemberType.IsEnum)
			{
				memberMap.SetSerializer(new WeirdEnumCaseSerializer());
			}
		}
	}
}