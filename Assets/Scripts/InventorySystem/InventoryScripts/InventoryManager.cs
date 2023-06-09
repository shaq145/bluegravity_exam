using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour {

    public PlayerInventory playerInventory;

    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject list;

    public InventoryItem currentItem;

    private void Start () {
        MakeInventorySlot ();
    }

    public void Update () {

    }

    //public void AddItem (string name, string desc, Sprite itemImage, Sprite lootImage, int amt, int eqId) {
    //    blankInventorySlot.gameObject.name = name;
    //    blankInventorySlot.itemName = name;
    //    blankInventorySlot.itemDescription = desc;
    //    blankInventorySlot.itemImage = itemImage;
    //    blankInventorySlot.lootImage = lootImage;
    //    blankInventorySlot.equipID = eqId;
    //    //itemList.Add (newItem);

    //    MakeInventorySlot (amt);
    //}

    public void MakeInventorySlot () {
        ClearInventorySlots ();
        if ( playerInventory ) {
            for ( int i = 0; i < playerInventory.myInventory.Count; i++ ) {
                GameObject temp = Instantiate ( blankInventorySlot, list.transform.position, Quaternion.identity );
                temp.transform.SetParent ( list.transform );
                ItemSlots newSlot = temp.GetComponent<ItemSlots> ();
                newSlot.transform.localScale = new Vector3 ( 1f, 1f, 1f );
                if ( newSlot ) {
                    newSlot.Setup ( playerInventory.myInventory [ i ], this );
                }
            }
        }
    }

    void ClearInventorySlots () {
        for ( int i = 0; i < list.transform.childCount; i++ ) {
            Destroy ( list.transform.GetChild ( i ).gameObject );
        }
    }

    //public void ViewNameDesc (string name, string desc, Sprite itemImg, Sprite lootImg ) {
    //    itemName.text = name;
    //    itemDesc.text = desc;
    //    itemImage.sprite = itemImg;
    //    lootImage.sprite = lootImg;
    //}

    //public void RemoveItem (Items thisItem) {
    //    for ( int i = 0; i < itemList.Count; i++ ) {
    //        if ( itemList [ i ].itemName == thisItem.itemName ) {
    //            thisItem = itemList [ i ];

    //            itemList.Remove (thisItem);
    //            break;
    //        }
    //    }
    //}
}
