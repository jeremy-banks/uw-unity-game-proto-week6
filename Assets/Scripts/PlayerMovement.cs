using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D myRB;
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpForce;
    float direction;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");
        if ( Input.GetKeyDown(KeyCode.Space))
        {
            myRB.velocity = new Vector2(myRB.velocity.x, jumpForce);
        }
    }
}
