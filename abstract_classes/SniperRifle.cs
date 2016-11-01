using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public abstract class SniperRifle :WeapActions
{

    //public UnityEvent ShootLogic;
       [Range(0, 200)]
    public float Range;

    public LayerMaskGun WeaponLayer;
       [Range(0, 50)]
    public float Damage;

    public bool Roading = false;

    public bool Shooting;

    //public float MinAcc;

    //public float MaxAcc;

    //public float Acc;
       [Range(0f, 10f)]
	public float Firetime;
    [HideInInspector]
	public float _fireTime;
    public int Ammo;
	public Vector2 MaxKick;

   


	// Use this for initialization
	public virtual void Start () {
        _fireTime = Tfire();
	
	}
	
	// Update is called once per frame
	public virtual void Update ()
    {



	
	}

    public virtual void Raycast ()
    {

    }

    public virtual void Rigbody()
    {
    
    
    }

    public virtual void Firing()
	{
 

	}

    public override void Fire(bool Shots)
    {
        Shooting = Shots;
    }
       [Range(0.3f, 30f)]
	public float smoothTime = 0.3F;
    [HideInInspector]
	public Vector3 velocity = Vector3.zero;

	public virtual void kick(Vector3 kic)
	{
		
	}

    public GameObject BulletHole;
    public virtual GameObject Bullethole (string Tag)
    {
        

        return new GameObject();
    }

	public virtual void tagweap(string tag,Transform target, Vector3 hitPoint)
	{


		switch (tag)
		{

		case "moveable":
			target.GetComponent<Rigidbody>().AddForceAtPosition(Camera.main.transform.forward * 500f, hitPoint);
			break;

		case "NPC":
			target.SendMessage("Damageable", Damage, SendMessageOptions.DontRequireReceiver);
			break;

		default:
			break;
		}
	}

    public virtual void WeaponTran( Transform trans)
    {
	
	
	}
   

	public virtual float Tfire()
	{
		return Firetime;
	}

    public virtual void Paway()
    {

    }



    public override void AIm(bool isAim,bool iswalk)
    {
        
    }

    public override void Walk(bool Iswalking,bool isaim)
    {
       
    }



    public override void GunClose()
    {
        
    }

    public override void Reload(bool isreloading)
    {

    }
}
