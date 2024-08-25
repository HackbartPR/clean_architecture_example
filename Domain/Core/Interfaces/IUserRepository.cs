using Domain.Core.DTOs.Entities;

namespace Domain.Core.Interfaces;

public interface IUserRepository
{
    Task<UserDTO> FindByIdAsync(Guid userId, CancellationToken? cancellationToken = default);
}
