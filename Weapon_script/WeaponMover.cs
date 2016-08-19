using UnityEngine;
using System.Collections;

public class WeaponMover : MonoBehaviour
{

	[SerializeField]
	private weaponMoverBase[] MoveState;

	private WeapMode currstate = WeapMode.hip;

    public WeapMode WmoveSetter 
    {
        get
        {
            return currstate;
        }
        set
        {
            currstate = value;
            Setup();
        }
    }

	// Use this for initialization
	public void OnStart () {
        WmoveSetter = WeapMode.hip;
        SendMessage("Listener", this, SendMessageOptions.DontRequireReceiver);
        Setup();
	}

    public void Setup() 
    {
     MoveState[(int)currstate].OnStart();
    
    }
	
	// Update is called once per frame
	public void OnUpdate () {
        MoveState[(int)currstate].OnUpdate();
       
	}
    

}
