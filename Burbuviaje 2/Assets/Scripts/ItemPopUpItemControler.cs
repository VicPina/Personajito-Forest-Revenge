using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPopUpItemControler : MonoBehaviour
{
    public static ItemPopUpItemControler Instance { get; private set; }

    public GameObject popupPrefab;
    public int maxPopup = 5;
    public float popupDuration = 3f;

    private readonly Queue<GameObject> activePopups = new();
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }else
        {
            Debug.LogError("No puede haber dos instancias de ItemPopUpIemControler");
            Destroy(gameObject);
        }
    }

    public void showItemPickup (string itemName, Sprite itemIcon)
    {
        GameObject newPopup = Instantiate(popupPrefab, transform);
        newPopup.GetComponentInChildren<TMP_Text>().text = itemName;
        Image itemImage = newPopup.transform.Find("ItemIcon")?.GetComponent<Image>();
        if (itemImage)
        {
            itemImage.sprite = itemIcon;
        }

        activePopups.Enqueue(newPopup);
        if(activePopups.Count > maxPopup)
        {
            Destroy(activePopups.Dequeue());

        }
        //Esto hace que se vaya apagando el popup y al final se quite de la lista
        StartCoroutine(FadeOutAndDestroy(newPopup));
    }

    private IEnumerator FadeOutAndDestroy(GameObject popup)
    {
        yield return new WaitForSeconds(popupDuration);
        if (popup == null) yield break;

        CanvasGroup canvasGroup = popup.GetComponent<CanvasGroup>();
        for(float timePassed = 0f; timePassed < 1f;  timePassed += Time.deltaTime)
        {
            if (popup == null) yield break;
            canvasGroup.alpha = 1f - timePassed;
            yield return null;
        }
        Destroy(popup);
    }
}
