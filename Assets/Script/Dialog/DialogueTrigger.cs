using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
    public GameObject dialogbox;
    bool dialogActive;
    public GameObject torch;

    void Update()
    {
        if (dialogActive)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
            }
            else
            {
                dialogbox.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        dialogActive = true;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
    }
    public void endDialogue()
    {
        dialogActive = false;
        dialogbox.SetActive(false);
        torch.SetActive(true);
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
