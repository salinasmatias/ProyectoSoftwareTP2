using CineGba.AccessData;
using CineGba.AccessData.Commands;
using CineGba.Application.Services;
using CineGba.Application.Validations;
using CineGba.Domain.Commands;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CineGba.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CineGba.Presentation", Version = "v1" });
            });
            var connectionString = Configuration.GetSection("ConnectionString").Value;
            services.AddDbContext<CineContext>(options => options.UseSqlServer(connectionString));
            services.AddTransient<IPeliculasRepository, PeliculasRepository>();
            services.AddTransient<IFuncionesRepository, FuncionesRepository>();
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<IPeliculaService, PeliculaService>();
            services.AddTransient<IFuncionService, FuncionService>();
            services.AddTransient<ITicketService, TicketService>();
            services.AddTransient<IFuncionValidation, FuncionValidation>();
            services.AddAutoMapper(typeof(Startup));
            /*services.AddTransient<ISalaService, SalaService>();
            services.AddTransient<ITicketService, TicketService>();
            */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CineGba.Presentation v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
