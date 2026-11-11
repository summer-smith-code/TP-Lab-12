using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventoryItem[] inventory = new InventoryItem[7];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // initialize the inventory with some items
        InitializeInventory();
        // search for an item by name : linear search
        LinearSearchByName("Potion");
    }
    // linear search method
    private InventoryItem LinearSearchByName(string itemName)     {

        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i].Name == itemName)
            {
                Debug.Log($"Item found: ID={inventory[i].ID}, Name={inventory[i].Name}, Value={inventory[i].Value}");
                return inventory[i];
            }
        }   
        Debug.Log("Item not found.");
        return null;
    }

    // initialize inventory method
    private void InitializeInventory()
    {
        string[] itemNames = { "Sword", "Shield", "Potion", "Bow", "Arrow" };

        for (int i = 0; i < itemNames.Length; i++)
        {
            int randomID = Random.Range(1, 1000); // Generate a random ID for the item
            int randomValue = Random.Range(10, 100); // Generate a random value for the item
            InventoryItem item = new InventoryItem(randomID, itemNames[i], randomValue);
            inventory[i] = item; //add item to list
        }
    }
}
