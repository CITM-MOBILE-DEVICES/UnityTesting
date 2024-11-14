using System.Collections.Generic;
using System.Linq;

public class Inventory
{
	private List<Item> items;
	public float MaxWeight { get; private set; }
	public int MaxItems { get; private set; }

	public Inventory(float maxWeight, int maxItems)
	{
		MaxWeight = maxWeight;
		MaxItems = maxItems;
		items = new List<Item>();
	}

	public bool AddItem(Item item)
	{
		if (items.Count >= MaxItems || GetTotalWeight() + item.Weight > MaxWeight)
			return false;

		items.Add(item);
		return true;
	}

	public bool RemoveItem(Item item)
	{
		return items.Remove(item);
	}

	public float GetTotalWeight() => items.Sum(i => i.Weight);
	public int GetItemCount() => items.Count;
}
