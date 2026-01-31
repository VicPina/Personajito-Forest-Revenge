using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private InteractableItem itemInRange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            itemInRange = collision.GetComponent<InteractableItem>();
        }
    }
    public void InteractWithObject()
    {
        print("Interaction recieved");
        if(itemInRange != null)
        {
            print($"Interacted with {itemInRange.name}");
            itemInRange.onInteraction.Invoke();
        }
    }
}
