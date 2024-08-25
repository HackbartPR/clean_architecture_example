using Domain.Application.CrossCutting;
using Domain.Application.UseCases.CreatTask;

namespace Domain.Application.Interfaces.UseCases;

public interface ITaskUseCases
{
	Task<BaseResponse<CreateTaskResult?>> Create(CreateTaskCommand command, CancellationToken? cancellationToken = default);
}
