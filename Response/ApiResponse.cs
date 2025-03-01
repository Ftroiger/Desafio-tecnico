using System.Net;

namespace Desafio_tecnico.Response
{
    public class ApiResponse<T>
    {
        public T data { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public HttpStatusCode statusCode { get; set; }

        public ApiResponse()
        {
            this.success = true;
            this.message = string.Empty;
            this.statusCode = HttpStatusCode.OK;
        }

        public ApiResponse(T data, bool success, string errorMenssage, HttpStatusCode statusCode)
        {
            this.data = data;
            this.success = success;
            this.message = errorMenssage;
            this.statusCode = statusCode;
        }

        public void SetError(string errorMenssage, HttpStatusCode statusCode)
        {
            this.success = false;
            this.message = errorMenssage;
            this.statusCode = statusCode;
        }

    }
}
