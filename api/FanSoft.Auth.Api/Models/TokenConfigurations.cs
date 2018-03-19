namespace FanSoft.Auth.Api.Models
{
    public class TokenConfigurations
    {
        //Público
        public string Audience { get; set; }

        //Emissor
        public string Issuer { get; set; }

        //Expiração do Token
        public int Seconds { get; set; }
    }
}
