using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D myRB;
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpForce;
    float direction;
    bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FlipPlayerSprite();

        direction = Input.GetAxisRaw("Horizontal");
        if ( Input.GetKeyDown(KeyCode.Space))
        {
            myRB.velocity = new Vector2(myRB.velocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        myRB.velocity = new Vector2 (direction * playerSpeed, myRB.velocity.y);
    }

    void FlipPlayerSprite()
    {
        if (isFacingRight && direction < 0f || !isFacingRight && direction > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 playerScale = transform.localScale;
            playerScale.x *= -1;
            transform.localScale = playerScale;
        }
    }
}
