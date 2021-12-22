using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool pause = false;
    public int levelNo;
    public TextMeshProUGUI txtTimer;
    public TextMeshProUGUI txtWin;
    public TextMeshProUGUI txtLose;
    public TextMeshProUGUI txtHS;
    public GameObject PauseMenu;
    public GameObject WinMenu;
    public GameObject LoseMenu;
    private float timer;
    private const float DefaultTimer = 15;
    private static int score = 0;

    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        timer = DefaultTimer;
        GameObject[] joints = GameObject.FindGameObjectsWithTag("joint");
        foreach (GameObject joint in joints)
        {
            int[] degree = { 0, 90, 180, 270 };
            joint.transform.Rotate(0, degree[Random.Range(0, 3)], 0);
        }

        InvokeRepeating("SolveCheck", 0.1f, 0.1f);
        if(SceneManager.GetActiveScene().name == "MainMenu")
            txtHS.text = "HighScore :\r\n" + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 0)
        {
            pause = true;
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }

        if (!pause)
        {
            if (SceneManager.GetActiveScene().name != "MainMenu")
            {
                if (timer < 0)
                {
                    CancelInvoke();
                    music.clip = Resources.Load<AudioClip>("LBGM");
                    music.Play();
                    pause = true;
                    txtTimer.text = "Time: 0.00";
                    txtTimer.color = Color.red;
                    LoseMenu.SetActive(true);
                    txtLose.text = "TIME's OUT \r\nYOU LOSE \r\nScore:\r\n" + score.ToString();
                    if (score > PlayerPrefs.GetInt("HighScore", 0))
                        PlayerPrefs.SetInt("HighScore", score);
                }
                else
                {
                    txtTimer.text = "Time: " + timer.ToString("0.00") + ("s");
                    timer -= Time.deltaTime;
                }
            }
        }

    }

    private void SolveCheck()
    {
        bool isSolved = true;
        bool win = false;
        GameObject[] touchObjects = GameObject.FindGameObjectsWithTag("touch");
        foreach (GameObject touchObject in touchObjects)
        {
            if (!touchObject.GetComponent<ConnectionCheck>().isConnected)
            {
                isSolved = false;
            }
        }
        if(isSolved)
        {
            win = true;
        }

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            if (win)
            {
                CancelInvoke();
                music.clip = Resources.Load<AudioClip>("WBGM");
                music.Play();
                pause = true;
                score = score + ((int)timer * 100);
                txtWin.text = "YOU WON \r\nScore:\r\n" + score.ToString();
                WinMenu.SetActive(true);
                if (score > PlayerPrefs.GetInt("HighScore", 0))
                    PlayerPrefs.SetInt("HighScore", score);

                GameObject[] joints = GameObject.FindGameObjectsWithTag("joint");
                foreach (GameObject joint in joints)
                {
                    joint.GetComponentInChildren<Renderer>().materials[0].color = Color.green;
                    joint.GetComponentInChildren<Renderer>().materials[1].color = Color.green;
                }
                txtTimer.text = "Time: " + timer.ToString("0.00") + ("s");
                txtTimer.color = Color.green;
                if(PlayerPrefs.GetInt("progress", 1) < SceneManager.GetActiveScene().buildIndex + 1)
                    PlayerPrefs.SetInt("progress", SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                //Debug.Log("NOT SOLVED YET");
                pause = false;
            }
        }
    }


    public void uiResume()
    {
        PauseMenu.SetActive(false);
        pause = false;
        Time.timeScale = 1;
    }

    public void uiMainMenu()
    {
        score = 0;
        SceneManager.LoadScene("MainMenu");
    }

    public void uiNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        pause = false;
        Time.timeScale = 1;
    }

    public void uiResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        txtHS.text = "HighScore :\r\n0";
    }

    public void uiRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pause = false;
        Time.timeScale = 1;
    }

    public void uiExit()
    {
        Application.Quit();
    }
}
