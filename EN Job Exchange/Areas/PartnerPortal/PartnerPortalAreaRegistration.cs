using System.Web.Mvc;

namespace ENJobExchange.Areas.PartnerPortal
{
    public class PartnerPortalAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "PartnerPortal";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "PartnerPortal_default",
                "PartnerPortal/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "ENJobExchange.Areas.PartnerPortal.Controllers" }

            );
        }
    }
}
