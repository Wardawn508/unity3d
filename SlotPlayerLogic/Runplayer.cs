using UnityEngine;

public class Runplayer : basicPlayer
{
    public float walk = 6.0F, Run = 10f;
    

	// Use this for initialization
    public override void Start()
    {
        base.Start();
        speed = adjustspeed(false);

     
    }
	
    //// Update is called once per frame
    //public override void Update()
    //{
    //    base.Update();

     

    //}

    public override void Horizontal(float _horizontal)
    {
        Hvalues = _horizontal;
    
    }

    public override void Vertical(float _Vertical)
    {
        Vvalues = _Vertical;
    }

    public virtual void Speed(bool speeder) 
    {
       speed = adjustspeed(speeder);
  
    
    }

    
    float adjustspeed(bool getspeed)
    {

        if (getspeed == true) 
        {
            return Run;
        }
       
        return walk;
        
    }

    //void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    //Debug.Log(" this is how dum we hit " + hit.controller.velocity.y);
    //}

}
