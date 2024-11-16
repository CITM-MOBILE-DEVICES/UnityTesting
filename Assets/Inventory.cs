using System.Collections.Generic;

public class Inventory
{
	private readonly int capacity;
	private readonly List<string> items;

	public Inventory(int capacity)
	{
		this.capacity = capacity;
		items = new List<string>();
	}

	public bool AddItem(string item)
	{
		if (items.Count >= capacity)
		{
			return false;
		}

		items.Add(item);
		return true;
	}

	public bool RemoveItem(string item)
	{
		return items.Remove(item);
	}

	public List<string> GetItems()
	{
		return new List<string>(items);
	}
}
