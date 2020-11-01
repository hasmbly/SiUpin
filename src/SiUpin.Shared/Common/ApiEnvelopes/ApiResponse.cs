namespace SiUpin.Shared.Common.ApiEnvelopes
{
    public class ApiResponse<T>
    {
        public ApiResponseStatus Status { get; set; }

        public T Result { get; set; }
    }
}