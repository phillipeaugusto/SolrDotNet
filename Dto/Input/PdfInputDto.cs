using Microsoft.AspNetCore.Http;

namespace SearchText.Dto.Input;

public class PdfInputDto
{
    public PdfInputDto() { }
    public PdfInputDto(IFormFile file)
    {
        File = file;
    }

    public IFormFile File { get; set; }
    
}