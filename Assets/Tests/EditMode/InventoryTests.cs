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
		inventory = new Inventory(5);

		Assert.IsTrue(inventory.AddItem("Potion", 3, 5)); // Máximo 5 por pila
		Assert.AreEqual(3, inventory.GetItems().FindAll(x => x == "Potion").Count);
	}

	[Test]
	public void AddItem_Stackable_ExceedsStackLimit_ReturnsFalse()
	{
		inventory = new Inventory(5);

		inventory.AddItem("Potion", 5, 5); // Llena la pila
		Assert.IsFalse(inventory.AddItem("Potion", 1, 5)); // Intenta añadir más
	}

	[Test]
	public void AddItem_ExceedsInventoryCapacity_ReturnsFalse()
	{
		inventory = new Inventory(5);

		inventory.AddItem("Potion", 3, 5);
		inventory.AddItem("Sword", 1);
		inventory.AddItem("Shield", 1);

		Assert.IsFalse(inventory.AddItem("Bow", 1)); // Sin espacio
	}

	[Test]
	public void RemoveItem_Stackable_RemovesCorrectQuantity()
	{
		inventory = new Inventory(5);

		inventory.AddItem("Potion", 3, 5);
		Assert.IsTrue(inventory.RemoveItem("Potion", 2)); // Quita 2
		Assert.AreEqual(1, inventory.GetItems().FindAll(x => x == "Potion").Count);
	}

	[Test]
	public void RemoveItem_LastInstance_RemovesItemFromInventory()
	{
		inventory = new Inventory(5);

		inventory.AddItem("Potion", 1, 5);
		Assert.IsTrue(inventory.RemoveItem("Potion", 1)); // Quita el último
		Assert.IsFalse(inventory.GetItems().Contains("Potion"));
	}

}
