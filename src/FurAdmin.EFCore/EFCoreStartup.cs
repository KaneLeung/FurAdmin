using Fur;
using Fur.DatabaseAccessor;
using Microsoft.Extensions.DependencyInjection;

namespace FurAdmin.EFCore
{
    [AppStartup(600)]
    public sealed class EFCoreStartup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabaseAccessor(options =>
            {
                options.AddDbPool<FurDbContext>(DbProvider.Sqlite);
            });
        }
    }
}