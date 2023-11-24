using Stripe;

namespace task29August.repository
{
    public interface ITokenCreation
    {
        public  Task<Token> CreateTokenAsync();
    }
}
