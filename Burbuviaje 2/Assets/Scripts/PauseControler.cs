using UnityEngine;

public class PauseControler : MonoBehaviour
{
    public static bool isGamePaused { get; private set; } = false;

    public static void setPaused(bool paused)
    {
        isGamePaused=paused;
    }
}
