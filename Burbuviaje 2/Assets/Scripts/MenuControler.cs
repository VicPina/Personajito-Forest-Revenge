using UnityEngine;

public class MenuControler : MonoBehaviour
{
    public GameObject MenuCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MenuCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //El menu se va a abrir y cerrar con la tecla TAB
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //Esto va a evitar que se abra el menu si el juego esta en pausa
            if(!MenuCanvas.activeSelf && PauseControler.isGamePaused)
            {
                return;
            }

            //Con esto hago que cambie el estado de activo del menu
            MenuCanvas.SetActive(!MenuCanvas.activeSelf);
            //Con esto activo o desactivo la pausa
            PauseControler.setPaused(MenuCanvas.activeSelf);
        }
    }
}
