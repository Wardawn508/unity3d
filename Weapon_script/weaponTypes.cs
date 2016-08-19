using System;
using UnityEngine;
using System.Collections;

[System.Serializable]
public class weaponTypes : ScriptableObject
{

    // Use this for initialization
    public virtual void OnStart(WeaponBaseSystems system = null) { }

    // Update is called once per frame
    public virtual void CallbackShot() { }
}