using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rental_Movie.Startup))]
namespace Rental_Movie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
