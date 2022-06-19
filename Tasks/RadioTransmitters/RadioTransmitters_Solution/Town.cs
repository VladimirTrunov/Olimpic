namespace RadioTransmitters_Solution
{
    public class Town
    {
        public Town() { }

        public Town(List<int> houses)
        {
            this.Houses = houses;
            this.Transmitters = new List<Transmitter>();
        }

        public List<int> Houses { get; set; }

        public List<Transmitter> Transmitters { get; set; }

        public void SetTransmitters(int transmitterRange)
        {
            Transmitter.DefaultRange = transmitterRange;

            int firstNotCoveredHouseIdx = 0;
            int i = firstNotCoveredHouseIdx + 1;

            while (i < this.Houses.Count)
            {
                Transmitter tryTransmitter = new Transmitter(this.Houses[i]);

                if (!tryTransmitter.IsHouseCovered(
                    this.Houses[firstNotCoveredHouseIdx]))
                {
                    Transmitter actualTransmitter = new Transmitter(this.Houses[i - 1]);
                    this.Transmitters.Add(actualTransmitter);

                    firstNotCoveredHouseIdx = this.GetFirstNotCoveredHouseIdx();

                    if (firstNotCoveredHouseIdx > 0)
                    {
                        i = firstNotCoveredHouseIdx + 1;
                    }
                    else
                    {
                        // All houses were covered.
                        break;
                    }
                }
                else
                {
                    i++;
                }
            }

            if (!this.IsCoveredByAtLeastOne(this.Houses.Count - 1))
            {
                this.Transmitters.Add(new Transmitter(this.Houses[this.Houses.Count - 1]));
            }
        }

        public int GetFirstNotCoveredHouseIdx()
        {
            for (int i = 0; i < this.Houses.Count; i++)
            {
                if (!this.IsCoveredByAtLeastOne(i))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool IsCoveredByAtLeastOne(int idx)
        {
            foreach (Transmitter transmitter in this.Transmitters)
            {
                if (transmitter.IsHouseCovered(this.Houses[idx]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}