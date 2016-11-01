using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider) )]
public class RigBodyWalker : RigbodyBasic
{

    public float speed = 6.0F, jumpSpeed = 8.0F, gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public float Hvalues = 0f;
    public float Vvalues = 0f;
    public war_MouseLook MouseLookly;
    
    
	// Use this for initialization
    public override void Start()
    {
        PlayerEventsSloted Tempevent = this.transform.GetComponent<PlayerEventsSloted>();

        MouseLookly.Init(this.transform, Camera.main.transform);

   
        Tempevent._Horizontal += this.Horizontal;
        Tempevent._Vertical += this.Vertical;

        if (rigBody == null) 
        {
            rigBody = GetComponent<Rigidbody>();
        
        }

    }



    public override void Update()
    {
        MouseLookly.LookRotation(this.transform, Camera.main.transform);
        if (jumpCooldown > 0)
        {
            jumpCooldown -= Time.deltaTime;
        }
    }

    

    public float timeToNextJump = 100f;
    public float jumpCooldown = 1f;

	// Update is called once per frame
    public override void FixedUpdate()
    {

        
            moveDirection.Set(Hvalues, 0f, Vvalues);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        

                if (Input.GetButtonDown("Jump") && jumpCooldown < 0.1f)
                {
                    rigBody.AddForce(0, jumpSpeed, 0 * Time.fixedDeltaTime, ForceMode.Impulse);
                    jumpCooldown = timeToNextJump; 

                }
                
                moveDirection.y -= gravity * Time.fixedDeltaTime;
                rigBody.MovePosition(transform.position + moveDirection * Time.fixedDeltaTime);
                
    }

    public override void Horizontal(float _horizontal)
    {
        Hvalues = _horizontal;

    }

    public override void Vertical(float _Vertical)
    {
        Vvalues = _Vertical;
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }

        if (collision.relativeVelocity.magnitude > 1f)
        {
            Debug.Log(" hit " + collision.relativeVelocity.magnitude);

        }
    }
}
