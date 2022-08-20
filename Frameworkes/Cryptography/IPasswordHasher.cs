using System.Threading.Tasks;

namespace Frameworks
{
    public interface IPasswordHasher
    {
        Task<string> Hash(string password);
        (bool Verified, bool NeedsUpgrade) Check(string hash, string password);
    }
}