using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        // setup movement
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);
        
        // Debug.Log(dirX);
        if (Input.GetKey("space"))
        {
           rb.velocity = new Vector2(rb.velocity.x, 7f);
        }

        if (dirX > 0f)
        {
            anim.SetBool("walking", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("walking", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("walking", false);
        }
    }
}
