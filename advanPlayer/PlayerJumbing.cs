using UnityEngine;
using System.Collections;

public class PlayerJumbing : Playerbase
{
   
  
    private string Jump = "Jump";
    private string landed = "Landed";
    public float gravity = 10;
  
    // Use this for initialization
    public override void OnStart()
    {
      
            //anim.animPlay(Jump);
        
        //GameState.gamestate.NPCtriggerFixedUpdate += OnFixedUpdate;
    }

    // Update is called once per frame
    public override void OnUpdate()
    {
        //moveDirection.y = jumpSpeed;
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        Ihitground();

    }
    void Ihitground()
    {
        if (controller.collisionFlags == CollisionFlags.Below)
        {
            player.MyPlayerstate = CurrPlayer.walking;
            //anim.animPlay(landed);

            //GameState.gamestate.NPCtriggerFixedUpdate -= OnFixedUpdate;
        }
    }
    public override void OnFixedUpdate()
    {

    }
    public override void animset(animbase animset)
    {
        base.animset(animset);
    }
}
