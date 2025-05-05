
using Logic;
using Logic.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Model;
using Model.Repository;
using System.Text;

namespace health_mate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<HealthMateDbContext>(options =>
            {
                options.UseMySql("server=localhost;port=3306;database=health_mate;user=root;password=root;", new MySqlServerVersion(new Version(8,4,3)));
                options.UseLazyLoadingProxies();
                options.EnableSensitiveDataLogging();
            });
            builder.Services.AddTransient<RecipeRepository>();
            builder.Services.AddTransient<CategoryRepository>();
            builder.Services.AddTransient<UserRepository>();

            builder.Services.AddTransient<RecipeMapper>();
            builder.Services.AddTransient<CategoryMapper>();
            builder.Services.AddTransient<UserMapper>();

            builder.Services.AddTransient<RecipeLogic>();
            builder.Services.AddTransient<CategoryLogic>();
            builder.Services.AddTransient<UserLogic>();


            // Add services to the container.

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "your-issuer", // Replace with your issuer
            ValidAudience = "your-audience", // Replace with your audience
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(UserLogic.SECRET_KEY)) // Replace with your key
        };
    });


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
            app.UseDeveloperExceptionPage();

            app.UseAuthorization();


            app.MapControllers();

            app.UseCors(x=>x.AllowCredentials().AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:4200"));
            app.Run();
        }
    }
}
