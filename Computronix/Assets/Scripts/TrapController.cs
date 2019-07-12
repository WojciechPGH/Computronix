using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    public float timeToFire = 1f;
    public bool trigger = false;
    public bool automaticTrigger = false;
    private bool canHurt = false;
    SpriteRenderer spriteRenderer;
    public Sprite[] textures;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(TriggerTrap());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && automaticTrigger == true)
        {
            trigger = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && canHurt == true)
        {
            collision.GetComponent<PlayerController>().Injure();
        }
    }

    public IEnumerator TriggerTrap()
    {
        while(true)
        {
            if(trigger == true)
            {
                if (automaticTrigger == true)
                {
                    yield return new WaitForSeconds(timeToFire);
                    canHurt = true;
                    spriteRenderer.sprite = textures[1];
                    yield return new WaitForSeconds(timeToFire);
                    canHurt = false;
                    spriteRenderer.sprite = textures[0];
                    trigger = false;
                }
                else
                {
                    canHurt = true;
                    spriteRenderer.sprite = textures[1];
                    yield return new WaitForSeconds(timeToFire);
                    canHurt = false;
                    spriteRenderer.sprite = textures[0];
                    trigger = false;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
