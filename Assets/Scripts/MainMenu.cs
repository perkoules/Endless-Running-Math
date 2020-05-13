using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

}
