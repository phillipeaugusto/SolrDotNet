using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SearchText.Domain.Entities;
using SolrNet;

namespace SearchText.Extensions;

public static class ServicesCloudExtension
{
    public static void SolrInitialization(this IServiceCollection services, IConfiguration configuration)
    {
        var url =  !string.IsNullOrEmpty(configuration["Solr:Url"]) ? configuration["Solr:Url"] : Environment.GetEnvironmentVariable("SolrUrl");
        var core =  !string.IsNullOrEmpty(configuration["Solr:Core"]) ? configuration["Solr:Core"] : Environment.GetEnvironmentVariable("SolrCore");
        var port =  !string.IsNullOrEmpty(configuration["Solr:Port"]) ? configuration["Solr:Port"] : Environment.GetEnvironmentVariable("SolrPort");
        var urlBase = url + ":" + port + "/solr/" + core;
        services.AddSolrNet<Document>(urlBase);
    }
}