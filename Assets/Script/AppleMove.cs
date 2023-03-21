using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleMove : MonoBehaviour
{
    private float speed;

    // Update is called once per frame
    private void FixedUpdate()
    {
        speed += -Time.deltaTime * 500; 
        
        transform.rotation = Quaternion.Euler(0,0, speed);
    }
}
