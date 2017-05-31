using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SriSaiVedaGayatri.Startup))]
namespace SriSaiVedaGayatri
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
