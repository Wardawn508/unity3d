using System;
using UnityEngine;
using System.Collections;


public class WeaponBaseSystems : ScriptableObject
{
   

	public Weapon_Sway sway;
	[SerializeField]
	Vector3 offsetb = Vector3.zero;
    [SerializeField]
    private weaponTypes[] callbacks;
    [SerializeField]
    private WAR_INPUTS inputs;

	public void OnStart()
	{
        
		sway.Init(Weapon.weapclass.WeaponTrans);
        for (int i = 0; i < callbacks.Length; i++)
        {
            callbacks[i].OnStart(this);
        }

	}


	public void OnUpdate()
	{
		sway.swayUpdate ();
        GunActions();
	
	
	
	}

	private void GunActions()
	{
        //if (Cursor.lockState == CursorLockMode.None && Weapon.weapclass.debugs == false)
        //{
        //    return;
        //}
        //else 
        if
           (Input.GetKeyDown(Weapon.weapclass.input.reloadkey) && Weapon.weapclass.ReloadingAction == false)
        {

            Weapon.weapclass.ReloadingAction = true;
        }
        else
			if
				(Weapon.weapclass.input.Fire == true && Weapon.weapclass.input.walk == false && Weapon.weapclass.ReloadingAction == false && Weapon.weapclass.Ingun > 0 )

			{

				if(Weapon.weapclass.firetime <= Time.time)
				{

                    callbacks[(int)Weapon.weapclass.Weapontype].CallbackShot();
                    Weapon.weapclass.weapbeviour.Setup();
                    Weapon.weapclass.Anim.InstantPlay("Fire");
				}

			}
	}

	public void Firing()
	{
		Weapon.weapclass.firetime = Time.time + Weapon.weapclass.Weapondata.fireRate;
		Weapon.weapclass.GunPlay.kick(Weapon.weapclass.Weapondata.maxKB );
		rayfire();
		Weapon.weapclass.Ingun--;
	}

	public void Firingbrust()
	{
		
		Weapon.weapclass.firetime = Time.time + Weapon.weapclass.Weapondata.brusttime;
		Weapon.weapclass.GunPlay.kick(Weapon.weapclass.Weapondata.maxKB);
		Weapon.weapclass.shotAction = 3;

	}


	public void shotgun()
	{
		Weapon.weapclass.firetime = Time.time + Weapon.weapclass.Weapondata.shotgun;
		Weapon.weapclass.shotAction = 4;
		Weapon.weapclass.Ingun--;
		Weapon.weapclass.GunPlay.kick(Weapon.weapclass.Weapondata.maxKB);
		//helpclass.anim.Play("fire");
	}


	public void FixedUpdate()
	{	
		while(Weapon.weapclass.Weapontype == weapontype.shotgun && Weapon.weapclass.shotAction>0){
			rayfire();
			Weapon.weapclass.shotAction--;
		}
	}






	public void rayfire()
	{
		
		Vector3 direction = Weapon.weapclass.weapCam.transform.TransformDirection(new Vector3( UnityEngine.Random.Range(-0.01f, 0.01f) * Weapon.weapclass.Weapondata.spread,  UnityEngine.Random.Range(-0.01f, 0.01f) * Weapon.weapclass.Weapondata.spread, 1));
	
		Ray ray = new Ray(Camera.main.transform.position, direction);

		Transform hitTransform;
		Vector3 hitPoint;

		hitTransform = FindHitObject(ray, out hitPoint);

		if (hitTransform != null)
		{
			if (hitTransform.CompareTag("moveable"))
			{
				hitTransform.GetComponent<Rigidbody>().AddForceAtPosition(Camera.main.transform.forward * 500f, hitPoint);
			}
			Debug.Log("We hit: " + hitTransform.name);

			if (hitTransform.CompareTag("NPC"))
			{
				// this is were we do damage stuff like 
				hitTransform.SendMessage("Damageable", Weapon.weapclass.Weapondata.damage, SendMessageOptions.DontRequireReceiver);

			}
			//hitTransform.SendMessage("gothit",SendMessageOptions.DontRequireReceiver);
		}
	}

	public Transform FindHitObject(Ray ray, out Vector3 hitPoint)
	{

		RaycastHit[] hits = Physics.RaycastAll(ray, Weapon.weapclass.Weapondata.rang, Weapon.weapclass.Weapondata.lay);

		Transform closestHit = null;
		float distance = 0;
		hitPoint = Vector3.zero;



		foreach (RaycastHit hit in hits)
		{
			if (hit.transform != Weapon.weapclass.transform.root && (closestHit == null || hit.distance < distance))
			{
				
				closestHit = hit.transform;
				distance = hit.distance;
				hitPoint = hit.point;
				var rot = Quaternion.FromToRotation(Vector3.up, hit.normal);
                GameObject.Instantiate(Weapon.weapclass.Weapondata.bullet, hit.point + offsetb, rot);
			}
		}
		// closestHit is now either still null (i.e. we hit nothing) OR it contains the closest thing that is a valid thing to hit
		return closestHit;
	}

    public void gold() 
    {
        //yield return new WaitForSeconds(.5f);
        Debug.Log("hehe");
    }

   
}
