using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlots: MonoBehaviour {

    [Header ( "ITEM DATA" )]
    public InventoryItem inventoryItem;
    public InventoryManager inventoryManager;
    public ShopManager shopManager;
    public int itemID;
    public bool equipped;

    [Header ( "DATA FROM UI CHANGES" )]
    [SerializeField] private TextMeshProUGUI itemNumberText;
    public Image itemImage;
    public bool shopItem;
    public int itemGoldValue;
    public int itemSellValue;

    private void Start () {
        inventoryManager = FindObjectOfType<InventoryManager> ();
        shopManager = FindObjectOfType<ShopManager> ();
    }

    public void Setup ( InventoryItem newItem, InventoryManager newManager ) {
        inventoryItem = newItem;
        inventoryManager = newManager;
        if ( inventoryItem ) {
            itemImage.sprite = inventoryItem.itemImage;
            itemNumberText.text = "" + inventoryItem.numberHeld;
            itemID = newItem.itemID;
            itemSellValue = newItem.sellValue;
        }
    }

    public void SetupShopItems ( InventoryItem newItem, ShopManager newManager ) {
        inventoryItem = newItem;
        shopManager = newManager;
        if ( inventoryItem ) {
            itemImage.sprite = inventoryItem.itemImage;
            itemNumberText.text = "" + inventoryItem.numberHeld;
            itemID = newItem.itemID;
            itemGoldValue = newItem.goldValue;
            shopItem = true;
        }
    }

    public void ClickedOn () {
        if ( shopManager.shopEnabled ) {
            if ( inventoryItem && shopItem ) {
                AddItem ();
            } else {
                RemoveItem ( inventoryItem );
            }
        } else {
            if ( inventoryItem.itemType.Equals (InventoryItem.ItemType.Armor ) && !equipped ) {
                this.gameObject.transform.SetParent ( inventoryManager.equipmentSlots [ itemID ].gameObject.transform );
                this.gameObject.transform.localPosition = new Vector3 ( 0f, 0f, 0f );
            } 
        }
    }

    public void AddItem () {
        if ( inventoryManager.itemList.Contains ( inventoryItem ) ) {
            inventoryItem.numberHeld += 1;
            inventoryManager.MakeInventorySlot ();
        } else {
            inventoryManager.itemList.Add ( inventoryItem );
            inventoryItem.numberHeld = 1;
            inventoryManager.MakeInventorySlot ();
        }
    }

    public void RemoveItem ( InventoryItem inventoryItem ) {
        if ( inventoryManager.itemList.Contains ( inventoryItem ) ) {
            inventoryItem.numberHeld -= 1;
            inventoryManager.MakeInventorySlot ();
        }
    }
}
