using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    PlayerMovement playerMovement;
    Animator animator;

    void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerWalkingAnimation();
        PlayerActivationAnimation();
    }

    void PlayerWalkingAnimation()
    {
        animator.SetFloat("Movement", playerMovement.GetPlayerVelocity().magnitude);
    }

    void PlayerActivationAnimation()
    {

    }

}
