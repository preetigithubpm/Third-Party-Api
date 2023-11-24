namespace task29August.Stripe
{
    internal class SandboxEnvironment : PayPalEnvironment
    {
        private string v1;
        private string v2;

        public SandboxEnvironment(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}