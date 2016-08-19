using UnityEngine;
using System.Collections;

[System.Serializable]
public class FPSMakeWeaponAdvnXML
{
    public string weaponName;
    public string description;
    public float reloadtime = 0.5f;
    public float FOVwalk = 60f;
    public float FOVSniper = 30f;
    public float FOVspeed = 1f;


    public weaponchange[] weapSchanger = new weaponchange[1];
    public string Ammotype = "9mm";
    public string weapdataName;

    public float fireRate = .5f;
    public int damage = 10;
    public float range = 100;
    public float brusttime;
    public float shotgun;

    public Vector3 rest;
    public float resttime = 1f;
    public Vector3 maxKB;
    public float kbtime;

    public Vector3 unzoom;
    public float zooming;
    public Vector3 zoomed;

    public float zoomRotspeed = 1f;

    public float putawaytime;

    public float spread;
    public float rang;
    public LayerMask lay;

    public int MaxInChips = 10;
    public string bullet;
}
