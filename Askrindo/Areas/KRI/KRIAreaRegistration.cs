using System.Web.Mvc;

namespace Askrindo.Areas.KRI
{
    public class KRIAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "KRI";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "KRI_default",
                "KRI/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}