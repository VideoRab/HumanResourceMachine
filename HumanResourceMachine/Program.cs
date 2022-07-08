using HumanResourceMachine.Context;
using HumanResourceMachine.Interfaces.Repository;
using HumanResourceMachine.Interfaces.Service;
using HumanResourceMachine.Middleware;
using HumanResourceMachine.Repositories;
using HumanResourceMachine.Services;
using Microsoft.EntityFrameworkCore;

namespace HumanResourceMachine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<HRMContext>(options => options.UseSqlServer(connection));
            builder.Services.AddScoped<IHumanService, HumanService>();
            builder.Services.AddScoped<IHumanRepository, HumanRepository>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}