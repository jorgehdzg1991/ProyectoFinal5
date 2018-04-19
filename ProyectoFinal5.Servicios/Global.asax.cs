using System.Web;
using System.Web.Http;

namespace ProyectoFinal5.Servicios
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
