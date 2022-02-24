using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public bool top;

    public Rigidbody2D rigidBody;
    private PlayerMovement player;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        //Switch();
    }

    public void Switch()
    {
        RotateSprite();
        rigidBody.gravityScale *= -1;
    }

    public void RotateSprite()
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
