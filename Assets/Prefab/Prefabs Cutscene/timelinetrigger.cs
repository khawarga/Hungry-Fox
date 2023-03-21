using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class timelinetrigger : MonoBehaviour
{

    public PlayableDirector finaltimeline;

    void Start()
    {
        finaltimeline = GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            finaltimeline.Play();
            PlayerMovement.playercontrolenable = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            finaltimeline.Stop();
        }
    }
}

