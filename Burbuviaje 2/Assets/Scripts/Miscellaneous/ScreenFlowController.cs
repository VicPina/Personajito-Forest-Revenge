using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenFlowController : MonoBehaviour
{
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
