using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitMenu : MonoBehaviour
{
    public GameObject popupbox;
    public GameObject ScoreBoxDisplay;
    public GameObject StageSelect;
    public int maxScore;
    private int score;
    public Text scoreDisplay; 

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            popupbox.SetActive(true);
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
            FindObjectOfType<Score>().SetTimerRunning(false);
        }
    }

    public void backToTitle()
    {
        SceneManager.LoadScene(0);
    }
    public void cancel()
    {
        popupbox.SetActive(false);
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        FindObjectOfType<Score>().SetTimerRunning(true);
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void stageSelect()
    {
        StageSelect.SetActive(true);
    }

    public void restarStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void countscore()
    {
        float seconds = FindObjectOfType<Score>().getSeconds();
        float minutes = FindObjectOfType<Score>().getMinutes();
        int apple = GameObject.Find("Player").GetComponent<AppleCollect>().getJumlahApple();

        score = maxScore + (apple * 200) - (((int)seconds * 120) + ((int)minutes * 240));
    }

    public void scoreFinal()
    {
        ScoreBoxDisplay.SetActive(true);

        countscore();

        scoreDisplay.text = "Score : " + score;
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        FindObjectOfType<Score>().SetTimerRunning(false);
    }
}
