using UnityEngine;
using System.Collections;

public class Fullauto : weaponTypes
{
    [SerializeField]
    private WeaponBaseSystems systems;

    public override void OnStart(WeaponBaseSystems sys)
    {
        systems = sys;
    }

    public override void CallbackShot()
    {
        systems.Firing();
    }

 
}
