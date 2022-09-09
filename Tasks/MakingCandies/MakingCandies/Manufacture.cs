namespace MakingCandies
{
    using System.Numerics;

    public class Manufacture
    {
        public Manufacture(BigInteger manPower, BigInteger machines)
        {
            this.ManPower = manPower;
            this.Machines = machines;
        }

        public BigInteger ManPower { get; set; }
        
        public BigInteger Machines { get; set; }

        public BigInteger GetCandies()
        {
            return this.ManPower * this.Machines;
        }

        public void AddResources(BigInteger resources)
        {
            BigInteger currentManPower = this.ManPower;
            BigInteger currentMachiens = this.Machines;

            Manufacture.PredictResources(ref currentManPower, ref currentMachiens, resources);

            this.ManPower = currentManPower;
            this.Machines = currentMachiens;
        }

        public static void PredictResources(
            ref BigInteger manPower, 
            ref BigInteger machines, 
            BigInteger additionalItems)
        {
            List<Resource> resources = new List<Resource>
            {
                new Resource(ResourceType.ManPower, manPower),
                new Resource(ResourceType.Machines, machines),
            };

            resources = resources.OrderBy(item => item.Amount).ToList();
            BigInteger balance = resources[1].Amount - resources[0].Amount;

            if (additionalItems <= balance)
            {
                resources[0].Amount += additionalItems;
            }
            else
            {
                BigInteger toMinimal = (additionalItems - balance) / 2 + balance;
                BigInteger toMax = additionalItems - toMinimal;

                resources[0].Amount += toMinimal;
                resources[1].Amount += toMax;
            }

            manPower = (from g in resources
                        where g.ResourceType == ResourceType.ManPower
                        select g.Amount).FirstOrDefault();

            machines = (from g in resources
                        where g.ResourceType == ResourceType.Machines
                        select g.Amount).FirstOrDefault();
        }
    }
}
