using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasUI : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    
    public void QuitButton()
    {
        Application.Quit();
    }
}
