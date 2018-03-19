using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace FanSoft.Auth.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors();
            services.AddScoped(typeof(Data.EF.FanSoftAuthDataContext));
            services.AddTransient(typeof(Domain.Contracts.Data.IUnitOfWork), typeof(Data.EF.UnitOfWork));
            services.AddTransient<Domain.Contracts.Repositories.IClienteRepository, Data.EF.Repositories.ClienteRepository>();
            services.AddTransient<Domain.Contracts.Repositories.IUsuarioRepository, Data.EF.Repositories.UsuarioRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Data.EF.FanSoftAuthDataContext ctx)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                Data.EF.DbInitialize.Initialize(ctx);
            }

            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
            });

            app.UseMvc();

            app.Run(async (context) =>
            {
                context.Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                context.Response.Headers.Add("content-type", "text/html; charset=utf-8");
                await context.Response.WriteAsync("Recurso não encontrado");
            });
        }
    }
}
