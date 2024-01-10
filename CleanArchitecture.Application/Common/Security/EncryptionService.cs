using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
using Microsoft.Extensions.Configuration;
using SshNet.Security.Cryptography;

namespace CleanArchitecture.Application.Common.Security
{
    public interface IEncryptionService
    {
        string EncryptPassword(string password);
        bool VerifyPassword(string inputPassword, string hashedPassword);
    }
    public class EncryptionService : IEncryptionService
    {
        private readonly IConfiguration _configuration;

        public EncryptionService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string EncryptPassword(string password)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA256(Encoding.UTF8.GetBytes(_configuration["Security.Bearer:Secret"]!)))
            {
                byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashBytes);
            }
        }

        public bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            string expectedHash = EncryptPassword(inputPassword);
            return hashedPassword == expectedHash;
        }
    }
}
