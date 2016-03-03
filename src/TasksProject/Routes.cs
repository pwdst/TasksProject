namespace TasksProject
{
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Routing;

    internal static class Routes
    {
        internal static void MapRoutes(IRouteBuilder routes)
        {
            routes.MapRoute(
                    name: "TasksList",
                    template: "{controller=Tasks}/{action=List}/");
        }
    }
}
