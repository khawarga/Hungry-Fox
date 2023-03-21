using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject door;
    public Sprite lever2;
    private bool masuk;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && masuk)
        {
           door.SetActive(false);
           gameObject.GetComponent<SpriteRenderer>().sprite = lever2;
           gameObject.GetComponent<BoxCollider2D>().enabled = false;
           suara.playsound("door");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            masuk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            masuk = false;
        }
    }
}
