using System;
using UnityEngine;
using System.Collections;
[System.Serializable]
public class indieBehaviourScript : Playerbase
{
   
    public GameObject camObj;
    public float speed = 1f;
    public bool init = false;

   
    [SerializeField]
    private float Magnitude;

	// Use this for initialization
    public override void OnStart()
    {
       
        anim.animPlay(animtoplay);
        camObj.SetActive(true);
    }
	
	// Update is called once per frame
    public override void OnUpdate()
    {
        Magnitude = controller.velocity.magnitude;
        if (Weapon.weapclass.input.Horizontal == 0 && Weapon.weapclass.input.Vertical == 0 && Magnitude == 0) 
        {
            camObj.transform.Rotate(Vector3.forward, speed * Time.deltaTime,Space.Self);
        
        
        }else if(Magnitude != 0) 
        {
            if (init == false)
            {
                init = true;
                changestate();
            }
        }

    }

    private void changestate()
    {
        
        controller.GetComponent<AdvanPlayerObj>().MyPlayerstate = CurrPlayer.walking;
        init = false;
    }

    public override void animset(animbase animset)
    {
        base.animset(animset);
    }

}
