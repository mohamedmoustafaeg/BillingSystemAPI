
using Billing_System.BuissnessLogic.Interfaces;
using Billing_System.BuissnessLogic.Services;
using BillingSystem.DataAccess.Context;
using BillingSystem.DataAccess.Interfaces;
using BillingSystem.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using model.models;
using System.Text.Json.Serialization;

namespace BillingSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddJsonOptions(x =>
  x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("Default"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            });
            //
            builder.Services.AddScoped<ApplicationDbContext>();
            builder.Services.AddScoped<IBaseRepository<Client>, BaseRepository<Client>>();
            builder.Services.AddScoped<IBaseRepository<Company>, BaseRepository<Company>>();
            builder.Services.AddScoped<IBaseRepository<Employee>, BaseRepository<Employee>>();
            builder.Services.AddScoped<IBaseRepository<Invoice>, BaseRepository<Invoice>>();
            builder.Services.AddScoped<IBaseRepository<Item>, BaseRepository<Item>>();
            builder.Services.AddScoped<IBaseRepository<ItemInvoice>, BaseRepository<ItemInvoice>>();
            builder.Services.AddScoped<IBaseRepository<model.models.Type>, BaseRepository<model.models.Type>>();
            builder.Services.AddScoped<IBaseRepository<Unit>, BaseRepository<Unit>>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services
            builder.Services.AddScoped<ICompanyService, CompanyService>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<ITypeService, TypeService>();

            builder.Services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("MyPolicy", CorsPolicyBuilder =>
                {
                    CorsPolicyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseCors("MyPolicy");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
