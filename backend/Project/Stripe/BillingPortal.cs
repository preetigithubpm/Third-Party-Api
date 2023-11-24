using Stripe.FinancialConnections;

namespace task29August.Stripe
{
    internal class BillingPortal
    {
        internal class SessionCreateOptions
        {
            public SessionAccountHolderOptions AccountHolder { get; set; }
            public List<string> Permissions { get; set; }
            public SessionFiltersOptions Filters { get; set; }
        }

        internal class SessionService
        {
            public SessionService()
            {
            }
        }
    }
}