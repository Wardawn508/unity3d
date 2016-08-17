using System;
using UnityEngine;
using System.Collections;
using WarFPS.Characters.Inputs;
[System.Serializable]

public class Playerbase {

    public int StateGo = 0;
    public PlayerValues values;
    public CharacterController controller;

    public WAR_INPUTS W_inputs;
    [HideInInspector]
    public Vector3 moveDirection = Vector3.zero;

    public AdvanPlayerObj player;

    public animbase anim;

    public string animtoplay;

    
	// Use this for initialization
	public virtual void OnStart () {
 
	}
	
	// Update is called once per frame
    public virtual void OnUpdate()
    {

    }

    public virtual void OnFixedUpdate() 
    {

    }

    public virtual void animset(animbase animset ) 
    {

        anim = animset;
    }

 
}

public enum CurrPlayer {idie,walking,running,isJumbing ,Chating,death,InMenu,IsPaused }