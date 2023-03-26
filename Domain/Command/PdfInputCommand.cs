using Flunt.Notifications;
using Flunt.Validations;
using SearchText.Domain.Command.Contracts;
using SearchText.Dto.Input;

namespace SearchText.Domain.Command;

public class PdfInputCommand: Notifiable, IValidator
{
    public PdfInputCommand(PdfInputDto pdfInputDto)
    {
        PdfInputDto = pdfInputDto;
    }

    public PdfInputDto PdfInputDto { get; set; }
    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .IsFalse(PdfInputDto.File is null, "Pdf", "Pdf, Invalid!")
        );
    }
}