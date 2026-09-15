using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using POS_Nova.Api.Extensions;
using POS_Nova.Api.Responses;
using POS_Nova.Application.Features.Auth.UseCases;
using POS_Nova.Application.Features.Auth.Validators;
using POS_Nova.Application.Features.Products.DTOs;
using POS_Nova.Application.Features.Products.UseCases;
using POS_Nova.Application.Features.Products.Validators;
using POS_Nova.Application.Interfaces.Persistence;
using POS_Nova.Application.Interfaces.Services;
using POS_Nova.Infrastructure.DependencyInjection;
using POS_Nova.Infrastructure.Repositories;
using POS_Nova.Infrastructure.Services;
using System.Security.Claims;
using System.Text;



namespace POS_Nova.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Controllers 
            builder.Services.AddControllers();

            // CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("FrondEndAngular", policy =>
                {
                    policy
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            // Swagger  
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Escribe: Bearer {tu token}"
                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
            {
            {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
            }
            });
            });


            // FluentValidation
            builder.Services.AddValidatorsFromAssemblyContaining<UserRegisterRequestDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<CategoryRegisterRequestDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<DocumentTypeRequestDtoValidator>();
            builder.Services.AddFluentValidationAutoValidation();

            // Use Cases
            builder.Services.AddScoped<LoginService>();
            builder.Services.AddScoped<RegisterUserService>();
            builder.Services.AddScoped<RegisterRoleService>();
            builder.Services.AddScoped<CategoryRegisterService>();
            builder.Services.AddScoped<DocumentTypeRegisterService>();

            // Repositories
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();

            // Services
            builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
            builder.Services.AddScoped<IJwtService, JwtService>();


            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<ICurrentUserService,
                CurrentUserService>();

            // Authentication 
            builder.Services.AddJwtAuthentication(builder.Configuration);


            // Authorization policies
            builder.Services.AddAuthorizationPolicies();
 

            // Database Conection Infraestructura
            builder.Services.AddInfrastructure(builder.Configuration);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

            app.UseCors("FrondEndAngular");

            // Global Exception Handler Middleware
            app.UseGlobalExceptionHandler();


            // Polity Authorization
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
