using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //TODO: Nuke this next line of code when observer pattern is correctly incorporated
    public delegate void ObserverTest(int number);
    public static event ObserverTest observerTest;

    public bool facingRight;
    
    public float speed;
    public float jumpForce;
    public float checkRadius;

    public Transform groundedCheck;
    public LayerMask ground;

    private bool isGrounded;
    
    private float moveInput;

    private int numberOfJumps = 1;
    
    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundedCheck.position, checkRadius, ground);

        Move();
    }

    void Update()
    {
        //TODO: Nuke this next line of code when observer pattern is correctly incorporated
        TestFunctionForObserver();
        Jump();
    }

    private void Move()
    {
        moveInput = Input.GetAxis("Horizontal");

        rigidBody.velocity = new Vector2(moveInput * speed, rigidBody.velocity.y);

        if (!facingRight && moveInput > 0)
        {
            FlipSprite();
        }
        else if (facingRight && moveInput < 0)
        {
            FlipSprite();
        }
    }

    void FlipSprite()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && numberOfJumps > 0)
        {
            rigidBody.velocity = Vector2.up * jumpForce;
            numberOfJumps--;
        }

        if (isGrounded)
        {
            numberOfJumps = 1;
        }
    }

    public Vector2 GetPlayerVelocity()
    {
        return rigidBody.velocity;
    }

    //TODO: Nuke this next line of code when observer pattern is correctly incorporated
    public void TestFunctionForObserver()
    {
        if (numberOfJumps == 0)
        {
            observerTest?.Invoke(5);
        }
    }
}
