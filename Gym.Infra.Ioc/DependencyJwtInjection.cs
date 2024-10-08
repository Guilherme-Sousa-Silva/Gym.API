﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Gym.Infra.Ioc
{
    public static class DependencyJwtInjection
    {
        public static IServiceCollection addJwtStructure(this IServiceCollection services, IConfiguration configuration)
        {
            //informar o tipo de autenticação JWT-Bearer
            //definir modelo de desafio de autenticação
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            //habilitar a autenticação JWT usando o esquema e desafio definidos
            //validar o token
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            // Definição da política de autorização
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RepresentantePolicy", policy =>
                    policy.RequireRole(Roles.Representante));

                options.AddPolicy("AdminPolicy", policy =>
                    policy.RequireRole(Roles.Administrador));
            });

            return services;
        }
    }
}

