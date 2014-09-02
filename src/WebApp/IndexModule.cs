using Nancy;

namespace UseDynamicSyntax
{
	public class IndexModule : NancyModule
	{
		public IndexModule()
		{
			Get["/"] = parameters => "Yo!";
		}
	}
}