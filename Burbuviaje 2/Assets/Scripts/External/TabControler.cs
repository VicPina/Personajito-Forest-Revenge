using UnityEngine;
using UnityEngine.UI;

public class TabControler : MonoBehaviour
{
    public Image[] tabImages;
    public GameObject[] pages;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activateTab(0);
    }

   public void activateTab(int tabNum)
    {
        //con esto desactivo todas las paginas
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
            tabImages[i].color = Color.gray;

        }
        pages[tabNum].SetActive(true);
        tabImages[tabNum].color = Color.white;
    }
}
