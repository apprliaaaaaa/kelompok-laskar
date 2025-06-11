using Laskar.Shared.Models;
using Laskar.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ManajemenAkunGuru.Services;

namespace Laskar.API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Registrasi service yang dibutuhkan
            services.AddSingleton<LoginAutomataService>();
            services.AddSingleton<RuntimeConfigService>();
            services.AddSingleton<PerkembanganService>();
            services.AddSingleton<GuruService>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(); // untuk dokumentasi API
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
