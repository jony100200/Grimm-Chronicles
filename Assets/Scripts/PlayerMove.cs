using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  DragonBones;

public class PlayerMove : MonoBehaviour
{
    protected Rigidbody2D myBody;
    [SerializeField] protected float _moveSpeed = 1.5f;
    protected UnityArmatureComponent playerAnimations;


    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        playerAnimations = GetComponent<UnityArmatureComponent>();
    }

    void FixedUpdate()
    {
        Move();
    }

    protected void Move()
    {
        var h = Input.GetAxisRaw("Horizontal");
        if (h > 0)
        {
            myBody.velocity= new Vector2(_moveSpeed,myBody.velocity.y);
            playerAnimations.armature.flipX = true;
            playerAnimations.animation.Play("walk");
        }
        else if (h<0)
        {
            myBody.velocity = new Vector2(-_moveSpeed, myBody.velocity.y);
            playerAnimations.armature.flipX = false;
            playerAnimations.animation.Play("walk");
        }
        else
        {
            myBody.velocity = new Vector2(0f, myBody.velocity.y);
            playerAnimations.animation.Play("Idle");
            playerAnimations.animation.Stop("walk");
        }
    }
}
