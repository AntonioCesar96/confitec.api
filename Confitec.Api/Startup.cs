using Confitec.Domain.Commands;
using Confitec.Domain.Handlers;
using Confitec.Domain.Handlers.Contracts;
using Confitec.Domain.Repositories;
using Confitec.Infra.AutoMapper;
using Confitec.Infra.Consultation;
using Confitec.Infra.Contexts;
using Confitec.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Confitec.Api
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
            services.AddControllers().AddNewtonsoftJson();

            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("dataBase")));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ISchoolingRepository, SchoolingRepository>();
            services.AddTransient<IUserConsultation, UserConsultation>();
            services.AddTransient<ISchoolingConsultation, SchoolingConsultation>();
            services.AddTransient<IHandler<CreateUserCommand>, CreateUserHandler>();
            services.AddTransient<IHandler<UpdateUserCommand>, UpdateUserHandler>();
            services.AddTransient<IHandler<DeleteUserCommand>, DeleteUserHandler>();

            services.AddAutoMapper();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
