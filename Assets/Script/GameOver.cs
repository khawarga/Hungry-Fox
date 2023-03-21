using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject PopUpBox;
    public GameObject retry;
    public Text PopUpText;
    private string Text;

    public void gameOverMessage()
    {
        retry.SetActive(true);
        Text = "main yang bener";
        PopUpBox.SetActive(true);
        PopUpText.text = Text;
    }
}
