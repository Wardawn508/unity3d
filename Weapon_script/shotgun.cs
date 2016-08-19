using UnityEngine;
using System.Collections;

public class shotgun : weaponTypes
{
    [SerializeField]
    private WeaponBaseSystems systems;

    public override void OnStart(WeaponBaseSystems sys)
    {
        systems = sys;
    }

    public override void CallbackShot()
    {
        systems.shotgun();
    }
}
