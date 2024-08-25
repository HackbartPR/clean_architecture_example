namespace Domain.Application.CrossCutting;

public class BaseResponse<T>(bool success, T data, string message)
{
	public bool Success { get; set; } = success;
	public T? Data { get; set; } = data;
	public string Message { get; set; } = message;
}
