using Adapters.CrossCutting;
using Domain.Application.CrossCutting;
using Domain.Application.Interfaces.UseCases;
using Domain.Application.UseCases.CreatTask;
using System.Net;

namespace Adapters.Presenters;

internal class CreateTaskPresenter(ITaskUseCases taskUseCases)
{
	private readonly ITaskUseCases taskUseCases = taskUseCases ?? throw new ArgumentNullException(nameof(taskUseCases));

	public async Task<WebBaseResponse<CreateTaskResult?>> Create(CreateTaskCommand command, CancellationToken cancellationToken = default)
	{
		BaseResponse<CreateTaskResult?> result = await taskUseCases.Create(command, cancellationToken);

		if (!result.Success)
			return new WebBaseResponse<CreateTaskResult?>(result.Success, result.Data, HttpStatusCode.NotFound, result.Message);

		return new WebBaseResponse<CreateTaskResult?>(result.Success, result.Data, HttpStatusCode.Created, result.Message);
	}
}
