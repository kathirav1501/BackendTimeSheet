namespace BackendEss.Model
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }

        public bool IsSucess { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}
