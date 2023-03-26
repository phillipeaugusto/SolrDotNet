using Microsoft.Extensions.DependencyInjection;
using SearchText.Domain.Repositories;
using SearchText.Repository;
using SearchText.Services;

namespace SearchText.Extensions;

public static class ServicesExtension
{
    public static void ServicesInitialization(this IServiceCollection services)
    {
        services.AddTransient<ISolrDocumentRepository, SolrDocumentRepository>();
        services.AddTransient<DocumentService, DocumentService>();
    }
}