using System.Threading.Tasks;
using SearchText.Domain.Command.Contracts;
using IResult = SearchText.Domain.Shared.Contracts.IResult;

namespace SearchText.Services.Contracts;

public partial interface IService<in T> where T : IValidator
{
    Task<IResult> Service(T action);
}