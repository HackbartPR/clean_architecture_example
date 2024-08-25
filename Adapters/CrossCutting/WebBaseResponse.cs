using System.Net;

namespace Adapters.CrossCutting;

public class WebBaseResponse<T>(bool success, T data, HttpStatusCode statusCode, string message)
{
	public bool Success { get; set; } = success;
	public T Data { get; set; } = data;
	public HttpStatusCode StatusCode { get; set; } = statusCode;
	public string Message { get; set; } = message;
}
