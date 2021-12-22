using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SurvivalManager : MonoBehaviour
{
    public bool pause = false;
    public TextMeshProUGUI txtTimer;
    public TextMeshProUGUI txtLose;
    public TextMeshProUGUI txtHS;
    public GameObject PauseMenu;
    public GameObject LoseMenu;
    public Material edge;
    public Material body;
    private float timer;
    private const float DefaultTimer = 15;
    private static int score = 0;

    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        pause = false;
        timer = DefaultTimer;
        GameObject[] joints = GameObject.FindGameObjectsWithTag("joint");
        foreach (GameObject joint in joints)
        {
            int[] degree = { 0, 90, 180, 270 };
            joint.transform.Rotate(0, degree[Random.Range(0, 3)], 0);
        }


        InvokeRepeating("SolveCheck", 0.1f, 0.1f);
        if (SceneManager.GetActiveScene().name == "MainMenu")
            txtHS.text = "HighScore:" + score.ToString();
    }

    void survival()
    {
        pause = false;
        timer = DefaultTimer;
        GameObject[] joints = GameObject.FindGameObjectsWithTag("joint");
        foreach (GameObject joint in joints)
        {
            int[] degree = { 0, 90, 180, 270 };
            joint.transform.Rotate(0, degree[Random.Range(0, 3)], 0);
        }
        InvokeRepeating("SolveCheck", 0.1f, 0.1f);
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
                    pause = true;
                    txtTimer.text = "Time: 0.00";
                    txtTimer.color = Color.red;
                    LoseMenu.SetActive(true);
                    txtLose.text = "TIME's OUT \r\nYOU LOSE \r\nScore:\r\n" + score.ToString();
                }
                else
                {
                    txtTimer.text = "Time: " + timer.ToString("0.00") + ("s");
                    timer -= Time.deltaTime;
                    txtHS.text = "HighScore: " + score.ToString("0");
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
                Debug.Log("SOLVEvfdddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddD");
                pause = true;
                score = score + ((int)timer * 100);
                txtTimer.text = "Time: " + timer.ToString("0.00") + ("s");

                survival();
            }
            else
            {
                Debug.Log("NOT SOLVED YET");
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
    

    public void uiRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pause = false;
        Time.timeScale = 1;
    }
}
