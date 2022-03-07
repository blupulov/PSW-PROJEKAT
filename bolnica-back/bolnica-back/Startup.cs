using bolnica_back.Interfaces;
using bolnica_back.Model;
using bolnica_back.Repositories;
using bolnica_back.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace bolnica_back
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
            //Enable CORS
            services.AddCors(c => c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            //Database
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();
            //Dependency injection
            this.RepositoryDependencieInjection(services);

            this.ServiceDependencieInjection(services);
        }

        private void RepositoryDependencieInjection(IServiceCollection services) 
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IReviewRatingRepository, ReviewRatingRepository>();
            services.AddTransient<ISurveyRepository, SurveyRepository>();
        }

        private void ServiceDependencieInjection(IServiceCollection services)
        {
            services.AddTransient<UserService, UserService>();
            services.AddTransient<DoctorService, DoctorService>();
            services.AddTransient<ReviewService, ReviewService>();
            services.AddTransient<ReviewRatingService, ReviewRatingService>();
            services.AddTransient<SurveyService, SurveyService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Enable CORS
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
