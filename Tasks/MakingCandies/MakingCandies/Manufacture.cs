namespace MakingCandies
{
    public class Manufacture
    {
        public Manufacture(long manPower, long machines)
        {
            this.ManPower = manPower;
            this.Machines = machines;
        }

        public long ManPower { get; set; }
        
        public long Machines { get; set; }

        public long GetCandies()
        {
            return this.ManPower * this.Machines;
        }

        public void AddResources(long resources)
        {
            for (int i = 0; i < resources; i++)
            {
                if (this.ManPower < this.Machines)
                {
                    this.ManPower++;
                }
                else
                {
                    this.Machines++;
                }
            }
        }
    }
}
