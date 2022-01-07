using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody Player;
    public GameObject isWin;
    //public GameObject BallVisible;
    /// <summary>
    /// sets the speed of the ball. How fast? no idea.;
    /// </summary>
    public float speed = 2400f;
    /// <summary>
    /// text for the scoreboard.
    /// </summary>
    public Text scoreText;
    public Text healthText;
    private int score = 0;
    /// <summary>
    /// player health;
    /// </summary>
    public int health = 5;
    void Start()
    {
    }

    void Update()
    {
        if (health == 0)
        {
            isWin.SetActive(true);
            isWin.GetComponent<Image>().color = new Color32(255, 0, 0, 200);
            isWin.GetComponentInChildren<Text>().text = "Game Over!";
            isWin.GetComponentInChildren<Text>().color = Color.white;
            //Debug.Log("Game Over!");
            score = 0;
            health = 5;
            StartCoroutine(LoadScene(3));
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
            Player.AddForce(0, 0, speed * Time.deltaTime);
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
            Player.AddForce(0, 0, -speed * Time.deltaTime);
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
            Player.AddForce(speed * Time.deltaTime, 0, 0);
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
            Player.AddForce(-speed * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score++;
            //Debug.Log("Score: " + score.ToString());
            SetScoreText();
            Destroy(other.gameObject);
        }
        if (other.tag == "Trap")
        {
            health--;
            //Debug.Log("Health: " + health);
            SetHealthText();
        }
        if (other.tag == "Goal")
        {
            isWin.SetActive(true);
            isWin.GetComponent<Image>().color = new Color32(0, 255, 0, 200);
            isWin.GetComponentInChildren<Text>().text = "You Win!";
            isWin.GetComponentInChildren<Text>().color = Color.black;
            //Debug.Log("You win!");
            StartCoroutine(LoadScene(3));

        }
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("maze");
    }
}
