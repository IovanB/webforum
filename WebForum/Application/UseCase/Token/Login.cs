using Application.Repositories.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using WebForum.Application.Repositories;
using WebForum.Domain.Entities;

namespace WebForum.Application.UseCase.Token
{
    public class Login : ITokenRepository
    {
        private IUserReadOnlyUseCase userReadOnlyUseCase;
        private SigningConfigurations signingConfigurations;
        private TokenConfiguration tokenConfiguration;

        public Login(IUserReadOnlyUseCase userReadOnlyUseCase,
            SigningConfigurations signingConfigurations,
            TokenConfiguration tokenConfiguration)
        {
            this.userReadOnlyUseCase = userReadOnlyUseCase;
            this.signingConfigurations = signingConfigurations;
            this.tokenConfiguration = tokenConfiguration;
        }

        public object GetByName(string name, string password)
        {
            bool credentialIsValid = false;
            var user = userReadOnlyUseCase.GetByName(name,password);

            if (user != null && !string.IsNullOrEmpty(user.Name))
            {
                var baseUser = userReadOnlyUseCase.GetByName(user.Name, user.Password);
                credentialIsValid = (baseUser != null && user.Name == baseUser.Name && user.Password == baseUser.Password && user.Email == baseUser.Email 
                    && user.Birthday == baseUser.Birthday && user.CreatedAt == baseUser.CreatedAt
                    && user.UpdatedAt == baseUser.UpdatedAt && user.UpdatedAt == baseUser.UpdatedAt
                    );
            }
            if(credentialIsValid)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.Name, "Name"),
                        new []
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.Name)
                        }
                    );
                DateTime createDate = DateTime.Now;
                DateTime expiration = createDate + TimeSpan.FromSeconds(tokenConfiguration.Seconds);

                var handler = new JwtSecurityTokenHandler();
                string token = CreateToken(identity, createDate, expiration, handler);

                return SuccessObject(createDate, expiration, token);
            }
            else
            {
                return ExceptionObject();
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expiration, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Issuer = tokenConfiguration.Issuer,
                Audience = tokenConfiguration.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expiration
            });

            var token = handler.WriteToken(securityToken); //esse que cria o toekn e diz se esta autenticado ou nao
            return token;
        }

        private object ExceptionObject()
        {
            return new
            {
                autenticated = false,
                message = "User or password not found"
            };
        }

        private object SuccessObject(DateTime creatDate, DateTime expiration, string token)
        {
            return new
            {
                autenticated = true,
                created = creatDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expiration.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                message = "OK"
            };
        }
    }
}
