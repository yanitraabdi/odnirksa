using System.Web.Mvc;

namespace Askrindo.Areas.RCSA
{
    public class RCSAAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "RCSA";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "RCSA_default",
                "RCSA/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}