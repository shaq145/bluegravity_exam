using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Item", menuName = "Item")]
public class InventoryItem : ScriptableObject {

    public int itemID;
    public string itemName;
    public string itemDesc;
    public Sprite itemImage;
    public int numberHeld;
    public int goldValue;
    public int sellValue;

    public enum ItemType { HeadGear, Armor, RightArmor, LeftArmor, NormalItem };
    public ItemType itemType;
}
