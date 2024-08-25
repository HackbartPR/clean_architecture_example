using Domain.Application.CrossCutting;
using Domain.Application.DTOs.Entities;
using Domain.Application.Interfaces.Repositories;
using Domain.Application.Interfaces.UseCases;
using Domain.Core.DTOs.Entities;
using Domain.Core.Entities;

namespace Domain.Application.UseCases.CreatTask;

internal class CreateTaskHandle(IUnitOfWork unit) : ITaskUseCases
{
    private readonly IUnitOfWork _unit = unit ?? throw new ArgumentNullException(nameof(unit));

	public async Task<BaseResponse<CreateTaskResult?>> Create(CreateTaskCommand command, CancellationToken? cancellationToken = default)
    {
        UserDTO userDto = await _unit.UserRepository.FindByIdAsync(command.UserId, cancellationToken);
        if (userDto == null)
            return new BaseResponse<CreateTaskResult?>(false, null, "Usuário não encontrado");

        ICollection<TagDTO> tagsDto = await _unit.TagRepository.FindByIdListAsync(command.TagsId, cancellationToken);
        ICollection<Tag> tags = TagMapping(tagsDto);

        Core.Entities.Task task = new(command.Title, command.Description, command.DueDate, command.Priority, tags);
        TaskDTO taskDto = new(task.Id, task.Title, task.Description, task.IsCompleted, task.DueDate, task.CreatedDate, task.Priority, tagsDto);
        await _unit.TaskRepository.SaveAsync(taskDto, cancellationToken);
        await _unit.CommitAsync(cancellationToken);

        return new BaseResponse<CreateTaskResult?>(true, new CreateTaskResult(command.UserId, taskDto), "Task criada com sucesso");
    }

    private ICollection<Tag> TagMapping(ICollection<TagDTO> tags)
        => tags.Select(t => new Tag(t.Name, t.Color, t.Id)).ToList();
}
