using UnityEngine;

[System.Serializable]
public class Item
{
    public enum ItemType {
        None,
    };
    public ItemType type;
    public string name;
    public int amount;
    public string description;
    public bool isStackable;
    public Sprite sprite;
    public Color color;
}
