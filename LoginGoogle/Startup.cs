using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoginGoogle.Startup))]
namespace LoginGoogle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
