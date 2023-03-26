namespace SearchText.Dto.Input;

public class TextInputDto
{
    public TextInputDto() { }

    public TextInputDto(string text)
    {
        Text = text;
    }

    public string Text { get; set; }
}
 