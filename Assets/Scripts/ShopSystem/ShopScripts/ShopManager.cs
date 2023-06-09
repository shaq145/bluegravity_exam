using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager: MonoBehaviour {

    public bool shopEnabled;
    public PlayerInventory shopInventory;
    //public List<InventoryItem> itemList = new List<InventoryItem> ();

    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject list;

    public InventoryItem currentItem;

    private void Start () {
        MakeInventorySlot ();
    }

    public void Update () {

    }
    public void MakeInventorySlot () {
        //for ( int i = 0; i < itemList.Count; i++ ) {
        //    itemList [ i ].numberHeld = 1;
        //    shopInventory.myInventory.Add ( ScriptableObject.Instantiate ( itemList [ i ] ) );
        //}
        

        if ( shopInventory ) {
            for ( int i = 0; i < shopInventory.myInventory.Count; i++ ) {
                GameObject temp = Instantiate ( blankInventorySlot, list.transform.position, Quaternion.identity );
                temp.transform.SetParent ( list.transform );
                ItemSlots newSlot = temp.GetComponent<ItemSlots> ();
                newSlot.transform.localScale = new Vector3 ( 1f, 1f, 1f );
                if ( newSlot ) {
                    newSlot.SetupShopItems ( shopInventory.myInventory [ i ], this );
                }
            }
        }
    }


    //public void ViewNameDesc (string name, string desc, Sprite itemImg, Sprite lootImg ) {
    //    itemName.text = name;
    //    itemDesc.text = desc;
    //    itemImage.sprite = itemImg;
    //    lootImage.sprite = lootImg;
    //}
}
