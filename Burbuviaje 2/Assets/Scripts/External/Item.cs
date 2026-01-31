using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int ID;
    public string Nombre;

    public virtual void UseItem()
    {
        Debug.Log($"Usando el item: {Nombre}");
    }
    public virtual void PickUp()
    {
        Sprite itemIcon = GetComponent<Image>().sprite;
        if (ItemPopUpItemControler.Instance != null)
        {
            ItemPopUpItemControler.Instance.showItemPickup(Nombre, itemIcon);
        }
    }
}
