using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SignalTest.Startup))]
namespace SignalTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
