using System.Runtime.CompilerServices;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public bool IsOpened { get; private set; }
    public string ChestID { get; private set; }

    public GameObject itemPrefab; //El item que va a tirar el cofre

    public Sprite OpenedChest;

    void Start()
    {
        //gereo un ID unico
        ChestID ??= GlobalHelper.GenerateUniqueID(gameObject);

    }

    public bool CanInteract()
    {
        //solo se puede interactuar cuando esta cerraro
        return (!IsOpened);
    }

    public void Interact()
    {
        if(!CanInteract()) return;
        OpenChest();

    }

    private void OpenChest()
    {
        //Abro el cofre
        SetOpened(true);
        //ejecuto el sonido
        SoundEffectManager.Play("Chest");

        //arrojo el item
        if(itemPrefab != null)
        {
            GameObject droppedItem = Instantiate(itemPrefab, transform.position + Vector3.down,Quaternion.identity);
            droppedItem.GetComponent<BounceEffect>().startBounce();
        }

    }

    public void SetOpened(bool opened)
    {
        IsOpened = opened;
        if (IsOpened)
        {
            GetComponent<SpriteRenderer>().sprite = OpenedChest;
        }
    }

}
