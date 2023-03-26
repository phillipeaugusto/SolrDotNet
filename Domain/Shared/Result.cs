using System.Threading.Tasks;
using SearchText.Domain.Shared.Contracts;

namespace SearchText.Domain.Shared;

public static class Result
{
    public static Task<IResult> ResultAsync(bool success, string message = "", object data = null)
    {
        return Task.FromResult<IResult>(new GenericResult(success, message, data));
    }
}