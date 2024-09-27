
using Billing_System.BuissnessLogic.Interfaces;
using Billing_System.BuissnessLogic.Services;
using BillingSystem.DataAccess.Context;
using BillingSystem.DataAccess.Interfaces;
using BillingSystem.DataAccess.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using model.models;
using System.Text;

namespace BillingSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
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
            builder.Services.AddScoped<IItemService, Itemervices>();
            builder.Services.AddScoped<IInvoiceService, InvoiceService>();

            builder.Services.AddScoped<IUnitService, UnitService>();

            //Identity 
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(o =>
            {
                o.Password.RequireUppercase = false;
                o.Password.RequireLowercase = false;

            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            //JWT Configurations
            //For Authentication
            builder.Services.AddAuthentication(options =>
            {
                /*This specifies that JWT Bearer authentication will be used as the default 
                 authentication scheme for authenticating and challenging requests.*/
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                // instructs the middleware to save the token in the
                // authentication properties after a successful authentication.
                options.SaveToken = true;
                //allows the use of HTTP (non-HTTPS) requests for token validation. 
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
                };
            });

            builder.Services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("MyPolicy", CorsPolicyBuilder =>
                {
                    CorsPolicyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Auth API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {{
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new string[]{}
                    }
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
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
