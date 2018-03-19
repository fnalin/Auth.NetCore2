using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace FanSoft.Auth.Api.Models
{
    public class SigningConfigurations
    {
        //Armazena a chave de criptografia utilizada na criação de tokens
        public SecurityKey Key { get; }

        //Contêm a chave de criptografia e o algoritmo de segurança empregados na geração de assinaturas digitais para tokens;
        public SigningCredentials SigningCredentials { get; }

        public SigningConfigurations()
        {
            //Determinando o o uso do padrão RSA como algoritmo de criptografia usado na produção de tokens.

            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(
                Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
