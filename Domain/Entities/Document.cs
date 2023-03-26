using SolrNet.Attributes;

namespace SearchText.Domain.Entities;

public class Document
{
    public Document() { }

    public Document(string id, string fieldForSearch)
    {
        FieldForSearch = fieldForSearch;
        Id = id;
    }

    [SolrField("FieldForSearch")]
    public string FieldForSearch { get; set; }
    
    [SolrUniqueKey("id")]
    public string Id { get; set; }
}