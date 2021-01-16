using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProductManagement.Service;
using ProductManagement.Data;
using ProductManagement.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace ProductManagement.Api
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
            AddSwagger(services);
            services.AddDbContext<ProductContext>(options => options.UseSqlServer("Data Source=localhost;Initial Catalog=ProductManagement;User Id=sa;Password=sa;"));
            services.AddScoped<IProductQueryService,ProductQueryService>();
            services.AddScoped<IProductCommandService, ProductCommandService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Management API");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        private IServiceCollection AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Product Management Api",
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "Darshana Bansal",
                            Email = "darshana0212@gmail.com"
                        }
                    });

                options.DescribeAllParametersInCamelCase();

             });

            return services;
        }
    }
}
