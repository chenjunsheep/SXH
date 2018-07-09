using System.Net;

namespace Sxh.Shared.Response
{
    public class SxhResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public SxhResult()
        {
            IsSuccess = false;
        }
        public SxhResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
            if (!IsSuccess)
            {
                Message = "unexpected error";
            }
        }
        public SxhResult(bool isSuccess, object data)
        {
            IsSuccess = isSuccess;
            Data = data;
        }
        public SxhResult(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
        public SxhResult(bool isSuccess, HttpStatusCode code)
        {
            IsSuccess = isSuccess;
            Message = $"status code {(int)code}";
        }
    }
}
