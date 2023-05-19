using FluentValidation;
using StaffProject.Data;
using StaffProject.Schema;
using StaffProject.Service.Extensions;
using StaffProject.Service.Validators;

namespace StaffProject.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen();
            services.AddDbContextExtension(Configuration);
            services.AddTransient<IValidator<StaffRequest>,StaffValidator>();
            services.AddMapperExtension();
            services.AddRepositoryExtension();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DefaultModelsExpandDepth(-1);
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Staff Api");
                c.DocumentTitle = "StaffApi House";
            });

            app.UseHttpsRedirection();

            // add auth 
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
