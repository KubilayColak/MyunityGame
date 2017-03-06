using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MyManager : MonoBehaviour {
    public GameObject pauseMenu, scoreboard, deathScreen;
    static public int deathScore, deathKills, deathHeadshots, deathRound;
    public Text scoreText, killsText, headshotsText, roundText;
    static public bool isPause = false;
    static public bool isDead = false;
    public bool isTrue;

    private void Start()
    {
        if (isTrue)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Update()
    {
        if (isTrue)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !isPause && !isDead)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.Confined;
                pauseMenu.SetActive(true);
                scoreboard.SetActive(false);
                isPause = true;
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && isPause)
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                pauseMenu.SetActive(false);
                isPause = false;
            }

            if (Input.GetKeyDown(KeyCode.Tab) && !isPause && !isDead)
            {
                scoreboard.SetActive(true);
            } 
            else if (Input.GetKeyUp(KeyCode.Tab))
            {
                scoreboard.SetActive(false);
            }

            if (isDead)
            {
                Cursor.lockState = CursorLockMode.Confined;
                deathScreen.SetActive(true);
                scoreboard.SetActive(false);

                deathScore = MyData.score;
                deathKills = MyData.kills;
                deathHeadshots = MyData.headshots;
                deathRound = MyData.round;

                scoreText.text = deathScore.ToString();
                killsText.text = deathKills.ToString();
                headshotsText.text = deathHeadshots.ToString();
                roundText.text = deathRound.ToString();
            }
        }
    }

    public void onExit()
    {
        Application.Quit();
    }

    public void onResume()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        isPause = false;
        isDead = false;
    }

    public void onHome()
    {
        SceneManager.LoadScene("Home");
        Time.timeScale = 1;
        isPause = false;
        isDead = false;
    }

    public void onLoad()
    {
        SceneManager.LoadScene("Castle");
        Time.timeScale = 1;
        isPause = false;
        isDead = false;
    }
}