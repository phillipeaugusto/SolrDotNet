using Flunt.Notifications;
using Flunt.Validations;
using SearchText.Domain.Command.Contracts;
using static System.String;

namespace SearchText.Domain.Command;

public class TextSearchCommand: Notifiable, IValidator
{
    public TextSearchCommand(string searchText, string searchField)
    {
        SearchText = searchText;
        SearchField = searchField;
    }

    public string SearchText { get; set; }
    public string SearchField { get; set; }
    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .IsFalse(SearchText == Empty, "Search Text", "Search Text is Empty")
                .IsFalse(SearchField == Empty, "Search Field", "Search Field is Empty")
        );
    }
}