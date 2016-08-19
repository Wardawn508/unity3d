using UnityEngine;
using System.Collections;

public class brust : weaponTypes
{

    public override void OnStart(WeaponBaseSystems sys)
    {
    }

    public override void CallbackShot()
    {
        Weapon.weapclass.shotAction = 3;
    }
}
