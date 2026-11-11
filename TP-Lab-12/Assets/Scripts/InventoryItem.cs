using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Value { get; set; }

    InventoryItem[] inventoryItems = new InventoryItem[5];

    public InventoryItem(int id, string name, int value)
    {
        ID = id;
        Name = name;
        Value = value;
    }

    private void InitializeInventory()
    {
        string[] itemNames = { "Sword", "Shield", "Potion", "Bow", "Arrow" };

        for (int i = 0; i < itemNames.Length; i++)
        {
            int randomID = Random.Range(1, 1000); // Generate a random ID for the item
            int randomValue = Random.Range(10, 100); // Generate a random value for the item
            InventoryItem item = new InventoryItem(randomID, itemNames[i], randomValue);
            inventoryItems[i] = item; //add item to list
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeInventory();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
