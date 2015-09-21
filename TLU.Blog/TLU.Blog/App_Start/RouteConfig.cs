using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TLU.Blog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                name: "AutoListComment",
                url: "AutoListComment/{pPostId}",
                defaults: new { controller = "Home", action = "AutoListComment", pPostId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CountComment",
                url: "CountComment/{pPostId}",
                defaults: new { controller = "Home", action = "CountComment", pPostId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "New_Comment",
                url: "New_Comment/{pContent}/{pPostId}",
                defaults: new { controller = "Home", action = "ViewComment", pContent = UrlParameter.Optional, pPostId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ViewReply",
                url: "ViewReply/{pReplyContent}/{pCommentId}",
                defaults: new { controller = "Home", action = "ViewReply", pReplyContent = UrlParameter.Optional, pCommentId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
