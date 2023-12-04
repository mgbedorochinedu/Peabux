namespace Peabux.API.ServiceResponse
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }

        public BaseResponse(bool success, object data, string message)
        {
            Success = success;
            Data = data;
            Message = message;
        }
    }
}
