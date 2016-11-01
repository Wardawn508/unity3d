using UnityEngine;
using System;
using System.Collections.Generic;


public abstract class Weapon_manager : MonoBehaviour
{
    public static Weapon_manager _Wmaster;

    public Transform WeapTrans;
    [HideInInspector]
	public Slot1 WeapSlot1;
    //[HideInInspector]
    public WeapActions W_Actions;

    public static Dictionary<string, Scopevalues> weaponDataCollections = new Dictionary<string,Scopevalues>();

	// Use this for initialization
	public virtual void Start()
    {
        _Wmaster = this;
        PlayerEventsSloted Tempevent = this.transform.GetComponent<PlayerEventsSloted>();

        Tempevent.isAim += this.AIm;
        Tempevent.isRunning += this.Walk;
        Tempevent.Changeweap += this.Changing;
        Tempevent.isReloadSet += this.reloadSet;
        Tempevent.isShooting += this.Firevalues;
        
	}

    // Update is called once per frame
    public virtual void Update () {
       
	}

    public virtual void Pickup(meleeTypes P_upObj)
    {

    }

    public virtual void Pickup(Slot2 P_upObj)
    {

    }
    public virtual void Pickup()
    {

    }

	public virtual void Weapon(int types,string Loadtype)
	{

	}

    public virtual void Changing() 
    {
    
    
    }

    public virtual void AIm(bool isAim , bool walk)
    {

        
    }

    public virtual void Walk(bool Iswalking,bool aim)
    {

    }

    public virtual void GunClose()
    {

    }

    public virtual void Firevalues(bool isfiring) 
    {
        
    }

    public virtual void reloadSet(bool set)
    {
        
    
    }


}



