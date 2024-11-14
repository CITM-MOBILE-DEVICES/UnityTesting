public class Item
{
	public string Name { get; private set; }
	public float Weight { get; private set; }

	public Item(string name, float weight)
	{
		Name = name;
		Weight = weight;
	}
}
