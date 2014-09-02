using Nancy;

namespace UseDynamicSyntax
{
	public class IndexModule : NancyModule
	{
		public IndexModule()
		{
			Get["/"] = parameters => "Yo!";

			Get["/index"] = parameters =>
			{
				return View["index", new {Name = "DGG"}];
			};
		}
	}
}