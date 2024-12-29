using UnityEngine;

public static class Game
{
    public static void ToggleCursor()
    {
        Cursor.visible = !Cursor.visible;
        Cursor.lockState = Cursor.lockState == CursorLockMode.None ? CursorLockMode.Locked : CursorLockMode.None;
    }
    public static void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }
}
