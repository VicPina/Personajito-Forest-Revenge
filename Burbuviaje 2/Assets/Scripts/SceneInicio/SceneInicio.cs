using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInicio : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(2);
    }

    public void Creditos()
    {
        SceneManager.LoadScene(1);
    }
    public void Salir()
    {
        Debug.Log("Saliendo del juego.....");
        Application.Quit();
    }

}
