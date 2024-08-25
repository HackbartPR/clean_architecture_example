using Domain.Application.DTOs.Entities;

namespace Domain.Core.Interfaces;

public interface ITagRepository
{
	Task<ICollection<TagDTO>> FindByIdListAsync(ICollection<Guid> tagId, CancellationToken? cancellationToken = default);
}
