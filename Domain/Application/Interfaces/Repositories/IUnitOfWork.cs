using Domain.Core.Interfaces;

namespace Domain.Application.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }

    ITaskRepository TaskRepository { get; }

    ITagRepository TagRepository { get; }

    Task<int> CommitAsync(CancellationToken? cancellationToken = default);
}
