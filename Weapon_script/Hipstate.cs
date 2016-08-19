using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hipstate : weaponMoverBase
{


	private WeaponMover parentclass;
    private bool init = false;

	// Use this for initialization
	public override void OnStart () {
        if (init == true) { return; }
		StartCoroutine ("weapplacement");
        init = true;
	}
	
	// Update is called once per frame
	public override void OnUpdate () 
	{

        if (Input.GetButtonDown("zoom"))
        {
            Weapon.weapclass.input.zooms = true;
            StopCoroutine("weapplacement");
            init = false;
            Changemodes();
        }
	}

	IEnumerator weapplacement()
	{
        while (Weapon.weapclass.Gun.transform.localPosition != Weapon.weapclass.Weapondata.rest)
        {
            init = true;
            Weapon.weapclass.Gun.transform.localPosition = Vector3.Lerp(Weapon.weapclass.Gun.transform.localPosition, Weapon.weapclass.Weapondata.rest, Weapon.weapclass.Weapondata.resttime * Time.deltaTime);
           
            Weapon.weapclass.weapCam.fieldOfView =  Mathf.Lerp( Weapon.weapclass.weapCam.fieldOfView,Weapon.weapclass.Weapondata.FOVwalk,Weapon.weapclass.Weapondata.FOVspeed *Time.deltaTime);
            yield return null;
        }
        Debug.Log("moving");
        init = false;
	}

    [SerializeField]
    private WeapMode currstateGO = WeapMode.hip;
	private void Changemodes()
	{
        parentclass.WmoveSetter = currstateGO;
		
	}

	public void Listener (WeaponMover mover)
	{
		parentclass = mover;
	}

    

}
