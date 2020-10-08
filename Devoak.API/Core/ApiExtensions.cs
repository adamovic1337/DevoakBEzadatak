using AutoMapper;
using Devoak.Application.Commands;
using Devoak.Application.Queries;
using Devoak.DataAccess;
using Devoak.Implementation.AutoMapperProfiles;
using Devoak.Implementation.Commands;
using Devoak.Implementation.Queries;
using Devoak.Implementation.Validation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Devoak.API.Core
{
    public static class ApiExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddTransient<DevoakContext>();
            services.AddTransient<FakerData>();
            services.AddAutoMapper(typeof(UserProfile).Assembly);
            services.AddControllers();
        }

        public static void AddAllValidators(this IServiceCollection services)
        {
            services.AddTransient<UserValidation>();
            services.AddTransient<RestaurantValidation>();
            services.AddTransient<RatingValidation>();
        }

        public static void AddAllCommands(this IServiceCollection services)
        {
            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
            services.AddTransient<ICreateRestaurantCommand, CreateRestaurantCommand>();
            services.AddTransient<ICreateRatingCommand, CreateRatingCommand>();

            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<IUpdateRestaurantCommand, UpdateRestaurantCommand>();

            services.AddTransient<IDeleteUserCommand, SoftDeleteUserCommand>();
            services.AddTransient<IDeleteRestaurantCommand, SoftDeleteRestaurantCommand>();
        }

        public static void AddAllQueries(this IServiceCollection services)
        {
            services.AddTransient<IGetUserQuery, GetUserQuery>();
            services.AddTransient<IGetUsersQuery, GetUsersQuery>();

            services.AddTransient<IGetRestaurantQuery, GetRestaurantQuery>();
            services.AddTransient<IGetRestaurantsQuery, GetRestaurantsQuery>();
        }

        public static void AddSwaggerToProject(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Devoak BE zadatak", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,

                            },
                            new List<string>()
                        }
                    });
                }
            );
        }
    }
}
