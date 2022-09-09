using System.Numerics;

namespace MakingCandies
{
    public class MakingCandies
    {
        public MakingCandies(long initialManPower, long initialMachines, long pricePerUnit, long aim)
        {
            this.PricePerUnit = pricePerUnit;
            this.Aim = aim;

            this.Manufacture = new Manufacture(initialManPower, initialMachines);
        }

        public long PricePerUnit { get; set; }

        public long Aim { get; set; }

        public Manufacture Manufacture { get; }

        public long GetMinimalIterationsForAim()
        {
            BigInteger totalCandies = 0;
            long iteration = 0;
            do
            {
                iteration++;
                totalCandies += this.Manufacture.GetCandies();
                if (totalCandies >= this.Aim)
                {
                    break;
                }

                long resourcesToAdd = HowManyItemsToAdd(totalCandies);
                this.Manufacture.AddResources(resourcesToAdd);
                totalCandies -= resourcesToAdd * this.PricePerUnit;

            } while (totalCandies < this.Aim);

            return iteration;
        }

        public long HowManyItemsToAdd(BigInteger currentTotalCandies)
        {
            BigInteger maxItemsToAdd = currentTotalCandies / this.PricePerUnit;
            if (maxItemsToAdd == 0)
            {
                return 0;
            }

            BigInteger remainedIterations = MakingCandies.GetRemainedIterations(
                this.Aim,
                this.Manufacture.ManPower,
                this.Manufacture.Machines,
                currentTotalCandies);

            int bestItemsCount = 0;

            long manpower = this.Manufacture.ManPower;
            long machines = this.Manufacture.Machines;

            for (int i = 1; i <= maxItemsToAdd; i++)
            {
                BigInteger remainedPrice = currentTotalCandies - i * this.PricePerUnit;

                if (manpower < machines)
                {
                    manpower++;
                }
                else
                {
                    machines++;
                }

                BigInteger currentIterations = GetRemainedIterations(this.Aim, manpower, machines, remainedPrice);

                if (currentIterations <= remainedIterations)
                {
                    remainedIterations = currentIterations;
                    bestItemsCount = i;
                }
            }

            return bestItemsCount;
        }

        public static BigInteger GetRemainedIterations(long aim, long manpower, long machines, BigInteger currentTotalCandies)
        {
            BigInteger remainedCandies = aim - currentTotalCandies;

            BigInteger remainedIterations = remainedCandies / (manpower * machines);
            if (remainedIterations * manpower * machines + currentTotalCandies < aim)
            {
                remainedIterations++;
            }

            return remainedIterations;
        }
    }
}