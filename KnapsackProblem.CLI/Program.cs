using System;
using System.Collections.Generic;
using System.Diagnostics;
using KnapsackProblem.Core;

var items = new List<Item>
{
	new Item(40, 80),
	new Item(20, 40),
	new Item(20, 80),
	new Item(30, 75),
	new Item(30, 60),
	new Item(30, 90),
	new Item(35, 70),
	new Item(25, 75),
	new Item(35, 105),
	new Item(25, 100),
};

PrintStatistics(items);

var knapsack = new Knapsack(80);
var timer = new Stopwatch();

Console.WriteLine("\nЖадный алгоритм:");
timer.Start();
knapsack.GreedyAlgorithm(items);
timer.Stop();
knapsack.PrintStatistics();
Console.WriteLine($"Время упаковки: {timer.ElapsedMilliseconds} мс");
timer.Reset();

Console.WriteLine("\nАлгоритм полного перебора:");
timer.Start();
knapsack.BruteforceAlgorithm(items);
timer.Stop();
knapsack.PrintStatistics();
Console.WriteLine($"Время упаковки: {timer.ElapsedMilliseconds} мс");
knapsack.Clear();
timer.Reset();

static void PrintStatistics(List<Item> items)
{
	Console.WriteLine("Список предметов:");
	foreach (var item in items)
	{
		Console.WriteLine($"Вес: {item.Weight}, Стоимость: {item.Price}");
	}
}