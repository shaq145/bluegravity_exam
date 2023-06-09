using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour {

    [SerializeField] private GameObject triggerImage;
    [SerializeField] private bool canShop;

    [SerializeField] private ShopManager shopManager;
    [SerializeField] private InventoryManager inventory;

    private void Update () {
        if ( canShop ) {
            if ( Input.GetKeyDown ( KeyCode.E ) ) {
                shopManager.gameObject.SetActive ( true );
                inventory.openInventory = true;
                shopManager.shopEnabled = true;
                triggerImage.SetActive ( false );
            }
        }
    }

    private void OnTriggerEnter2D ( Collider2D other ) {
        if ( other.CompareTag("Player") ) {
            canShop = true;
            triggerImage.SetActive ( true );
        }
    }

    private void OnTriggerExit2D ( Collider2D other ) {
        if ( other.CompareTag ( "Player" ) ) {
            canShop = false;
            shopManager.gameObject.SetActive ( false );
            shopManager.shopEnabled = false;
            triggerImage.SetActive ( false );
        }
    }
}
