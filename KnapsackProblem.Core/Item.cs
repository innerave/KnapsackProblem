namespace KnapsackProblem.Core
{
	public sealed class Item
	{
		public int Weight { get; set; }
		public int Price { get; set; }
		public double Profit { get; set; }

		public Item(int weight, int price)
		{
			Weight = weight;
			Price = price;
		}
	}
}
