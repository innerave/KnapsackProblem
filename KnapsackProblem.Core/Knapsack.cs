using System.Collections.Generic;
using System.Linq;

namespace KnapsackProblem.Core
{
	public sealed class Knapsack
	{
		private List<Item> items = new List<Item>();
		public int MaxCapacity { get; }
		public int CurrentCapacity { get; private set; }
		public int TotalPrice { get; private set; }

		public Knapsack(int maxCapacity)
		{
			MaxCapacity = maxCapacity;
		}

		public void Clear()
		{
			items.Clear();
			CurrentCapacity = 0;
			TotalPrice = 0;
		}
		// Жадный алгоритм
		public void GreedyAlgorithm(List<Item> items)
		{
			// Оценим удельные стоимости данных предметов
			CalculateProfitForEachItem(items);

			// Будем брать самые ценные предметы
			foreach (var item in items.OrderByDescending(item => item.Profit))
			{
				// Если предмет поместиттся в рюкзак - возьмем его
				if (CurrentCapacity + item.Weight <= MaxCapacity)
				{
					this.items.Add(item);
					CurrentCapacity += item.Weight;
					TotalPrice += item.Price;
				}
			}
		}
		// Расчет удельных стоимостей предметов
		private static void CalculateProfitForEachItem(List<Item> items)
		{
			foreach (var item in items)
			{
				item.Profit = item.Price / item.Weight;
			}
		}

		/* Перебираем все возможные перестановки предметов для рюкзака. 
		 * Сначала в наборе все N предметов, затем, при переходе вглубь на один уровень рекурсии, 
		 * один предмет удаляется.*/
		public void BruteforceAlgorithm(List<Item> items)
		{
			if(items.Count > 0)
			{
				CheckSolution(items);
			}
			for (int i = 0; i < items.Count; i++)
			{
				List<Item> newSet = new List<Item>(items);
				newSet.RemoveAt(i);
				BruteforceAlgorithm(newSet);
			}
		}
		/* Метод, сравнивающий текущий лучший набор предметов 
		 * в рюкзаке с набором предметов из аргументов метода.
		 * Если набор из аргументов лучше, то он сохраняется 
		 * в рюкзаке:*/
		private void CheckSolution(List<Item> items)
		{
			if (CalculateWeight(items) <= MaxCapacity && CalculatePrice(items) > TotalPrice)
			{
				this.items = items;
				TotalPrice = CalculatePrice(items);
				CurrentCapacity = CalculateWeight(items);
			}
		}
		// Оценка общего веса
		private static int CalculateWeight(List<Item> items)
		{
			var totalWeight = 0;
			foreach (var item in items)
			{
				totalWeight += item.Weight;
			}
			return totalWeight;
		}
		// Оценка общей цены
		private static int CalculatePrice(List<Item> items)
		{
			var totalPrice = 0;
			foreach (var item in items)
			{
				totalPrice += item.Price;
			}
			return totalPrice;
		}

		public void PrintStatistics()
		{
			System.Console.WriteLine("Предметы в рюкзаке:");
			foreach (var item in items)
			{
				System.Console.WriteLine($"Вес: {item.Weight}, Стоимость: {item.Price}");
			}
			System.Console.WriteLine($"Общая стоимость предметов в рюкзаке: {TotalPrice}\nЗанято места: {CurrentCapacity}");
		}
	}
}
