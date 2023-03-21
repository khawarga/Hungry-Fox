using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

	public CharacterController2D controller;
	public float runSpeed = 40f;
	public float horizontalMove = 0f;
	private Animator anima;
	private int extrajump;
	private Rigidbody2D rb;
	private bool grounded;
	public GameObject teleporter;
	public static bool playercontrolenable = true;

	private void Awake(){
        anima = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        if (playercontrolenable)
        {
			horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

			if(Input.GetButtonDown("Jump") && grounded && extrajump == 0)
			{
				grounded = false;
				rb.velocity = Vector2.up * 6f;
				anima.SetTrigger("Jump");
				extrajump++;
				suara.playsound("lompat");
			}
			else if (Input.GetButtonDown("Jump") && extrajump !=2)
			{
				rb.velocity = Vector2.up * 6f;
				anima.SetTrigger("Jump");
				extrajump++;
				suara.playsound("lompat");
			}

			if (Input.GetButtonDown("Crouch") && grounded)
			{
				anima.SetBool("Crouch", true);
			} 
			else if (Input.GetButtonUp("Crouch"))
			{
				anima.SetBool("Crouch", false);
			}

			//set animator paramater
			anima.SetBool("Run", horizontalMove != 0);

			anima.SetBool("Grounded",grounded);

			if (Input.GetKeyDown(KeyCode.E))
			{
				if(teleporter != null)
				{
					transform.position = new Vector3(teleporter.GetComponent<Teleporter>().GetTujuan().position.x, teleporter.GetComponent<Teleporter>().GetTujuan().position.y, transform.position.z); 
				}
			}
        }
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    }

	private void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.tag == "Tanah"){
			grounded = isGrounde.getIsGrounded();
            if (grounded)
            {
				extrajump = 0;
            }
		}
		if(collision.gameObject.CompareTag("Finish"))
        {
			suara.playsound("menang");
			GameObject.Find("UI").GetComponent<ExitMenu>().scoreFinal();
		}


		if (collision.gameObject.tag.Equals("Trap"))
        {
			suara.playsound("kena");
		}
		if (collision.gameObject.tag.Equals("Apple"))
		{
			suara.playsound("ambil");
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Teleporter"))
		{
			teleporter = collision.gameObject;
		}
        if (collision.CompareTag("Jatoh"))
        {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Teleporter"))
		{
			if (collision.gameObject.Equals(teleporter))
			{
				teleporter = null;
			}
		}
	}
}
