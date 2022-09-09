namespace MatrixRotation_Solution
{
    public class Chain
    {
        public Chain(List<Item> items)
        {
            this.Items = items;
        }

        public List<Item> Items { get; set; }

        public void MoveForward()
        {
            int lastItem = this.Items[this.Items.Count - 1].Value;
            for(int i = this.Items.Count - 1; i > 0; i--)
            {
                this.Items[i].Value = this.Items[i - 1].Value;
            }

            this.Items[0].Value = lastItem;
        }
    }
}
