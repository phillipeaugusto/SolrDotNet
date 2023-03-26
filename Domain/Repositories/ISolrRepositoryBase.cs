using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchText.Domain.Repositories;

public interface ISolrRepository<T>
{
    Task AddOrUpdate(T entity);
    Task<IEnumerable<T>> Search(string fieldSearch, string search);
}