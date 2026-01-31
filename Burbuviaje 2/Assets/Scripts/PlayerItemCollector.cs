using UnityEngine;

public class PlayerItemCollector : MonoBehaviour
{
    private InventoryControler inventoryControler;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryControler = FindFirstObjectByType<InventoryControler>();

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                //Agrego el item al inventario
                bool itemAdded = inventoryControler.AddItem(collision.gameObject);
                if (itemAdded )
                {
                    //Esto es para que aparesca la ventanita de que se levanto un item
                    item.PickUp();
                    //Elimino el objeto del item del juego.
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
