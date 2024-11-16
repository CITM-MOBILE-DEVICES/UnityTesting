using System.Collections.Generic;

public class Inventory
{
	private readonly int capacity;
	private readonly List<string> items;
	private readonly Dictionary<string, int> stackLimits; // L�mite de pilas por tipo de objeto

	public Inventory(int capacity)
	{
		this.capacity = capacity;
		items = new List<string>();
		stackLimits = new Dictionary<string, int>();
	}

	public bool AddItem(string item, int amount = 1, int maxStackSize = 1)
	{
		if (!stackLimits.ContainsKey(item))
		{
			stackLimits[item] = maxStackSize;
		}

		for (int i = 0; i < amount; i++)
		{
			if (items.Count >= capacity) return false;

			// Cuenta las instancias actuales del objeto
			int currentCount = items.FindAll(x => x == item).Count;
			if (currentCount >= stackLimits[item]) return false;

			items.Add(item);
		}
		return true;
	}

	public bool RemoveItem(string item, int amount = 1)
	{
		for (int i = 0; i < amount; i++)
		{
			if (!items.Remove(item)) return false;
		}
		return true;
	}

	public List<string> GetItems()
	{
		return new List<string>(items);
	}
}
