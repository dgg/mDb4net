using System;
using System.Text;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Options;

namespace BsonSerialization.Sample
{
	internal class WeirdEnumCaseSerializer : IBsonSerializer
	{
		public object Deserialize(BsonReader bsonReader, Type nominalType, IBsonSerializationOptions options)
		{
			return null;
		}

		public object Deserialize(BsonReader bsonReader, Type nominalType, Type actualType, IBsonSerializationOptions options)
		{
			string value = bsonReader.ReadString();
			return Enum.Parse(nominalType, value, ignoreCase: true);
		}

		public IBsonSerializationOptions GetDefaultSerializationOptions()
		{
			return DocumentSerializationOptions.Defaults;
		}

		public void Serialize(BsonWriter bsonWriter, Type nominalType, object value, IBsonSerializationOptions options)
		{
			var sb = new StringBuilder(value.ToString());
			for (int i = 0; i < sb.Length; i++)
			{
				if (even(i)) sb[i] = char.ToLowerInvariant(sb[i]);
				else sb[i] = char.ToUpperInvariant(sb[i]);
			}
			bsonWriter.WriteString(sb.ToString());
		}

		private bool even(int i)
		{
			return i%2 == 0;
		}
	}
}