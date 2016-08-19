using UnityEngine;
using System.Collections;

public class Snpier : weaponMoverBase
{
    private WeaponMover parentclass;
    private bool init = false;

    // Use this for initialization
    public override void OnStart()
    {
        if (init == true) { return; }
        StartCoroutine("weapplacementSniper");
        Weapon.weapclass.Anim.animPlay("Idle");
        
    }

    // Update is called once per frame
    public override void OnUpdate()
    {

        if (Input.GetButtonUp("zoom") || Weapon.weapclass.input.zooms == false || Input.GetKeyDown(KeyCode.R))
        {
            Weapon.weapclass.input.zooms = false;
            StopCoroutine("weapplacementSniper");
            init = false;
            Changemodes();
        }
    }

    IEnumerator weapplacementSniper()
    {
        while (Weapon.weapclass.Gun.transform.localPosition != Weapon.weapclass.Weapondata.zoomed)
        {
            init = true;
            Weapon.weapclass.Gun.transform.localPosition = Vector3.Lerp(Weapon.weapclass.Gun.transform.localPosition, Weapon.weapclass.Weapondata.zoomed, Weapon.weapclass.Weapondata.zooming * Time.deltaTime);
           // Weapon.weapclass.Gun.transform.localEulerAngles = Weapon.weapclass.Weapondata.xoomRot;
            Weapon.weapclass.weapCam.fieldOfView = Mathf.Lerp(Weapon.weapclass.weapCam.fieldOfView, Weapon.weapclass.Weapondata.FOVSniper, Weapon.weapclass.Weapondata.FOVspeed * Time.deltaTime);
            yield return null;
        }
        warLogger.add("moving");
        init = false;
    }

    [SerializeField]
    private WeapMode currstateGO = WeapMode.hip;
    private void Changemodes()
    {
        parentclass.WmoveSetter = currstateGO;

    }

    public void Listener(WeaponMover mover)
    {
        parentclass = mover;
    }
}
