using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleCollect : MonoBehaviour
{
    public Text PopUpText;
    private string Text;
    private int jumlah = 0;

    void Update()
    {
        Text = "X " + jumlah + "/" + GameObject.FindGameObjectsWithTag("Apple").Length;
        PopUpText.text = Text;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject apple = collision.gameObject;

        if (collision.gameObject.CompareTag("Apple"))
        {
            jumlah += 1;
            apple.SetActive(false);
        }
    }

    public int getJumlahApple()
    {
        return jumlah;
    }
}
