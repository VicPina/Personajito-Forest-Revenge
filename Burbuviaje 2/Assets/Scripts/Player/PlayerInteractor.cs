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
        if(itemInRange != null)
        {
            itemInRange.onInteraction.Invoke();
        }
    }
}
