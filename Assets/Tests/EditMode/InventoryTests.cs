using NUnit.Framework;

public class InventoryTests
{
	private Inventory inventory;
	private Item sword;

	[SetUp]
	public void SetUp()
	{
		inventory = new Inventory(maxWeight: 10f, maxItems: 5);
		sword = new Item("Sword", 3f);
	}

	[Test]
	public void AddItem_WhenInventoryIsFull_ReturnsFalse()
	{
		for (int i = 0; i < 5; i++)
			inventory.AddItem(sword);

		Assert.IsFalse(inventory.AddItem(sword));
	}

	[Test]
	public void AddItem_WhenExceedingMaxWeight_ReturnsFalse()
	{
		inventory.AddItem(new Item("Heavy Shield", 5f));
		inventory.AddItem(new Item("Heavy Shield", 5f));

		Assert.IsFalse(inventory.AddItem(sword));
	}

	[Test]
	public void RemoveItem_RemovesItemFromInventory()
	{
		inventory.AddItem(sword);
		Assert.AreEqual(1, inventory.GetItemCount());

		inventory.RemoveItem(sword);
		Assert.AreEqual(0, inventory.GetItemCount());
	}
}
