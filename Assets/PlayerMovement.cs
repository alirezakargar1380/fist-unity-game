using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    float dirX = 0f;
    private bool startGame;

    private enum MovementState { stay, walking, jumping }
    // private MovementState state = MovementState.stay;

    [SerializeField] private LayerMask jumpableGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        startGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        // setup movement
        rb.velocity = new Vector2(dirX * 14f, rb.velocity.y);

        if (Input.GetKey("space"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 7f);
        }

        // Debug.Log(startGame);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (!IsGround() && !startGame)
        {
            rb.gravityScale = 0.2f;
            state = MovementState.jumping;
            anim.SetInteger("state", (int)state);
            return;
        }

        if (IsGround() && !startGame)
        {
            rb.gravityScale = 1;
            startGame = true;
            state = MovementState.stay;
            anim.SetInteger("state", (int)state);
        }

        if (dirX > 0f)
        {
            state = MovementState.walking;
            Debug.Log(sprite);
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

    private bool IsGround()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
