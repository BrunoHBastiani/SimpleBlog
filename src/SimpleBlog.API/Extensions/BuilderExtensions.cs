using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SimpleBlog.API.Authentication;
using SimpleBlog.API.Notification;
using SimpleBlog.Application.Authentication;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.Services;
using SimpleBlog.Data;
using SimpleBlog.Data.Interfaces;
using SimpleBlog.Data.Repositories;

namespace SimpleBlog.API.Extensions
{
    public static class BuilderExtensions
    {
        public static void AddArchitectures(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();
            builder.Services.AddSignalR();
            builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings"));
            ConfigureSwagger(builder);
            ConfigureAuthentication(builder);

        }

        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<SimpleBlogDbContext>(options =>
            {
                options.UseInMemoryDatabase("simpleblogdb");
            });

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IPostService, PostService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddScoped<IJwtService, JwtService>();
            builder.Services.AddScoped<INotificationService, NotificationService>();
        }

        private static void ConfigureSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SimpleBlog API",
                    Version = "v1",
                    Description = "API para gerenciamento de blog com autenticação JWT."
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header usando o esquema Bearer. \r\n\r\n" +
                                  "Digite 'Bearer' [espaço] e então seu token na caixa de texto abaixo.\r\n\r\n" +
                                  "Exemplo: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        private static void ConfigureAuthentication(this WebApplicationBuilder builder)
        {
            var secret = builder.Configuration["Settings:Secret"];
            var key = Encoding.ASCII.GetBytes(secret);
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}
