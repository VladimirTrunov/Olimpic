namespace MakingCandies
{
    using System.Numerics;

    public class Resource
    {
        public Resource(ResourceType resourceType, BigInteger amount)
        {
            this.ResourceType = resourceType;
            this.Amount = amount;
        }

        public ResourceType ResourceType { get; set; }

        public BigInteger Amount { get; set; }
    }
}
