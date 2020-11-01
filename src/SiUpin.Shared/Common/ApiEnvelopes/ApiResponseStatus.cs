namespace SiUpin.Shared.Common.ApiEnvelopes
{
    public class ApiResponseStatus
    {
        public bool IsError { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
    }
}