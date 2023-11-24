using Stripe;

namespace task29August.repository
{
    public class TokenCreation:ITokenCreation
    {
        public async Task<Token> CreateTokenAsync()
        {
            try
            {
                // Use a test card number provided by Stripe for testing
                var tokenOptions = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = "4242424242424242", // Test card number
                        ExpMonth = "12",            // Replace with the desired expiration month
                        ExpYear = "2023",           // Replace with the desired expiration year
                        Cvc = "123"                 // Replace with the desired CVC code
                    }
                };

                // Set your Stripe API key
                StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

                var tokenService = new TokenService();
                var token = await tokenService.CreateAsync(tokenOptions);

                // The 'token' variable now contains the created token
                return token;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during token creation
                Console.WriteLine($"Failed to create token: {ex.Message}");
                return null;
            }
        }
    }

}
