using System.Collections.Generic;
using System.Threading.Tasks;
using SearchText.Domain.Entities;
using SearchText.Domain.Repositories;
using SolrNet;

namespace SearchText.Repository;

public class SolrDocumentRepository: ISolrDocumentRepository
{
    private readonly ISolrOperations<Document> _solr;
    
    public SolrDocumentRepository(ISolrOperations<Document> solr)
    {
        _solr = solr;
    }

    public async Task AddOrUpdate(Document entity)
    {
        await _solr.AddAsync(entity);
        await _solr.CommitAsync();
    }

    public async Task<IEnumerable<Document>> Search(string fieldSearch, string search)
    {
        var list = await _solr.QueryAsync(new SolrQuery(fieldSearch + ":" + search));
        return list;
   }
}
