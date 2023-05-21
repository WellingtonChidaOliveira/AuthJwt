namespace Domain.Entities
{
    public class TokenConfigurations
    {
        public string Audience { get; set; } = string.Empty;

        public string Issuer { get; set; } = string.Empty;

        public int Seconds { get; set; } = 0;
        
        public string Secret { get; set; } = string.Empty;


    }
}
