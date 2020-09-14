using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Movement speed variables
    public float movementSpeed = 1f;
    public float jumpForce = 1f;
    
    // Ground check variables
    public bool grounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        // Set rb to the player's rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        // Set horizontal user input and scale it by movementSpeed
        float xSpeed = Input.GetAxis("Horizontal") * movementSpeed;
        float ySpeed = rb.velocity.y;

        // Checks to see if bottom of the player is touching the ground
        grounded = Physics2D.OverlapCircle(groundCheck.position, .1f, groundLayer);

        // If holding up and grounded, set vertical speed
        if (Input.GetAxisRaw("Vertical") == 1 && grounded) {
            ySpeed = jumpForce;
        }

        // Update rigidbody's velocity
        rb.velocity = new Vector2(xSpeed, ySpeed);
    }
}
