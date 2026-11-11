using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Value { get; set; }

    public InventoryItem(int id, string name, int value)
    {
        ID = id;
        Name = name;
        Value = value;
    }
}
