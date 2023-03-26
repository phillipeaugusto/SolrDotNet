using System;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using SearchText.Domain.Command;
using SearchText.Domain.Entities;
using SearchText.Domain.Repositories;
using SearchText.Domain.Shared;
using SearchText.Services.Contracts;
using static System.String;
using IResult = SearchText.Domain.Shared.Contracts.IResult;

namespace SearchText.Services;

public class DocumentService: 
    Notifiable,
    IService<PdfInputCommand>,
    IService<TextInputCommand>,
    IService<TextSearchCommand>
{
    private readonly ISolrDocumentRepository _solrDocumentRepository;

    public DocumentService(ISolrDocumentRepository solrDocumentRepository)
    {
        _solrDocumentRepository = solrDocumentRepository;
    }

    public async Task<IResult> Service(PdfInputCommand action)
    {
        action.Validate();
        if (action.Invalid) 
            return await Result.ResultAsync(false, "Error", action.Notifications);
        
        using var leitor = new PdfReader(action.PdfInputDto.File.OpenReadStream());
        var textPdf = new StringBuilder();
        
        for (var i = 1; i <= leitor.NumberOfPages; i++) 
            textPdf.Append(PdfTextExtractor.GetTextFromPage(leitor, i));

        await _solrDocumentRepository.AddOrUpdate(new Document(Guid.NewGuid().ToString(), leitor.ToString()));
        return await Result.ResultAsync(true, "Successfully Inserted PDF Text!");
    }

    public async Task<IResult> Service(TextInputCommand action)
    {
        action.Validate();
        if (action.Invalid) 
            return await Result.ResultAsync(false, "Error", action.Notifications);
        
        await _solrDocumentRepository.AddOrUpdate(new Document(Guid.NewGuid().ToString(), action.TextInputDto.Text));
        return await Result.ResultAsync(true, "Successfully Inserted Text!");
    }

    public async Task<IResult> Service(TextSearchCommand action)
    {
        action.Validate();
        if (action.Invalid) 
            return await Result.ResultAsync(false, "Error", action.Notifications);

        var list = await _solrDocumentRepository.Search(action.SearchField, action.SearchText);
        return await Result.ResultAsync(true, Empty, list);
    }
}