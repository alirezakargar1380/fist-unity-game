using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private Animator anim;
    float dirX = 0f;

    private enum MovementState { stay, walking, jumping }
    // private MovementState state = MovementState.stay;

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
        dirX = Input.GetAxis("Horizontal");
        // setup movement
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);

        // Debug.Log(dirX);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (Input.GetKey("space"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 7f);
        }

        if (dirX > 0f)
        {
            state = MovementState.walking;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.walking;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.stay;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }

        anim.SetInteger("state", (int)state);
    }
}
