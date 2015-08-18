using System.Web.Mvc;

namespace ENJobExchange.Areas.ENPortal
{
    public class ENPortalAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ENPortal";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ENPortal_default",
                "ENPortal/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "ENJobExchange.Areas.ENPortal.Controllers" }
            );
        }
    }
}
