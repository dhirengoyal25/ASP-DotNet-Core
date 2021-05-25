using AttendanceSystem.Api.Middlewares;
using AttendanceSystem.Persistent.Configurations;
using AttendanceSystem.Persistent.Contracts;
using AttendanceSystem.Persistent.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AttendanceSystem.Api
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

			MapServices(services);

			var connectionString = Configuration.GetConnectionString("DefaultConnectionString");
			services.AddDbContext<IRelationalDbContext, SqlDbContext>(o => o.UseSqlServer(connectionString));

			services.AddDatabaseDeveloperPageExceptionFilter();

			services.AddMvc(op => op.EnableEndpointRouting = false);

			services.AddSwaggerGen();

			services.AddSwaggerGenNewtonsoftSupport();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseMiddleware<ExceptionHandlingMiddleware>();

			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Attendance System API V1");
			});

			app.UseAuthorization();

			app.UseMvcWithDefaultRoute();
		}

		private void MapServices(IServiceCollection services)
		{
			services.AddTransient<IUserAccountRepositioryService, UserAccountRepositioryService>();
			services.AddTransient<IEmployeeDetailsService, EmployeeDetailsService>();
			services.AddTransient<IAttendanceRecordService, AttendanceRecordService>();
		}
	}
}
