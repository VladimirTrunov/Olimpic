// https://www.hackerrank.com/challenges/making-candies/problem?isFullScreen=true
namespace MakingCandies
{
    using System.Numerics;

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

                BigInteger resourcesToAdd = HowManyItemsToAdd(totalCandies);
                this.Manufacture.AddResources(resourcesToAdd);
                totalCandies -= resourcesToAdd * this.PricePerUnit;

            } while (totalCandies < this.Aim);

            return iteration;
        }

        public BigInteger HowManyItemsToAdd(BigInteger currentTotalCandies)
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

            BigInteger bestItemsCount = 0;

            BigInteger manpower = this.Manufacture.ManPower;
            BigInteger machines = this.Manufacture.Machines;

            BigInteger remainedPrice = currentTotalCandies - maxItemsToAdd * this.PricePerUnit;
            Manufacture.PredictResources(ref manpower, ref machines, maxItemsToAdd);
            BigInteger currentIterations = GetRemainedIterations(this.Aim, manpower, machines, remainedPrice);
            if (currentIterations <= remainedIterations)
            {
                bestItemsCount = maxItemsToAdd;
            }

            return bestItemsCount;
        }

        public static BigInteger GetRemainedIterations(long aim, BigInteger manpower, BigInteger machines, BigInteger currentTotalCandies)
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