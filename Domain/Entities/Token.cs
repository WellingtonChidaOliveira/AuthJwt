namespace Domain.Entities
{
    public class Token
    {
        public bool Authenticated { get; set; } = false;
        public string AccessToken { get; set; } = string.Empty;
        public string Created { get; set; } = string.Empty;
        public string Expiration { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
