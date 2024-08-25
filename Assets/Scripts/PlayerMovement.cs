using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D myRB;
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpForce;
    float horizontal;
    bool isFacingRight = true;

    [SerializeField] Transform groundDetect;
    [SerializeField] LayerMask groundLayer;

    Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        flipPlayerSprite();
        isRunning();
    }

    void LateUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if ( Input.GetKeyDown(KeyCode.Space) && isOnGround() )
        {
            myRB.velocity = new Vector2(myRB.velocity.x, jumpForce);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && myRB.velocity.y > 0f)
        {
            myRB.velocity = new Vector2(myRB.velocity.x, jumpForce * 0.5f);
        }
    }

    void FixedUpdate()
    {
        myRB.velocity = new Vector2 (horizontal * playerSpeed, myRB.velocity.y);
    }

    void flipPlayerSprite()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 playerScale = transform.localScale;
            playerScale.x *= -1;
            transform.localScale = playerScale;
        }
    }

    bool isOnGround()
    {
        return (Physics2D.OverlapCircle(groundDetect.position, 0.2f, groundLayer));
    }

    void isRunning()
    {
        if (horizontal != 0)
        {
            myAnimator.SetBool("isRunning", true);
        }
        else
        {
            myAnimator.SetBool("isRunning", false);
        }
    }
}
