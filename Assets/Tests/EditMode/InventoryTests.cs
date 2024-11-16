using NUnit.Framework;

[TestFixture]
public class InventoryTests
{
	private Inventory inventory;

	[SetUp]
	public void Setup()
	{
		inventory = new Inventory(3);
	}

	[Test]
	public void AddItem_WhenSpaceAvailable_AddsItem()
	{
		Assert.IsTrue(inventory.AddItem("Sword"));
		Assert.Contains("Sword", inventory.GetItems());
	}

	[Test]
	public void AddItem_WhenInventoryFull_ReturnsFalse()
	{
		inventory.AddItem("Sword");
		inventory.AddItem("Shield");
		inventory.AddItem("Potion");

		Assert.IsFalse(inventory.AddItem("Bow"));
	}

	[Test]
	public void RemoveItem_WhenItemExists_RemovesItem()
	{
		inventory.AddItem("Sword");
		Assert.IsTrue(inventory.RemoveItem("Sword"));
		Assert.IsEmpty(inventory.GetItems());
	}

	[Test]
	public void RemoveItem_WhenItemDoesNotExist_ReturnsFalse()
	{
		Assert.IsFalse(inventory.RemoveItem("NonExistentItem"));
	}
}
