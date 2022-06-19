namespace RadioTransmitters_Solution
{
    public class Transmitter
    {
        public static int DefaultRange { get; set; }

        public Transmitter() { }

        public Transmitter(int house)
        {
            this.House = house;
            this.Range = Transmitter.DefaultRange;
        }

        public Transmitter(int house, int range)
        {
            this.House = house;
            this.Range = range;
        }

        public int House { get; set; }

        public int Range { get; set; }

        /// <summary>
        /// Virifies if it covers the house.
        /// </summary>
        public bool IsHouseCovered(int housePosition)
        {
            return (housePosition >= (this.House - this.Range) && housePosition <= (this.House + this.Range));
        }

        public List<int> GetCoveredHouses(List<int> houses)
        {
            if (!houses.Contains(this.House))
            {
                throw new ArgumentException($"Array with houses desn't contain house {this.House}");
            }

            return (from g in houses
                    where this.IsHouseCovered(g)
                    select g).ToList();
        }
    }
}
