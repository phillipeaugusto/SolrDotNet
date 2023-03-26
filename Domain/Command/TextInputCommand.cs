using Flunt.Notifications;
using Flunt.Validations;
using SearchText.Domain.Command.Contracts;
using SearchText.Dto.Input;
using static System.String;

namespace SearchText.Domain.Command;

public class TextInputCommand: Notifiable, IValidator
{
    public TextInputCommand(TextInputDto textInputDto)
    {
        TextInputDto = textInputDto;
    }

    public TextInputDto TextInputDto { get; set; }
    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .IsFalse(TextInputDto.Text == Empty, "Text", "Text is Empty!")
        );
    }
}