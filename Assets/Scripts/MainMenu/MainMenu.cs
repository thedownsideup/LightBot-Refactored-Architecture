using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu
{
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
