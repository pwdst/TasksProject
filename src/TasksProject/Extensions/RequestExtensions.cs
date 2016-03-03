namespace TasksProject.Extensions
{
    using System;
    using System.Linq;
    using Microsoft.AspNet.Http;

    public static class RequestExtensions
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            const string requestedWithHeaderkey = "X-Requested-With";

            var requestedWithHeader = request.Headers.Keys.FirstOrDefault(k => k.Equals(requestedWithHeaderkey, StringComparison.OrdinalIgnoreCase));

            if (requestedWithHeader == null)
            {
                return false;
            }

            const string xmlHttpRequest = "XMLHttpRequest";

            return requestedWithHeader.Equals(xmlHttpRequest, StringComparison.OrdinalIgnoreCase);
        }
    }
}