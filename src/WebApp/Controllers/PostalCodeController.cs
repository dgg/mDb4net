using MongoDB.Driver;
using Nancy;

namespace UseDynamicSyntax.Controllers
{
	public class PostalCodeController : NancyModule
	{
		public PostalCodeController()
		{
			var db = new MongoClient().GetServer().GetDatabase("dynamic");

			Get["/postal-codes"] = p =>
			{
				var first24 = db.GetCollection("PostalCodes").FindAll().SetLimit(24);

				return View["PostalCode/Index", first24];
			};
		}
	}
}