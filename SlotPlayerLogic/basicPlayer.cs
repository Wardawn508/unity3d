using UnityEngine;
using System.Collections;
using System.Threading;

public abstract class basicPlayer : SlotPlayer {
     [Range( 0, 50)]
    public float speed = 6.0F, jumpSpeed = 8.0F, gravity = 20.0F, Hvalues = 0f, Vvalues = 0f;
    private Vector3 moveDirection = Vector3.zero;
    [SerializeField]
    CharacterController controller;
    //Thread t;
    

    // Use this for initialization
    public override void Start()
    {
        base.Start();

        PlayerEventsSloted Tempevent = this.transform.GetComponent<PlayerEventsSloted>();


        MouseLookly.Init(this.transform, Camera.main.transform);

        //t = new Thread(new ThreadStart(this.Update));

        

        Tempevent._Horizontal += this.Horizontal;
        Tempevent._Vertical += this.Vertical;

       
    }

    // Update is called once per frame
    public override  void Update()
    {
        //base.Update();

        if (controller.isGrounded)
        {
            MouseLookly.LookRotation(this.transform, Camera.main.transform);
            
            //moveDirection.Set(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            moveDirection.Set(Hvalues, 0f, Vvalues);

            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    public virtual void Horizontal(float _horizontal)
    {
        Hvalues = _horizontal;

    }

    public virtual void Vertical(float _Vertical)
    {
        Vvalues = _Vertical;

    }




}
