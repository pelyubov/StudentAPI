using Microsoft.EntityFrameworkCore;
using StudentAPI.DBcontexts;
using StudentAPI.Services.Implements;
using StudentAPI.Services.Interfaces;

namespace StudentAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //
            //builder.Services.AddSingleton(new ApplicationDbContext());
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<IStudentCourseService, StudentCourseService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
