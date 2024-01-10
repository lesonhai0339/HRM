using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CleanArchitecture.Configuration
{
    public static class ApplicationSecurityConfiguration
    {
        public static IServiceCollection ConfigureApplicationSecurity(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient<ICurrentUserService, CurrentUserService>();
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
            services.AddHttpContextAccessor();
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.SaveToken = true;
                option.RequireHttpsMetadata = false;
                //JwtBearer
                option.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    RequireExpirationTime = true,
                    ValidIssuer = configuration["Security.Bearer:Authority"],
                    ValidAudience = configuration["Security.Bearer:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Security.Bearer:Secret"]!))
                };
            });
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(
            //        JwtBearerDefaults.AuthenticationScheme,
            //        options =>
            //        {
            //            options.Authority = configuration.GetSection("Security.Bearer:Authority").Get<string>();
            //            options.Audience = configuration.GetSection("Security.Bearer:Audience").Get<string>();

            //            options.TokenValidationParameters.RoleClaimType = "role";
            //        });
            services.AddAuthorization(ConfigureAuthorization);


            return services;
        }


        private static void ConfigureAuthorization(AuthorizationOptions options)
        {
            //Configure policies and other authorization options here. For example:
            options.AddPolicy("CustomerOnly", policy => policy.RequireClaim("role", "Customer"));
            options.AddPolicy("AdminOnly", policy => policy.RequireClaim("role", "Admin"));
            options.AddPolicy("VendorOnly", policy => policy.RequireClaim("role", "Vendor"));
        }
    }
}
