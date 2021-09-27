using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace reserverProf
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            /*var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<reserverProf.Models.user, ReserverProf.Models.userEdite>();
            });*/

            /*IMapper mapper = config.CreateMapper();
            var source = new reserverProf.Models.user();
            var dest = mapper.Map<reserverProf.Models.user, ReserverProf.Models.userEdite>() > (reserverProf.Models.user);

             var source = new Source();
             var dest = Mapper.Map<Source, Dest>(source);

             AutoMapper.Map<reserverProf.Models.user, ReserverProf.Models.userEdite>();*/
        }
    }
}
