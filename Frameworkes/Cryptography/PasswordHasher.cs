using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Frameworks
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 16; // 128 bit 
        private const int KeySize = 32; // 256 bit

        public PasswordHasher(IOptions<HashingOptions> options)
        {
            Options = options.Value;
        }

        private HashingOptions Options { get; }

        public async Task<string> Hash(string password)
        {
            string salt = string.Empty;
            string key = string.Empty;
            await Task.Run(() =>
            {
                using var algorithm = new Rfc2898DeriveBytes(password, SaltSize, Options.Iterations, HashAlgorithmName.SHA256);
                key = Convert.ToBase64String(algorithm.GetBytes(KeySize));
                salt = Convert.ToBase64String(algorithm.Salt);
            });
            return $"{Options.Iterations}.{salt}.{key}";

        }

        internal class CheckProps
        {
            public bool needsUpgrade { get; set; }
            public bool verified { get; set; }
        }
        public (bool Verified, bool NeedsUpgrade) Check(string hash, string password)
        {
            CheckProps checkProps = new CheckProps();

            var parts = hash.Split('.', 3);

            if (parts.Length != 3)
            {
                return (false, false);
            }

            var iterations = Convert.ToInt32(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);

            checkProps.needsUpgrade = iterations != Options.Iterations;

            using var algorithm = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
            var keyToCheck = algorithm.GetBytes(KeySize);

            checkProps.verified = keyToCheck.SequenceEqual(key);

            return (checkProps.verified, checkProps.needsUpgrade);
        }
    }
}