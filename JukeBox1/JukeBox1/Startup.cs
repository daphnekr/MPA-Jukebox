using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JukeBox1.Startup))]
namespace JukeBox1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
