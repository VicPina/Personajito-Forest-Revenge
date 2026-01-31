using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    Transform originalParent;
    CanvasGroup canvasGruop;

    public float minDropDistance = 2f;
    public float maxDropDistance = 3f;


    void Start()
    {
        canvasGruop = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent; //Guardo la posicion del parent
        transform.SetParent(transform.root);
        canvasGruop.blocksRaycasts = false;
        canvasGruop.alpha = 0.6f; //lo hago un poco transparente
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position; //es para que siga el mouse
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGruop.blocksRaycasts=true;
        canvasGruop.alpha=1.0f;

        Slot dropSlot = eventData.pointerEnter?.GetComponent<Slot>();
        if (dropSlot == null)
        {
            GameObject dropItem = eventData.pointerEnter;
            if (dropItem != null)
            {
                dropSlot = dropItem.GetComponentInParent<Slot>();
            }
        }

        Slot originalSlot = originalParent.GetComponent<Slot>();

        if (dropSlot != null)
        {
            if (dropSlot.currentItem != null)
            {
                dropSlot.currentItem.transform.SetParent(originalSlot.transform);
                originalSlot.currentItem = dropSlot.currentItem;
                dropSlot.currentItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

            }
            else
            {
                originalSlot.currentItem = null;
            }
            //muevo el item al otro slot
            transform.SetParent(dropSlot.transform);
            dropSlot.currentItem = gameObject;

        }
        else
        {
            //Me fijo donde tiro el item
            if (!IsWithinInventory(eventData.position))
            {
                //Si lo tiro fuera del inventario
                DropItem(originalSlot);
            }
            else
            {
                //lo devuelvo a su sitio original
                transform.SetParent(originalParent);
            }

               

        }
        GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }

    bool IsWithinInventory(Vector2 mousePosition)
    {
        //con esto obtengo el tamaño del inventario
        RectTransform inventoryRect = originalParent.parent.GetComponent<RectTransform>();
        //Esto compara si la posicion del mouse se encuentra dentro del inventario o no
        return RectTransformUtility.RectangleContainsScreenPoint(inventoryRect, mousePosition);

    }

    void DropItem(Slot originalSlot)
    {
        originalSlot.currentItem = null;
        //Busco al player
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (playerTransform == null)
        {
            Debug.LogError("No se pudo encontrar al player");
            return;
        }

        //Posicion aleatoria para dejar el item
        Vector2 dropOffest = Random.insideUnitCircle.normalized * Random.Range(minDropDistance, maxDropDistance);
        Vector2 dropPosition = (Vector2)playerTransform.position + dropOffest;

        //La manera más facil es crear un nuevo item en la posicion y borrar el viejo
        //Creo un nuevo item en la posicion y lo hago rebotar
        GameObject dropItem = Instantiate(gameObject, dropPosition, Quaternion.identity);
        dropItem.GetComponent<BounceEffect>().startBounce();
        //Borro el item original
        Destroy(gameObject);


    }
}
