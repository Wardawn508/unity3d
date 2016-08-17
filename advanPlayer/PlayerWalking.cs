using System;
using UnityEngine;
using System.Collections;
using WarFPS.Characters.Inputs;

[System.Serializable]
public class PlayerWalking : Playerbase
{
    
    public float speed = 6.0F, jumpSpeed = 8.0F, gravity = 20.0F;

    //pretty much what it says
    //private CollisionFlags m_CollisionFlags = 0;
    // its a CharacterController I dont no how else to say it sorry.
   
    [SerializeField]
    private float Magnitude = 0f;

   
   
    public override void OnStart()
    {
        speed = values.speed;
        
    }

    // Update is called once per frame
    public override void OnUpdate()
    {
        
        if (W_inputs.walk == true) 
        {
            player.MyPlayerstate = CurrPlayer.running;
    
            return;
        
        }
        Magnitude = Mathf.Clamp01(controller.velocity.magnitude);

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(W_inputs.Horizontal, 0, W_inputs.Vertical);
            moveDirection = player.transform.TransformDirection(moveDirection);
            moveDirection *= speed;


            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                player.jumping(moveDirection);
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        if (anim != null && controller.isGrounded && W_inputs.zooms == false)
        {

            anim.animPlay(animtoplay, Magnitude);


        }
        if (controller.isGrounded == false)
        {
            player.jumping(moveDirection);

        }
    }

    public override void OnFixedUpdate()
    {
 	
        //base.OnFixedUpdate();
         

    
    }
    public override void animset(animbase animset)
    {
        base.animset(animset);
    }
    
    
    
    }
