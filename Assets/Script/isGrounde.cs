using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGrounde : MonoBehaviour
{
    private static bool isGrounded;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tanah"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Tanah"))
        {
            isGrounded = false;
        }
    }

    public static bool getIsGrounded()
    {
        return isGrounded;
    }
}
