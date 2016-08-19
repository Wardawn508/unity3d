
using UnityEngine;
using System.Collections;

[System.Serializable]
public class WeaponMovements : ScriptableObject {


	public void WeapStates()
	{
		if (Weapon.weapclass.input.zooms == false && Weapon.weapclass.input.walk == false && Weapon.weapclass.debugs == false && Weapon.weapclass.ReloadingAction == false) {
			Weapon.weapclass.Anim.animPlay ("Idle01", false);

			Weapon.weapclass.Gun.transform.localPosition = Vector3.Lerp (Weapon.weapclass.Gun.transform.localPosition, Weapon.weapclass.Weapondata.rest, Weapon.weapclass.Weapondata.resttime * Time.deltaTime);


		} else if (Weapon.weapclass.input.zooms == true && Weapon.weapclass.input.walk == false && Weapon.weapclass.debugs == false && Weapon.weapclass.ReloadingAction == false) {
			//weapstatbehavers = 1;
			Debug.Log ("your in zoom");
			Weapon.weapclass.Anim.animPlay ("Run", false);


			Weapon.weapclass.Gun.transform.localPosition = Vector3.Lerp (Weapon.weapclass.Gun.transform.localPosition, Weapon.weapclass.Weapondata.zoomed, Weapon.weapclass.Weapondata.zooming * Time.deltaTime);


		} else if (Weapon.weapclass.input.zooms == false && Weapon.weapclass.input.walk == true && Weapon.weapclass.debugs == false && Weapon.weapclass.ReloadingAction == false) {
			//weapstatbehavers = 2;
			Weapon.weapclass.Gun.transform.localPosition = Vector3.Lerp (Weapon.weapclass.Gun.transform.localPosition, Weapon.weapclass.Weapondata.rest, Weapon.weapclass.Weapondata.resttime * Time.deltaTime);

			//	if (moving == Vector3.zero) { Weapon.weapclass.Anim.SetBool("Run", false);
			//	}

            Weapon.weapclass.Anim.animPlay("Run", true);

		} else if (Weapon.weapclass.ReloadingAction == true) {
			//weapstatbehavers = 3;
			Weapon.weapclass.Gun.transform.localPosition = Vector3.Lerp (Weapon.weapclass.Gun.transform.localPosition, Weapon.weapclass.Weapondata.rest, Weapon.weapclass.Weapondata.resttime * Time.deltaTime);

		}
	}

      public float smoothTime = 0.3F;
        private Vector3 velocity = Vector3.zero;
		public void kick(Vector3 kic)
		{
            Vector3 junk = Vector3.zero; 
                junk.Set(Random.Range(-0.1f, .1f), Random.Range(-0.1f, .1f), Random.Range(-0.1f, .1f));
            
            velocity = kic + junk;
        //Weapon.weapclass.Gun.transform.localPosition = Vector3.Lerp(Weapon.weapclass.Gun.transform.localPosition , Weapon.weapclass.Gun.transform.localPosition + kic/2,Weapon.weapclass.Weapondata.kbtime);
        //    //its a Mesh on and off base with are sounds....
			//helpclass.MuzzleFlash();

            Weapon.weapclass.Gun.transform.localPosition = Vector3.SmoothDamp(Weapon.weapclass.Gun.transform.localPosition, kic, ref velocity, smoothTime);
    }
}
