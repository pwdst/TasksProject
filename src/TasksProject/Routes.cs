namespace TasksProject
{
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Routing;

    internal static class Routes
    {
        internal static void MapRoutes(IRouteBuilder routes)
        {
            routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
