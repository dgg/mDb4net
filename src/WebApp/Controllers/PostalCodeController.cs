using MongoDB.Driver;
using Nancy;
using UseDynamicSyntax.Models;

namespace UseDynamicSyntax.Controllers
{
	public class PostalCodeController : NancyModule
	{
		public PostalCodeController()
		{
			var db = new MongoClient().GetServer().GetDatabase("dynamic");

			Get["/static/postal-codes"] = p =>
			{
				var first24 = db.GetCollection("PostalCodes")
					.FindAll().SetLimit(24);

				return View["PostalCode/Static", first24];
			};

			Get["/dynamic/postal-codes"] = p =>
			{
				var first24 = db.GetCollection("PostalCodes")
					.FindAll().SetLimit(24);

				return View["PostalCode/Dynamic", first24.AsDynamic()];
			};
		}
	}
}