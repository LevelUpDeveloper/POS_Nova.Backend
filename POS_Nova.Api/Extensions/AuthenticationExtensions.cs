using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using POS_Nova.Api.Responses;
using System.Security.Claims;
using System.Text;

namespace POS_Nova.Api.Extensions
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidAudience = configuration["JwtSettings:Audience"],

                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(
                                configuration["JwtSettings:Key"]!
                            )
                        ),

                        NameClaimType = ClaimTypes.Name,
                        RoleClaimType = ClaimTypes.Role,

                        ClockSkew = TimeSpan.Zero
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnChallenge = async context =>
                        {
                            context.HandleResponse();

                            context.Response.StatusCode =
                                StatusCodes.Status401Unauthorized;

                            context.Response.ContentType =
                                "application/json";

                            await context.Response.WriteAsJsonAsync(
                                new ErrorResponse
                                {
                                    TraceId = context.HttpContext.TraceIdentifier,
                                    StatusCode =
                                        StatusCodes.Status401Unauthorized,
                                    Message =
                                        "Se requiere autenticación."
                                });
                        },

                        OnForbidden = async context =>
                        {
                            context.Response.StatusCode =
                                StatusCodes.Status403Forbidden;

                            context.Response.ContentType =
                                "application/json";

                            await context.Response.WriteAsJsonAsync(
                                new ErrorResponse
                                {
                                    TraceId = context.HttpContext.TraceIdentifier,
                                    StatusCode =
                                        StatusCodes.Status403Forbidden,
                                    Message =
                                        "No tienes permisos para realizar esta operación."
                                });
                        }
                    };
                });

            return services;
        }
    }
}

