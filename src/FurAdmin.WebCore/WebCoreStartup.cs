﻿using Fur;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FurAdmin.WebCore
{
    [AppStartup(700)]
    public sealed class WebCoreStartup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // 注册 JWT 授权
            services.AddJwt<JwtHandler>();
            services.AddCorsAccessor();
            services.AddControllersWithViews().AddInjectWithUnifyResult<YourResultProvider>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // 添加自定义返回类型，需要在这里注册，要先注入【YourResultProvider】
            app.UseUnifyResultStatusCodes();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCorsAccessor();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseInject();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}