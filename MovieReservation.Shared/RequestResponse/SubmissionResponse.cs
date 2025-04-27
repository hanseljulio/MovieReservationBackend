using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace MovieReservation.Shared.RequestResponse
{
    public class SubmissionResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }

        public SubmissionResponse(bool success, string message, T? data = default)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public static SubmissionResponse<T> SuccessResponse(string message, T? data = default)
        {
            return new SubmissionResponse<T>(true, message, data);
        }

        public static SubmissionResponse<T> ErrorResponse(string message)
        {
            return new SubmissionResponse<T>(false, message);
        }
    }
}
