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

	// Phase 2

	[Test]
	public void AddItem_Stackable_AddsMultipleInstances()
	{
		Assert.IsTrue(inventory.AddItem("Potion", 3, 5));
		Assert.AreEqual(3, inventory.GetItems().FindAll(x => x == "Potion").Count);
	}

	[Test]
	public void AddItem_Stackable_ExceedsStackLimit_ReturnsFalse()
	{
		Assert.IsFalse(inventory.AddItem("Potion", 3, 2));
	}

	[Test]
	public void AddItem_ExceedsInventoryCapacity_ReturnsFalse()
	{
		Assert.IsFalse(inventory.AddItem("Bow", 5));
	}

	[Test]
	public void RemoveItem_Stackable_RemovesCorrectQuantity()
	{
		inventory.AddItem("Potion", 3, 5);
		Assert.IsTrue(inventory.RemoveItem("Potion", 2));
		Assert.AreEqual(1, inventory.GetItems().FindAll(x => x == "Potion").Count);
	}

	[Test]
	public void RemoveItem_LastInstance_RemovesItemFromInventory()
	{
		inventory.AddItem("Potion", 1, 5);
		Assert.IsTrue(inventory.RemoveItem("Potion", 1));
		Assert.IsFalse(inventory.GetItems().Contains("Potion"));
	}

}
