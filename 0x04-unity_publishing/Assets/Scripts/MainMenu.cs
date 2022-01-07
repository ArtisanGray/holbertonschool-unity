using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Play;
    public GameObject Exit;
    public Material goalMat;
    public Material trapMat;
    public Toggle colorblindMode;

    // Start is called before the first frame update
    void Start()
    {
        Button playButton = Play.GetComponent<Button>();
        playButton.onClick.AddListener(PlayMaze);
        Button quitButton = Exit.GetComponent<Button>();
        quitButton.onClick.AddListener(QuitMaze);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
    public void PlayMaze()
    {
        SceneManager.LoadScene("maze");
        if (colorblindMode.isOn == true)
        {
            goalMat.color = Color.blue;
            trapMat.color = new Color32(255, 112, 0, 1);
        }
    }
    public void QuitMaze()
    {
        goalMat.color = new Color32(0, 255, 0, 1);
        trapMat.color = new Color32(255, 0, 0, 1);
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
