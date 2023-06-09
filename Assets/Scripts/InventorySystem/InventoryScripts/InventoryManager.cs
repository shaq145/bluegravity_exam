using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour {

    public PlayerInventory playerInventory;

    public List<InventoryItem> itemList = new List<InventoryItem> ();

    public bool openInventory;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject list;

    public GameObject [] equipmentSlots;

    public InventoryItem currentItem;

    private void Start () {
        MakeInventorySlot ();
    }

    public void Update () {
        if ( Input.GetKeyDown (KeyCode.I) ) {
            openInventory = !openInventory;
        }

        if ( openInventory ) {
            inventoryPanel.SetActive ( true );
        } else {
            inventoryPanel.SetActive ( false );
        }
    }

    public void MakeInventorySlot () {
        ClearInventorySlots ();
        if ( playerInventory ) {
            for ( int i = 0; i < itemList.Count; i++ ) {
                if ( itemList [ i ].numberHeld > 0 ) {
                    GameObject temp = Instantiate ( blankInventorySlot, list.transform.position, Quaternion.identity );
                    temp.transform.SetParent ( list.transform );
                    ItemSlots newSlot = temp.GetComponent<ItemSlots> ();
                    newSlot.transform.localScale = new Vector3 ( 1f, 1f, 1f );
                    if ( newSlot ) {
                        newSlot.Setup ( itemList [ i ], this );
                    }
                }
            }
        }
    }

    void ClearInventorySlots () {
        for ( int i = 0; i < list.transform.childCount; i++ ) {
            Destroy ( list.transform.GetChild ( i ).gameObject );
        }
    }

    public void RemoveItem ( InventoryItem thisItem ) {
        for ( int i = 0; i < itemList.Count; i++ ) {
            if ( itemList [ i ].itemName == thisItem.itemName ) {
                thisItem = itemList [ i ];
                itemList.Remove ( thisItem );
                break;
            }
        }
    }
}
