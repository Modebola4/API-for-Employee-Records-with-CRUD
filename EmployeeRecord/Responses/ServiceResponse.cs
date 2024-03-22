namespace EmployeeRecord.Responses
{
    public class ServiceResponse<T> where T : class //configure this class to accept a generic type
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

    }
}
