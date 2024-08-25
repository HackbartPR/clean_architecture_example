using Adapters.CrossCutting;
using Domain.Application.UseCases.CreatTask;

namespace Adapters.Interfaces;

public interface ICreateTaskPresenter
{
	Task<WebBaseResponse<CreateTaskResult?>> Create(CreateTaskCommand command, CancellationToken cancellationToken = default);
}
