using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool hit = false;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;


    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void takeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if(currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
            StartCoroutine(Invunerability());
        }
        else
        {
            anim.SetTrigger("Die");
            GetComponent<PlayerMovement>().enabled = false;
            FindObjectOfType<GameOver>().gameOverMessage();
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Trap")
        {
            if (!hit)
            {
                hit = true;
                takeDamage(1);
            }
        }
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(6, 9, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            hit = false;
        }
        Physics2D.IgnoreLayerCollision(6, 9, false);
    }
}
