using Domain.Application.DTOs.Entities;

namespace Domain.Core.Interfaces;

public interface ITaskRepository
{
	Task SaveAsync(TaskDTO task, CancellationToken? cancellationToken = default);
}
