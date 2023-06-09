using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlots: MonoBehaviour {

    [Header ( "ITEM DATA" )]
    public InventoryItem invetoryItem;
    public InventoryManager inventoryManager;
    public ShopManager shopManager;

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
        invetoryItem = newItem;
        inventoryManager = newManager;
        if ( invetoryItem ) {
            itemImage.sprite = invetoryItem.itemImage;
            itemNumberText.text = "" + invetoryItem.numberHeld;
            itemSellValue = newItem.sellValue;
        }
    }

    public void SetupShopItems ( InventoryItem newItem, ShopManager newManager ) {
        invetoryItem = newItem;
        shopManager = newManager;
        if ( invetoryItem ) {
            itemImage.sprite = invetoryItem.itemImage;
            itemNumberText.text = "" + invetoryItem.numberHeld;
            itemGoldValue = newItem.goldValue;
            shopItem = true;
        }
    }

    public void ClickedOn () {
        if ( shopManager.shopEnabled ) {
            if ( invetoryItem && shopItem ) {
                AddItem ();
            } else {
                Debug.Log ( "SELL" );
            }
        } else {

        }
    }

    public void AddItem () {
        if ( inventoryManager.playerInventory.myInventory.Contains ( invetoryItem ) ) {
            invetoryItem.numberHeld += 1;
            inventoryManager.MakeInventorySlot ();
        } else {
            inventoryManager.playerInventory.myInventory.Add ( invetoryItem );
            invetoryItem.numberHeld += 1;
            inventoryManager.MakeInventorySlot ();
        }
    }
}
