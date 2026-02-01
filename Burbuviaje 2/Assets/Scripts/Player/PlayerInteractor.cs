using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private InteractableItem itemInRange;
    private IInteractable interactableInRange;
    public GameObject interactionIcon;

    private void Start()
    {
        interactionIcon.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            if (collision.TryGetComponent(out IInteractable interactable) && interactable.CanInteract())
            {
                interactableInRange = interactable;
                interactionIcon.SetActive(true);
            }
                
        }

            if (collision.CompareTag("Interactable"))
        {
            itemInRange = collision.GetComponent<InteractableItem>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactionIcon.SetActive(false);
    }
    public void InteractWithObject()
    {
        if (interactableInRange != null) 
            {
            interactableInRange.Interact();
            if (!interactableInRange.CanInteract())
            {
                interactionIcon.SetActive(false);
            }
        }
        

        if (itemInRange != null)
        {

            itemInRange.onInteraction.Invoke();
        }
    }
}
