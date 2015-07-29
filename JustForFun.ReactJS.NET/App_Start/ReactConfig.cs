using React;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(JustForFun.ReactJS.NET.ReactConfig), "Configure")]

namespace JustForFun.ReactJS.NET
{
	public static class ReactConfig
	{
		public static void Configure()
        {
            ReactSiteConfiguration.Configuration
                .AddScript("~/Scripts/templates/recipes.jsx")
                .AddScript("~/Scripts/templates/menu.jsx")
                .AddScript("~/Scripts/templates/footer.jsx");
        }
	}
}