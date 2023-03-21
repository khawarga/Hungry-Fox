using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolong : MonoBehaviour
{
    public GameObject Trap;
    public GameObject Isi;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Trap.SetActive(false);
            Isi.SetActive(true);
        }
    }

}
