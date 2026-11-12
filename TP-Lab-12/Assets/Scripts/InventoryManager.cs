using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private InventoryItem[] inventory;

    void Start()
    {
        // initialize the inventory with some items
        InitializeInventory();

        // search for an item by name : linear search
        LinearSearchByName("Potion");

        // search for an item by ID (binary search)
        BinarySearchByID(inventory[Random.Range(0, inventory.Length)].ID);
    }

    // initialize inventory method
    private void InitializeInventory()
    {
        string[] itemNames = { "Sword", "Shield", "Potion", "Bow", "Arrow" };
        inventory = new InventoryItem[itemNames.Length];

        for (int i = 0; i < itemNames.Length; i++)
        {
            int randomID = Random.Range(1, 1000); // Generate a random ID for the item
            int randomValue = Random.Range(10, 100); // Generate a random value for the item
            InventoryItem item = new InventoryItem(randomID, itemNames[i], randomValue);
            inventory[i] = item; //add item to list
        }
    }

    // linear search method
    private InventoryItem LinearSearchByName(string itemName)
    {

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

    // binary search method
    private InventoryItem BinarySearchByID(int ID)
    {
        // sorts inventory by ID first 
        QuickSortByID(0, inventory.Length - 1);

        // prints out inventory to confirm sorting worked
        PrintArray();

        // lower bound and upper bound indices
        int left = 0;
        int right = inventory.Length - 1;

        // loop until numbers converge 
        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (inventory[mid].ID == ID)
            {
                Debug.Log($"Found inventory item with ID {inventory[mid].ID}: {inventory[mid].Name}");
                return inventory[mid]; // return inventory item when found
            }
            else if (inventory[mid].ID < ID) left = mid + 1; // narrow search to higher values
            else right = mid - 1; // narrow search to lower values
        }

        // if inventory item with ID is not found, return null
        Debug.Log($"Could not find inventory item with ID {ID}.");
        return null;
    }

    // quicksort by value
    private void QuickSortByValue()
    {

    }

    // quicksort by ID
    private void QuickSortByID(int first, int last)
    {
        // recursive call until given values are sorted
        if (first < last)
        {
            int pivot = QuickSortPartitionID(first, last);
            QuickSortByID(first, pivot - 1); // from first num to pivot - 1
            QuickSortByID(pivot + 1, last); // from pivot + 1 to last num
        }
    }

    // partition helper method for quicksort
    private int QuickSortPartitionID(int first, int last)
    {
        // sets the pivot to the ID of the last array index provided
        int pivot = inventory[last].ID;
        int smaller = first - 1;

        // iterate through the array at the given index range
        for (int e = first; e < last; e++)
        {
            // if the inventory item's ID is less than pivot number's ID, swap spots
            if (inventory[e].ID < pivot)
            {
                smaller++; // increment index

                // swap the smaller inventory item with the current item
                InventoryItem temp = inventory[smaller];
                inventory[smaller] = inventory[e];
                inventory[e] = temp;
            }
        }

        // after reaching the end of the loop, ensure the last item in this partition is the last index value
        InventoryItem tempNext = inventory[smaller + 1];
        inventory[smaller + 1] = inventory[last];
        inventory[last] = tempNext;

        return smaller + 1;
    }

    // helper method to print out array 
    private void PrintArray()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            Debug.Log($"ITEM {i} -- Name: {inventory[i].Name} | ID: {inventory[i].ID} | Value: {inventory[i].Value}");
        }
    }
}
