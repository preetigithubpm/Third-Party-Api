namespace task29August.Controllers.UpgradeDowngrade.model
{
    public class SubscriptionModel
    {
        public string subsitemid { get; set; }
        public string newPriceid { get; set; }
    }
    public class subscriptionDto
    {
        public string customerId { get; set; }
        public string Priceid { get; set; }
    }
    public class PlanModel
    {
        public long Amount { get; set; }
        public string Interval { get; set; }
        public string prodId { get; set; }
    }
    public class PlanUpdate
    {
        //public long Amount { get; set; }
        //public string Interval { get; set; }
        public string planId { get; set; }
    }

}
