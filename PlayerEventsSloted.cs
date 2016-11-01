using UnityEngine;
using System.Collections;


public class PlayerEventsSloted : MonoBehaviour
{
    public delegate void Changeing();
    public event Changeing Changeweap;

    //[SerializeField]
    private KeyCode ChangeWeap = KeyCode.Tab;


    //[SerializeField]
    private KeyCode _speedKey = KeyCode.LeftShift;

    private bool runvalues = false;

    public delegate void Running(bool _Running, bool _aim);
    public event Running isRunning;
    [System.NonSerialized]
    public bool aimvalues = false;
    public delegate void Aiming(bool _insAim, bool _running);
    public event Aiming isAim;

    private bool Reloadvalues = false;
    public bool MyReloads 
    {
        set 
        {
            Reloadvalues = value;
            isReloadSet(Reloadvalues);
        }
    }
    public KeyCode Reloadkey = KeyCode.R;
    public delegate void ReloadSet(bool _setReload);
    public event ReloadSet isReloadSet;

    private bool firevalues;
    public KeyCode FireKey = KeyCode.Mouse0;
    public delegate void Shots(bool _inShots);
    public event Shots isShooting;

    float hvalues;
    public delegate void Horizontal(float horizontal);
    public event Horizontal _Horizontal;

    float Vvalues;
    public delegate void Vertical(float vertical);
    public event Vertical _Vertical;



    public delegate void HandV(float horizontal, float vertical);
    public event HandV _HandV;
    [System.NonSerialized]
    public int Anim = 0;
    public delegate void AnimTrans(int animT);
    public event AnimTrans _animT;

    //public delegate void PlayerUpdate(bool _Running, bool _aim, bool Reloads, int _animstate);
    //public event PlayerUpdate _pUpdates;


    // Use this for initialization
    void Start()
    {
        runvalues = true;
        Anim = 0;
        aimvalues = false;
    }

    // Update is called once per frame
    void Update()
    {

        //if (_pUpdates != null) 
        //{
        //    _pUpdates(runvalues, aimvalues,Reloadvalues, Anim);

        //}

        

        if (Input.GetKeyDown(ChangeWeap))
        {
            if (Changeweap != null)
            {
                Changeweap();
            }
        }


        if (runvalues == true)
        {


            if (Input.GetKeyDown(_speedKey))
            {

                
                isRunning(runvalues = false, aimvalues = false);

                _animT(Anim = 1);
                return;

            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                isAim(aimvalues = true, runvalues = true);

            }
            if(Input.GetKeyUp(KeyCode.Mouse1))
            {
                isAim(aimvalues = false, runvalues);

            }



            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                isShooting(true);

            }
            
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                isShooting(false);
            }

            if (Input.GetKeyDown(Reloadkey))
            {
                isReloadSet(Reloadvalues = true);
            }
        }

        if (runvalues == false)
        {
            if (Input.GetKeyUp(_speedKey))
            {
                
                isRunning(runvalues = true, aimvalues = false);

                _animT(Anim = 0);

            }



        }



        if (_Horizontal != null)
        {

            _Horizontal(Input.GetAxis("Horizontal"));
        }

        if (_Vertical != null)
        {

            _Vertical(Input.GetAxis("Vertical"));
        }

        if (_HandV != null)
        {
            _HandV(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        }
    }
}