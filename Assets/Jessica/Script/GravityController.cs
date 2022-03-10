using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    private bool top;

    private Rigidbody2D rigidBody;
    private PlayerMovement player;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        Switch();
    }

    public void Switch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            RotateSprite();
            rigidBody.gravityScale *= -1;
        }
    }

    void RotateSprite()
    {
        if (!top)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }

        player.facingRight = !player.facingRight;
        top = !top;
    }
}
