using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GoingTo.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; } // Representa a las propiedades de la configuracion de la aplicacion

        public Startup(IConfiguration configuration) // Inyeccion por constructor de las configuraciones
        {
            Configuration = configuration;
        }
    
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) // configuracion de los servicios
        {
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) // Un void que recibe: (Los mecanismos para configurar una peticion de la aplicacion, La informacion del web hosting)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting(); // garantiza las rutas del endpoint

            app.UseAuthorization(); // autorizacoines builder de NetCore

            app.UseEndpoints(endpoints => // para usar los endpoints en las acciones del controlador
            {
                endpoints.MapControllers();
            });
        }
    }
}
