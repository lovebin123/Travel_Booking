﻿using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Asp.Versioning.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerGen;

public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
    {
        _provider = provider;
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, new OpenApiInfo
            {
                Title = $"Travel Booking API {description.ApiVersion}",
                Version = description.ApiVersion.ToString(),
                Description="Description for Travel Booking",
            });
        }
    }
}
